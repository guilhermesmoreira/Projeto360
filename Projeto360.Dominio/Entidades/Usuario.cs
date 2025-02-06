using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Dominio.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public TiposUsuario Tipo { get; set; }        

        public Usuario()
        {
            Ativo = true;

            Tipo = TiposUsuario.Gestor;
            
        }

        public void Deletar()
        {
            Ativo = false;
        }

        public void Restaurar()
        {
            Ativo = true;
        }
    }
}

