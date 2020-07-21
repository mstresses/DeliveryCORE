using BLL.Models.Fornecedores;
using BLL.Services.FornecedorService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutosNestle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorResponseModel>> GetAll()
        {
            return await _fornecedorService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<FornecedorResponseModel> GetById([FromRoute] int id)
        {
            return await _fornecedorService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorResponseModel>> Create([FromBody] FornecedorRequestModel fornecedorRequestModel)
        {
            var novoFornecedor = await _fornecedorService.Create(fornecedorRequestModel);

            return CreatedAtAction(nameof(GetById), new { id = novoFornecedor.Id }, novoFornecedor);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<FornecedorResponseModel>> Update([FromRoute] int id, [FromBody] FornecedorRequestModel fornecedorRequestModel)
        {
            var fornecedorASerAtualizado = await _fornecedorService.Update(id, fornecedorRequestModel);

            return CreatedAtAction(nameof(GetById), new { id = fornecedorASerAtualizado.Id }, fornecedorASerAtualizado);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _fornecedorService.Delete(id);

            return Ok("Fornecedor deletado com sucesso.");
        }
    }
}