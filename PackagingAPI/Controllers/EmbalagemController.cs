using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PackagingAPI.Models;
using PackagingAPI.Services;

namespace PackagingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmbalagemController : ControllerBase
    {
        private readonly EmbalagemService _embalagemService;

        public EmbalagemController(EmbalagemService embalagemService)
        {
            _embalagemService = embalagemService;
        }

        [HttpPost("embalar")]
        [ProducesResponseType(typeof(List<Caixa>), 200)]  
        [ProducesResponseType(400)] 
        [ProducesResponseType(404)] 
        public IActionResult EmbalarPedido([FromBody] List<Produto> produtos)
        {
            
            if (produtos == null || produtos.Count == 0)
            {
                return BadRequest("A lista de produtos não pode ser vazia.");
            }

            
            var caixas = _embalagemService.EmbalagemPedido(produtos);

            
            if (caixas == null || caixas.Count == 0)
            {
                return NotFound("Nenhuma caixa foi encontrada para embalar os produtos.");
            }

            return Ok(caixas);  
        }
    }
}
