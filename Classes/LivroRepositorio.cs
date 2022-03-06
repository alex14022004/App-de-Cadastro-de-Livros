using System;
using Projeto.CadastroLivros.Interfaces;
using System.Collections.Generic;

namespace Projeto.CadastroLivros
{
    public class LivroRepositorio : Repositorio<Livro>
    {   
        private List<Livro>  listaLivro = new List<Livro>();
    
        public void Atualiza(int id, Livro objeto)
		{
			listaLivro[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaLivro[id].Excluir();
		}

		public void Insere(Livro objeto)
		{
			listaLivro.Add(objeto);
		}

		public List<Livro> Lista()
		{
			return listaLivro;
		}

		public int ProximoId()
		{
			return listaLivro.Count;
		}

		public Livro RetornaPorId(int id)
		{
			return listaLivro[id];
		}
    }
}