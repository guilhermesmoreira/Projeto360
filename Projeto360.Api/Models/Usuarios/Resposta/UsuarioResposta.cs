using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Api.Models.Resposta
{
    public class UsuarioResposta
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}

