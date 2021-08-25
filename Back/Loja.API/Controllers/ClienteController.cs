using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class CLienteController : ControllerBase{
        public static List<CLiente> clientes = new List<CLiente>();
        public CLienteController(){
            if(clientes.Count <= 0){
                CLiente cliente = new CLiente(){
                Id = 1,
                Nome = "Marquinhos",
                Liberado = true,
                Credito = 400.00
                };
                clientes.Add(cliente);
                CLiente cliente = new CLiente(){
                Id = 2,
                Nome = "Mirosvaldo",
                Liberado = true,
                Credito = 810.00
                };
                clientes.Add(cliente);
                CLiente cliente = new CLiente(){
                Id = 3,
                Nome = "Maria Bonita",
                Liberado = true,
                Credito = 170.00
                };
                clientes.Add(cliente);
            }
        }
        [HttpGet]
        public IActionResult Get(){
            // Produto produto = new Produto(){
            //     Nome = "Tênis",
            //     Estoque = 10,
            //     Valor = 159.99
            //};
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            var clienteSelecionado = clientes.Where(
                cli => cli.Id == id);
            return Ok(clienteSelecionado);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CLiente novoCliente){
            clientes.Add(novoCliente);
            return Created("", novoCliente);
        }

        [HttpPut("{id}")]
        public string Put(int id){
            return "Olá Put!"+id;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            // Selecionar o produto que deverá ser removido
            CLiente clienteSelecionado = clientes.FirstOrDefault(p => p.Id == id);
            if (clienteSelecionado != null){
                // Remove o produto da lista
                produtos.Remove(clienteSelecionado);
                // Retorna um resultado para o cliente
                return NoContent();
            }
            return NotFound();
        }
    }
}