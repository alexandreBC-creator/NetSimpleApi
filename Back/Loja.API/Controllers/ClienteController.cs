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
                Cliente cliente = new Cliente(){
                Id = 1,
                Nome = "Marquinhos",
                Liberado = true,
                Credito = 400.00
                };
                clientes.Add(cliente);
                cliente = new Cliente(){
                Id = 2,
                Nome = "Mirosvaldo",
                Liberado = false,
                Credito = 810.00
                };
                clientes.Add(cliente);
                cliente = new Cliente(){
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
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id){
            var clienteSelecionado = clientes.Where(
                cli => cli.Id == id);
            return Ok(clienteSelecionado);
        }

          [HttpGet("/credito{credito}")]
        public IActionResult GetMaiorOuIgual(double credito) {
            var clientesSelecionados = clientes.Where(
                cli => cli.Credito >= credito);
            return Ok(clientesSelecionados);
        }

        [HttpGet("/liberados")]
        public IActionResult GetLiberados() {
            var clienteSelecionado = clientes.Where(
                cli => cli.Liberado == true);
            return Ok(clienteSelecionado);
        }
        
        [HttpGet("/bloqueados")]
        public IActionResult GetBloqueados() {
            var clienteSelecionado = clientes.Where(
                cli => cli.Liberado == false);
            return Ok(clienteSelecionado);
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
            Cliente clienteSelecionado = clientes.FirstOrDefault(p => p.Id == id);
            if (clienteSelecionado != null){
                clientes.Remove(clienteSelecionado);
                return NoContent();
            }
            return NotFound();
        }
    }
}