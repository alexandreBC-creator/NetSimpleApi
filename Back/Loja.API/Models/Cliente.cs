using System;

namespace Loja.API.Models {
    public class Cliente {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public bool Liberado { get; set; }
        private double _credito;
        public double Credito { 
            get{ return this._credito; }
            set { this._credito = (value < 0 ? 0 : value);} 
        }
        public DateTime DataCadastro { get; set; }
        public DateTime DataNascimento { get; set; }

        public Cliente() {
            DataCadastro = DateTime.Now;
        }
        public Cliente(string nome, double credito){
            this.Id = null;
            this.Nome = nome;
            this.Liberado = true;
            this.Credito = credito;
            this.DataCadastro = DateTime.Now;
        }
        public Cliente(string nome, bool liberado, double credito, DateTime dataNascimento){
            this.Id = null;
            this.Nome = nome;
            this.Liberado = liberado;
            this.Credito = credito;
            this.DataCadastro = DateTime.Now;
            this.DataNascimento = dataNascimento;
        }
        public void Liberar(){
            this.Liberado = true;
        }
        public void Bloquear(){
            this.Liberado = false;
        }
        public void AtualizarCliente(string nome, bool liberado, double credito, DateTime dataNascimento){
            Nome = nome;
            Liberado = liberado;
            Credito = credito;
            DataNascimento = dataNascimento;
        }
    }
}