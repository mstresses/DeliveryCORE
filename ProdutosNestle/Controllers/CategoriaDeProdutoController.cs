using BLL.Models.CategoriaDeProdutos;
using BLL.Services.CategoriaDeProdutoService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutosNestle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaDeProdutoController : ControllerBase
    {
        private readonly ICategoriaDeProdutoService _categoriaDeProdutoService;

        public CategoriaDeProdutoController(ICategoriaDeProdutoService categoriaDeProdutoService)
        {
            _categoriaDeProdutoService = categoriaDeProdutoService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaDeProdutoResponseModel>> GetAll()
        {
            return await _categoriaDeProdutoService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CategoriaDeProdutoResponseModel> GetById([FromRoute] int id)
        {
            return await _categoriaDeProdutoService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDeProdutoResponseModel>> Create([FromBody] CategoriaDeProdutoRequestModel categoriaRequestModel)
        {
            var novaCategoria = await _categoriaDeProdutoService.Create(categoriaRequestModel);

            return CreatedAtAction(nameof(GetById), new { id = novaCategoria.Id }, novaCategoria);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<CategoriaDeProdutoResponseModel>> Update([FromRoute] int id, [FromBody] CategoriaDeProdutoRequestModel categoriaRequestModel)
        {
            var categoriaASerAtualizada = await _categoriaDeProdutoService.Update(id, categoriaRequestModel);

            return CreatedAtAction(nameof(GetById), new { id = categoriaASerAtualizada.Id }, categoriaASerAtualizada);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _categoriaDeProdutoService.Delete(id);

            return Ok("Categoria de produto deletada com sucesso.");
        }
    }
}