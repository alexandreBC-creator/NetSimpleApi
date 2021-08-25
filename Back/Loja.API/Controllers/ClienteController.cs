using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase{
        public static List<Cliente> clientes = new List<Cliente>();
        public ClienteController(){
            if(clientes.Count <= 0){
                Cliente cliente1 = new Cliente(){
                Id = 1,
                Nome = "Marquinhos",
                Liberado = true,
                Credito = 400.00
                };
                clientes.Add(cliente);
                Cliente cliente2 = new Cliente(){
                Id = 2,
                Nome = "Mirosvaldo",
                Liberado = true,
                Credito = 810.00
                };
                clientes.Add(cliente);
                Cliente cliente3 = new Cliente(){
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
        public IActionResult GetByID(int id){
            var clienteSelecionado = clientes.Where(
                cli => cli.Id == id);
            return Ok(clienteSelecionado);
        }

         [HttpGet("{credito}")]
        public IActionResult GetByCreditoMaiorOuIgual(double credito){
            var clientesSelecionados = clientes.Where(
                cli => cli.Credito >= credito);
            return Ok(clientesSelecionados);
        }

        [HttpGet)]
        public IActionResult GetClientesBloqueados(){
            var clientesSelecionados = clientes.Where(
                cli => cli.Liberado == false);
            return Ok(clientesSelecionados);
        }

        [HttpGet)]
        public IActionResult GetClientesLiberados(){
            var clientesSelecionados = clientes.Where(
                cli => cli.Liberado == true);
            return Ok(clientesSelecionados);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente novoCliente){
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
            Cliente clienteSelecionado = clientes.FirstOrDefault(p => p.Id == id);
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