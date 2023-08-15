// Screen Sound
string mensagemBoasVindas = "Boas vinda ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso"};// cria uma lista com valores

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add( "Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("Beatles", new List<int> ());


void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    
    Console.WriteLine(mensagemBoasVindas);
    
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();

    Console.WriteLine("\nDigite  1 para registrar uma banda");
    Console.WriteLine("Digite  2 para mostrar todas as bandas");
    Console.WriteLine("Digite  3 para avaliar uma banda");
    Console.WriteLine("Digite  4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");

    string  opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMediaBanda();
            break;
        case -1:Console.WriteLine("Tchau tchauuuu");
            break;
        default: Console.WriteLine("Opção Inválida");
            break;

    }
}

void RegistrarBanda()
{
    Console.Clear();//Limpa a tela

    ExibirTituloDaOpcao("| Registro das bandas |");

    Console.Write(" Digite o nome da banda que deseja registrar ");

    string nomeDaBanda = Console.ReadLine()!;   

    //listaDasBandas.Add();// adiciona  abanda a listaDasbandas
    bandasRegistradas.Add(nomeDaBanda, new List<int>());

    Console.WriteLine($"A banda {nomeDaBanda} foi registrada ");

    Thread.Sleep(2000);//Dá alguns mili segundos antes de encerrar

    Console.Clear();
    ExibirOpcoesDoMenu();
    
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("| Exibindo todas as banda registradas na nossa aplicação |");
    //for(int i = 0;i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda} ");
    }
    Console.WriteLine("\nDigite uma tecla pra voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*'); //adiciona os asteriscos para o tamanho do titulo, com o caracter desejado, no caso o *
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    //se a banda existir, no dicionario >> atribuir uma nota
    //se não volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.WriteLine("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada !");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal ");
        Console.ReadKey(true);
        Console.Clear();
        ExibirOpcoesDoMenu();
        
    }
}

void ExibirMediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliação das Bandas");
    Console.WriteLine("Digite o nome da banda que deseja ver a média de notas: ");
    string nomeDaBanda = Console.ReadLine()!;
    
    if(bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        double mediaNotas = bandasRegistradas[nomeDaBanda].Average();
        Console.WriteLine($"A média da banda {nomeDaBanda} é " + mediaNotas);
        Thread.Sleep(5000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    }else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal !");
        Console.ReadKey(true);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

ExibirOpcoesDoMenu();