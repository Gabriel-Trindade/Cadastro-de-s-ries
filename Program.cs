using System;
using DIO.Series.Classes;

namespace DIO.Series;

class Program{

    static SerieRepositório repositorio = new SerieRepositório();


    static void Main(string[] args){
        string opcaoUsuario = ObterOpcaoUsuario();

        while(opcaoUsuario.ToUpper() != "X"){
            switch(opcaoUsuario){
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
                
                default:
                throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
    }

    private static void ListarSeries()
    {
        Console.WriteLine("Listar Séries");
        var lista = repositorio.Lista();

        if (lista.Count == 0){
            Console.WriteLine("Nenhuma lista cadastrada");
            return;
        }

        foreach(var serie in lista){

            var excluido = serie.retornaExcluido();
            
            Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} - {(excluido ? "*Excluido*" : "")} ");
        }
    }

    private static void InserirSerie(){
        
        Console.WriteLine("Inserir nova série");

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
        }
        
        Console.Write("Digite o gênero dentre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série:  ");
        string entradaDescricao  = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorio.proximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao);

        repositorio.insere(novaSerie);
    }

    public static void AtualizarSerie(){

        Console.Write("Digite o ID da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach(int i in Enum.GetValues(typeof(Genero))){
            Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
        }
        
        Console.Write("Digite o gênero dentre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série:  ");
        string entradaDescricao  = Console.ReadLine();

        Serie atualizaSerie = new Serie(id: indiceSerie,
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao);

        repositorio.atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie(){
        Console.Write("Digite o ID da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.exclui(indiceSerie);
    }

    private static void VisualizarSerie(){
        Console.Write("Digite o ID da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.retornaporId(indiceSerie);

        Console.WriteLine(serie); 
    }

       

        private static string ObterOpcaoUsuario(){

        Console.WriteLine();
        Console.WriteLine("DIO séries ao seu dispor!");
        Console.WriteLine("Informe a Opção desejada:");

        Console.WriteLine("1- Listar série");
        Console.WriteLine("2- Inserir nova série");
        Console.WriteLine("3- Atualizar série");
        Console.WriteLine("4- Excluir série");
        Console.WriteLine("5- Visualizar série");
        Console.WriteLine("C- Limpar tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;

    }

}

