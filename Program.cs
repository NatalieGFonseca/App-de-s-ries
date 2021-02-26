using System;
using App.Series.classes;

namespace App.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = MenuDeOpcoes();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        //AtualizarSerie();
                        break;

                    case "4":
                        //ExcluirSerie();
                        break;

                    case "5":
                        //VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = MenuDeOpcoes();
            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listagem");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nada cadastrado");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());

            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserindo série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções: ");
            int entGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título: ");
            string entTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano: ");
            int entAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição: ");
            string entDescricao = Console.ReadLine();

            Serie nova = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entGenero,
                                    titulo: entTitulo,
                                    ano: entAno,
                                    descricao: entDescricao);

            repositorio.Insere(nova);

        }

        private static string MenuDeOpcoes()
        {
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine("Informe a opção: ");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Exlcuir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
