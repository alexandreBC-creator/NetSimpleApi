using System;

namespace Loja.API.Models {
    public class Produto {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        private double _valor;
        public double Valor { 
            get{ return this._valor; }
            set { this._valor = (value < 0 ? 0 : value);} 
        }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Produto() {
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }
        public Produto(string nome, int estoque, double valor){
            this.Id = null;
            this.Nome = nome;
            this.Estoque = estoque;
            this.Valor = valor;
            this.DataCadastro = DateTime.Now;
            this.DataAtualizacao = DateTime.Now;
        }
        public void AtualizarProduto(string nome, int estoque, double valor){
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            DataAtualizacao = DateTime.Now;
        }
    }
}