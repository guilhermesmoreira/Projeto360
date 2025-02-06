using Projeto360.Dominio.Entidades;
using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<int> CriarAsync(Usuario usuario)
        {
            if (usuario == null)
                throw new Exception("Usuário não pode ser vazio");

            ValidarInformacoesUsuario(usuario);

            if (string.IsNullOrEmpty(usuario.Senha))
                throw new Exception("Senha não pode ser vazio");

            return await _usuarioRepositorio.SalvarAsync(usuario);
        }       

        public async Task AtualizarAsync(Usuario usuario)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterAsync(usuario.ID);
            
            if (usuarioDominio == null)
                throw new Exception("Usuário não encontrado");
            
            ValidarInformacoesUsuario(usuario);

            usuarioDominio.Nome = usuario.Nome;
            usuarioDominio.Email = usuario.Email;
            usuarioDominio.TipoUsuarioId = usuario.TipoUsuarioId;
                
            await _usuarioRepositorio.AtualizarAsync(usuarioDominio);
        }

        public async Task AlterarSenhaAsync(Usuario usuario, string senhaAntiga)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterAsync(usuario.ID);
            
            if (usuarioDominio == null)
                throw new Exception("Usuário não encontrado");
            
            if (usuarioDominio.Senha != senhaAntiga)
                throw new Exception("Senha antiga inválida");

            usuarioDominio.Senha = usuario.Senha;
            
                
            await _usuarioRepositorio.AtualizarAsync(usuarioDominio);
        }

        public async Task<Usuario> ObterAsync(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterAsync(usuarioId);

            if(usuarioDominio == null)
                throw new Exception("Usuario não encontrado");
            
            return usuarioDominio;
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorEmailAsync(email);

            if(usuarioDominio == null)
                throw new Exception("Usuario não encontrado");
            
            return usuarioDominio;
        }

        public async Task DeletarAsync(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterAsync(usuarioId);

            if(usuarioDominio == null)
                throw new Exception("Usuario não encontrado");

            usuarioDominio.Deletar();

            await _usuarioRepositorio.AtualizarAsync(usuarioDominio);
        }

        public async Task RestaurarAsync(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterAsync(usuarioId);

            if(usuarioDominio == null)
                throw new Exception("Usuario não encontrado");

            usuarioDominio.Restaurar();

            await _usuarioRepositorio.AtualizarAsync(usuarioDominio);
        }

        public Task<IEnumerable<Usuario>> ListarAsync(bool ativo)
        {
            return _usuarioRepositorio.ListarAsync(ativo);
        }        

        #region Util

        private static void ValidarInformacoesUsuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome))
                throw new Exception("Nome não pode ser vazio");

            if (string.IsNullOrEmpty(usuario.Email))
                throw new Exception("E-mail não pode ser vazio");
        }

        #endregion
    }
}



