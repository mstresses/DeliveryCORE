using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ProdutoService : AbstractValidator<ProdutoDTO>, IProdutoService
    {
        public async Task Insert(ProdutoDTO produto)
        {
            ProdutoRepository repository = new ProdutoRepository();
            

            RuleFor(r => r.Nome).NotNull().WithMessage("O nome deve ser informado.");
            RuleFor(r => r.Nome).MaximumLength(60).WithMessage("O nome deve ter no máximo 30 caracteres.");

            RuleFor(r => r.Restaurante).NotNull().WithMessage("O restaurante deve ser informado.");
           

            RuleFor(r => r.Valor).NotNull().WithMessage("O Valor deve ser informado.");


            try
            {
                await repository.Insert(produto);
            }
            catch (Exception ex)
            {
                
                //Log.Write("erro 666 " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }
        }
       

        public Task<List<ProdutoDTO>> GetProdutos()
        {
            throw new NotImplementedException();
        }
    }
}
