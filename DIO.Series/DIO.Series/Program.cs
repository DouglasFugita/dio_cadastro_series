using DIO.Series.Classes;
using DIO.Series.Enums;
using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeries()
        {
            Console.Clear();
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                QualquerTeclar();
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.RetornaId()}:  {serie.RetornaTitulo()} {(serie.Excluido?" (Excluido)":"")}");
            }

            QualquerTeclar();
        }

        private static void InserirSerie()
        {
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Inserie nova serie");
            Console.WriteLine("===============");

            var novaSerie = ObterSerie();
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Atualizar serie");
            Console.WriteLine("===============");

            Console.Write("Digite o ID: ");
            Guid id = Guid.Parse(Console.ReadLine());

            var novaSerie = ObterSerie();
            novaSerie.Id = id;

            repositorio.Atualiza(id, novaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Excluir serie");
            Console.WriteLine("===============");

            Console.Write("Digite o ID: ");
            Guid id = Guid.Parse(Console.ReadLine());

            repositorio.Exclui(id);
        }

        private static void VisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Visualizar serie");
            Console.WriteLine("===============");

            Console.Write("Digite o ID: ");
            Guid id = Guid.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(id);

            Console.WriteLine(serie.ToString());
            
            QualquerTeclar();
        }

        private static Serie ObterSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o genero: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite no ano de inicio: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao: ");
            string descricao = Console.ReadLine();

            return new Serie((Genero)genero, titulo, descricao, ano);
        }

        private static void QualquerTeclar()
        {
            Console.WriteLine("");
            Console.WriteLine("===> Pressione qualquer para voltar");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("DIO Serie");
            Console.WriteLine("===============");
            Console.WriteLine("Informe a opcao desejada:");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario=Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return  opcaoUsuario;
        }
    }
}
