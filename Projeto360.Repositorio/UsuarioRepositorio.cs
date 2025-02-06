using Microsoft.EntityFrameworkCore;
using Projeto360.Dominio.Entidades;
using Projeto360.Dominio.Enumeradores;

namespace DataAcces.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(Projeto360Contexto contexto) : base(contexto)
        {
        }

        // public int Salvar(Usuario usuario)
        // {
        //     _contexto.Usuarios.Add(usuario);
        //     _contexto.SaveChanges();

        //     return usuario.ID;
        // }

        public async Task<int> SalvarAsync(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
            await _contexto.SaveChangesAsync();

            return usuario.ID;
        }

        // public void Atualizar(Usuario usuario)
        // {
        //     _contexto.Usuarios.Update(usuario);
        //     _contexto.SaveChanges();
        // }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        // public Usuario Obter(int usuarioId)
        // {
        //     return _contexto.Usuarios.
        //                     Where(u => u.ID == usuarioId)
        //                     .FirstOrDefault();
        // }

        public async Task<Usuario> ObterAsync(int usuarioId)
        {
            return await _contexto.Usuarios
                                 .Where(u => u.ID == usuarioId)
                                 .FirstOrDefaultAsync();            
        }

        // public Usuario ObterPorEmail(string email)
        // {
        //     return_contexto.Usuarios.
        //                     Where(u => u.Email == email)
        //                     .Where(u => u.Ativo)
        //                     .FirstOrDefaultAsync();
        // }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _contexto.Usuarios.
                            Where(u => u.Email == email)
                            .Where(u => u.Ativo)
                            .FirstOrDefaultAsync();
        }

        // public IEnumerable<Usuario> Listar(bool ativo)
        // {
        //     return _contexto.Usuarios.Where(u => u.Ativo == ativo).ToList();
        // }

        public async Task<IEnumerable<Usuario>> ListarAsync(bool ativo)
        {
            return await _contexto.Usuarios.Where(u => u.Ativo == ativo).ToListAsync();
        }        
    }
}