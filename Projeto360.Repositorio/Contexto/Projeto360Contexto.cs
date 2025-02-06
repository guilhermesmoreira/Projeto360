using Microsoft.EntityFrameworkCore;
using Projeto360.Dominio.Entidades;
using Projeto360.Repositorio.Configuracoes;

public class Projeto360Contexto : DbContext
{
    private readonly DbContextOptions _options;
    
    public DbSet<Usuario> Usuarios { get; set; }

    public Projeto360Contexto()
    {}
    public Projeto360Contexto(DbContextOptions options) : base(options)
    {
        _options = options;
    }

    //<summary>
    // Configura as opções de conexão com o banco de dados.
    //</summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Gera um arquivo na pasta reposítorio. Não é necessário um banco de dados.
        if (_options == null)
            optionsBuilder.UseSqlite(@"Filename=./projeto360.sqlite;");
    }

    //<summary>
    //Aplica as configurações de entidade para o modelo de banco de dados.
    //<summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiuracoes());
    }
}