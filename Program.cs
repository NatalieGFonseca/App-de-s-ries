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
                            Listar();
                            break;

                        case "2":
                            Inserir();
                            break;

                        case "3":
                            Atualizar();
                            break;

                        case "4":
                            Excluir();
                            break;

                        case "5":
                            Visualizar();
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

        private static void Listar()
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
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }


        private static void Inserir()
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

    

        private static void Atualizar()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

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

            Serie atualiza = new Serie(id: indiceSerie,
                                    genero: (Genero)entGenero,
                                    titulo: entTitulo,
                                    ano: entAno,
                                    descricao: entDescricao);

            repositorio.Atualiza(indiceSerie, atualiza);

        }

        private static void Excluir()
        {
            Console.Write("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());

            repositorio.Exclui(indice);
        }

        private static void Visualizar()
        {
            Console.Write("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indice);

            Console.WriteLine(serie);
        }

        private static string MenuDeOpcoes()
        {
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine("Informe a opção: ");
            Console.WriteLine("1- Listar");
            Console.WriteLine("2- Inserir");
            Console.WriteLine("3- Atualizar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Visualizar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }

    }
}
