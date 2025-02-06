using Microsoft.AspNetCore.Mvc;
using Projeto360.Dominio.Entidades;
using Projeto360.Dominio.Enumeradores;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Api.Models.Resposta;
using Projeto360.Aplicacao;

namespace Projeto360.Api
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpGet]
        [Route("Obter/{usuarioId}")]
        public async Task<ActionResult> ObterAsync([FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.ObterAsync(usuarioId);

                var usuarioResposta = new UsuarioResposta()
                {
                    ID = usuarioDominio.ID,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email                    
                };

                return Ok(usuarioResposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> CriarAsync([FromBody] UsuarioCriar usuarioCriar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Nome = usuarioCriar.Nome,
                    Email = usuarioCriar.Email,
                    Senha = usuarioCriar.Senha                    
                };

                var usuarioID = await _usuarioAplicacao.CriarAsync(usuarioDominio);

                return Ok(usuarioID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> AtualizarAsync([FromBody] UsuarioAtualizar usuarioAtualizar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    ID = usuarioAtualizar.ID,
                    Nome = usuarioAtualizar.Nome,
                    Email = usuarioAtualizar.Email
                };

                await _usuarioAplicacao.AtualizarAsync(usuarioDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("AlterarSenha")]
        public async Task<ActionResult> AlterarSenhaAsync([FromBody] UsuarioAlterarSenha usuarioAlterarSenha)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    ID = usuarioAlterarSenha.ID,
                    Senha = usuarioAlterarSenha.Senha
                };

                await _usuarioAplicacao.AlterarSenhaAsync(usuarioDominio, usuarioAlterarSenha.SenhaAntiga);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public async Task<ActionResult> Deletar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.DeletarAsync(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Restaurar/{usuarioId}")]
        public async Task<ActionResult> RestaurarAsync([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.RestaurarAsync(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> ListarAsync([FromQuery] bool ativos)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.ListarAsync(ativos);

                var usuarios = usuarioDominio.Select(usuario => new UsuarioResposta()
                {
                    ID = usuario.ID,
                    Nome = usuario.Nome,
                    Email = usuario.Email                                        
                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarTiposUsuario")]
        public IActionResult ListarTiposUsuario()
        {
            try
            {
                // Cria uma lista para armazenar os usuários
                var tiposUsuario = new List<object>();
                
                var valoresUsuarios = Enum.GetValues(typeof(TiposUsuario));

                foreach (var valor in valoresUsuarios)
                {
                    tiposUsuario.Add(new
                    {
                        id = (int)valor,
                        nome = Enum.GetName(typeof(TiposUsuario), valor)
                    });
                }

                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}













