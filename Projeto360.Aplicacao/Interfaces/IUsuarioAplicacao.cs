using Projeto360.Dominio.Entidades;

namespace Projeto360.Aplicacao
{
    public interface IUsuarioAplicacao
    {
        Task<int> CriarAsync(Usuario usuarioDTO);
        Task AlterarSenhaAsync(Usuario usuarioDTO, string senhaAntiga);
        Task AtualizarAsync(Usuario usuarioDTO);
        Task DeletarAsync(int usuarioId);
        Task RestaurarAsync(int usuarioId);
        Task<IEnumerable<Usuario>> ListarAsync(bool ativo);
        Task<Usuario> ObterAsync(int usuarioId);
        Task<Usuario> ObterPorEmailAsync(string email);
    }
}