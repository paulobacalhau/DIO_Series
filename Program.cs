using System;
using series;
using series.Enum;

namespace Series
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            // EntidadeBase minhaclasse = new EntidadeBase()
            string opcaoUsuario = ObterOpcaoUsuario();
            while ( opcaoUsuario != "X")
            {
                switch ( opcaoUsuario)
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
                    case "L":
                         Console.Clear();
                         break;
                    case "X":
                         break;
                    default:
                         throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static void ListarSeries(){
            Console.WriteLine ("Lista as séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine ("#ID {0}: - {1} : {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluido*" : "") );
            }
        }
        private static void InserirSerie(){
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine ("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Informe o gênero dentre as opções acima:");
            int entradaGenero = int.Parse (Console.ReadLine());

            Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série:");
            int entradaAno = int.Parse (Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (Id : repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao );
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie(){
            Console.WriteLine ("Digite o id da série:");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine ("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Informe o gênero dentre as opções acima:");
            int entradaGenero = int.Parse (Console.ReadLine());

            Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série:");
            int entradaAno = int.Parse (Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie (Id : idSerie,
                                             genero: (Genero)entradaGenero,
                                             titulo: entradaTitulo,
                                             ano: entradaAno,
                                             descricao: entradaDescricao);
            
            repositorio.Atualiza(atualizaSerie, idSerie);
        }
        private static void ExcluirSerie(){
            Console.WriteLine ("Digite o id da série:");
            int idSerie = int.Parse(Console.ReadLine());
 
            repositorio.Exclui(idSerie);

        }
       private static void VisualizarSerie(){
            Console.WriteLine ("Digite o id da série:");
            int idSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorID(idSerie);
            Console.WriteLine (serie);
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine ("");
            Console.WriteLine ("Bacalhau : Séries ao seu dispor");
            Console.WriteLine ("Informe a opção desejada");
            Console.WriteLine ("");
            Console.WriteLine ("1 - Listar séries cadastradas");
            Console.WriteLine ("2 - Inserir uma nova série");
            Console.WriteLine ("3 - Atualizar dados de série");
            Console.WriteLine ("4 - Excluir uma série");
            Console.WriteLine ("5 - Visualizar dados da série");
            Console.WriteLine ("L - Limpar tela");
            Console.WriteLine ("X - Sair");
            Console.Write ("");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }

}
