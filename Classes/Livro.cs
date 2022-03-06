using System;

namespace Projeto.CadastroLivros
{
    public class Livro : ClasseBase
    {
        private string Titulo { get; set; }
        private Genero Genero { get; set; }
        private int AnoPublicacao { get; set; }
        private string Editora { get; set; }
        private string Autor { get; set; }
        private Boolean Deletado { get; set; }
    

        public Livro(int id, string titulo, Genero genero, int ano, string editora, string autor)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Genero = genero;
            this.AnoPublicacao = ano;
            this.Editora = editora;
            this.Autor = autor;
            this.Deletado = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Ano da Publicação: " + this.AnoPublicacao + Environment.NewLine;
            retorno += "Editora: " + this.Editora +  Environment.NewLine;
            retorno += "Autor(a): " + this.Autor + Environment.NewLine;
            retorno += "Deletado: " + this.Deletado;
            return retorno;
        }

        public string retornaTitulo(){
            return this.Titulo;
        }

        public string retornaAutor(){
            return this.Autor;
        }

        public bool retornaDeletado(){
            return this.Deletado;
        }
        public int retornaId(){
            return this.Id;
        }

        public void Excluir(){
            this.Deletado = true;
        }
    }
}