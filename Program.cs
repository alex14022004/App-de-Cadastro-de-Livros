using System;
using Projeto.CadastroLivros;

namespace Projeto.Livros
{
    class Program
    {

        static LivroRepositorio repositorio = new LivroRepositorio();
        static void Main (string[] args)
        {
            string opcao = InteracaoUsuario();

            while (opcao != "X")
            {
                switch (opcao){
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;   
                    case "3":
                         Editar();
                        break;
                    case "4":
                        Deletar();
                        break;
                    case "5":
                        Visualizar();
                        break;

                default:
                    throw new ArgumentOutOfRangeException();
                }
            opcao = InteracaoUsuario();
            }
           
        }

        private static void Listar(){
            var lista  = repositorio.Lista();
            Console.Clear();

            if (lista.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há nenhum livro cadastrado. Que tal adicionar alguns?");
                return;
            }

            foreach(var livro in lista)
            {   
                var deleted = livro.retornaDeletado();
                if (!deleted){
                    Console.WriteLine("#ID {0}: - {1} - {2}", livro.retornaId(), livro.retornaTitulo(), livro.retornaAutor());
                }
            }

        }

        private static void Inserir()
        {
            
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" ~~~Inserir livro~~~");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            
            Console.WriteLine("");
			Console.Write("De qual desses gêneros é o livro? ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Qual o Título do Livro: ");
			string titulo = Console.ReadLine();

			Console.Write("E o Ano de publicação: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do autor(a): ");
			string autor = Console.ReadLine();

            Console.Write("Agora o nome da editora: ");
			string editora = Console.ReadLine();

			Livro novoLivro = new Livro(id: repositorio.ProximoId(),
										genero: (Genero)genero,
										titulo: titulo,
										ano: ano, 
										autor: autor,
                                        editora: editora);

			repositorio.Insere(novoLivro);
		}

         private static void Editar()
		{
			Console.Write("Digite o ID do livro: ");
			int indice = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            
            Console.WriteLine("");
			Console.Write("De qual desses gêneros é o livro? ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Qual o Título do Livro: ");
			string titulo = Console.ReadLine();

			Console.Write("E o Ano de publicação: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do autor(a): ");
			string autor = Console.ReadLine();

            Console.Write("Agora o nome da editora: ");
			string editora = Console.ReadLine();

			Livro atualizaLivro = new Livro(id: repositorio.ProximoId(),
										genero: (Genero)genero,
										titulo: titulo,
										ano: ano, 
										autor: autor,
                                        editora: editora);

			repositorio.Atualiza(indice, atualizaLivro);
		}

        private static void Deletar()
        {
           	Console.Write("Digite o ID do livro: ");
			int indice = int.Parse(Console.ReadLine());

            repositorio.Exclui(indice);
        }

        private static void Visualizar()
		{
			Console.Write("Digite o id do livro: ");
			int indice = int.Parse(Console.ReadLine());

			var livro = repositorio.RetornaPorId(indice);

			Console.WriteLine(livro);
		}

        public static string InteracaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Bem vindo à Biblioteca Virtual!");
            Console.WriteLine("Qual opção você deseja nesse momento?");
            Console.WriteLine("....................................."); 
            Console.WriteLine("1 - Ver lista de livros");
            Console.WriteLine("2 - Inserir livro");
            Console.WriteLine("3 - Editar livro");
            Console.WriteLine("4 - Excluir livro");
            Console.WriteLine("5 - Visualizar livro");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();
            return opcao;
            
        }
    }
}