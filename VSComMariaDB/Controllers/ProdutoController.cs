using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public List<Produto> GetLista()
        {
            var _DbContext = new _DbContext();
            var vLista = _DbContext.Produto.ToList();

            return vLista;
        }

        [HttpGet("ListaAsync")]
        public async Task<List<Produto>> GetListaAsync()
        {

            {
                var _DbContext = new _DbContext();
                var vLista = await _DbContext.Produto.ToListAsync();

                return vLista;
            }
        }


        /// <summary>
        /// Pegar os dados de uma pessoa especifica
        /// </summary>
        /// <param name="id">ID da Pessoa</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Produto> GetProduto(int id)
        {
            //Instanciar o banco de dados
            var _DbContext = new _DbContext();

            //Selecionar a Pessoa pelo id
            //  var vPessoa = _DbContext.Pessoa
            //  .Where(p => p.Id == id)
            //  .FirstOrDefault();

            var vProduto = await _DbContext.Produto.FindAsync(id);

            //retornar dos dados
            return vProduto;
        }

        [HttpPost("Inserir")]
        public async Task<List<Produto>> Inserir(List<Produto> produto)
        {
            var _DbContext = new _DbContext();

            await _DbContext.Produto.AddRangeAsync(produto);
            await _DbContext.SaveChangesAsync();
            return produto;
        }

        [HttpPut("Alterar")]
        public async Task<Produto> Alterar(Produto produto)
        {

            var _DbContext = new _DbContext();

            _DbContext.Produto.Entry(produto).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
            return produto;

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var _DbContext = new _DbContext();

            //Localiza a pessoa com ID solicitado em front end
            var vProduto = _DbContext.Produto.Find(id);

            //Remove a pessoa localizada
            _DbContext.Produto.Remove(vProduto);

            await _DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
