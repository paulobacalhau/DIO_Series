using System;
using series.Enum;
namespace series
{
    public class Serie : EntidadeBase
    {
       // Atributos
       // O tipo genero será um enum.
       private Genero Genero {get;set;}  
       private string Titulo {get;set;}
       private string Descricao {get;set;}
       private int Ano {get;set;}
       private bool Excluido {get;set;}

       // Métodos
       public Serie(int Id, Genero genero, string titulo, string descricao, int ano)
       {
           this.Id = Id;
           this.Genero = genero;
           this.Titulo = titulo;
           this.Descricao = descricao;
           this.Ano = ano;
           this.Excluido = false;
       }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine; // Environment.NewLine acrescenta uma quebra de linha
            retorno += "Título: " + this.Titulo + Environment.NewLine; // Environment.NewLine acrescenta uma quebra de linha
            retorno += "Descrição: " + this.Descricao + Environment.NewLine; // Environment.NewLine acrescenta uma quebra de linha
            retorno += "Ano de inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string RetornaTitulo(){
            return this.Titulo;
        }

        public int RetornaId(){
            return this.Id;
        }
        public void Excluir(){
            this.Excluido = true;
        }

        public bool RetornaExcluido(){
            return this.Excluido;
        }
    }
}