using DesafioWebAPI.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using DesafioWebAPI.Services;
using DesafioWebAPI.Services.Base;
using System;
using System.Collections.Generic;
using DesafioWebAPI.Domain;

namespace DesafioWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdocaoController : ControllerBase
    {
        private readonly AdocaoService adocaoService;
        public AdocaoController(AdocaoService adocaoService)
        {
            this.adocaoService = adocaoService;
        }

        [HttpGet]
        public IEnumerable<Adocao> Get()
        {
            return adocaoService.ListarTodos();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = adocaoService.PesquisarPorId(id);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }
        [HttpGet("nome/{nomeParam}")]
        public IActionResult GetByNome(string nomeParam) // nome do parametro deve ser o mesmo do {}
        {
            var retorno = adocaoService.PesquisarPorNome(nomeParam);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AdocaoCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = adocaoService.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno.Mensagem);
                }                  
                else { 
                    return Ok(retorno);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdocaoUpdateRequest putModel)
        {
            //Validação modelo de entrada
            if (ModelState.IsValid)
            {
                var retorno = adocaoService.Editar(id, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Validação modelo de entrada
            var retorno = adocaoService.Deletar(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok();

        }

    }
}
