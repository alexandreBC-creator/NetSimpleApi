using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase{
        public static List<Produto> produtos = new List<Produto>();
        public ProdutoController(){
            if(produtos.Count <= 0){
                Produto produto = new Produto(){
                Id = 1,
                Nome = "Tênis",
                Estoque = 10,
                Valor = 159.99
                };
                produtos.Add(produto);
                produto = new Produto(){
                Id = 2,
                Nome = "Camiseta",
                Estoque = 5,
                Valor = 59.99
                };
                produtos.Add(produto);
                produto = new Produto(){
                Id = 3,
                Nome = "Boné",
                Estoque = 7,
                Valor = 39.99
                };
                produtos.Add(produto);
            }
        }
        [HttpGet]
        public IActionResult Get(){
            // Produto produto = new Produto(){
            //     Nome = "Tênis",
            //     Estoque = 10,
            //     Valor = 159.99
            //};
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            var produtoSelecionado = produtos.Where(
                prod => prod.Id == id);
            return Ok(produtoSelecionado);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto){
            produtos.Add(novoProduto);
            return Created("", novoProduto);
        }

        [HttpPut("{id}")]
        public string Put(int id){
            return "Olá Put!"+id;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            // Selecionar o produto que deverá ser removido
            Produto produtoSelecionado = produtos.FirstOrDefault(p => p.Id == id);
            if (produtoSelecionado != null){
                // Remove o produto da lista
                produtos.Remove(produtoSelecionado);
                // Retorna um resultado para o cliente
                return NoContent();
            }
            return NotFound();
        }
    }
}