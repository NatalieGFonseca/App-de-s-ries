using System;

namespace App.Series
{
    public class Filme : EntidadeBase
    {
            public Filme(Genero genero, string titulo, string descricao, int ano, string diretor, bool excluido) 
            {
                this.genero = genero;
                this.Titulo = titulo;
                this.Descricao = descricao;
                this.ano = ano;
                this.Diretor = diretor;
                this.Excluido = excluido;
            
            }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Diretor: " + this.Diretor + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        
        private Genero genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int ano { get; set; }
        private string Diretor { get; set; }
        private bool Excluido { get; set; }
    }
}