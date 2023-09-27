// Screen Sound

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Florence and the Machine", new List<int> {9, 8, 6 } );
bandasRegistradas.Add("U2", new List<int> { 9, 7, 6 });
bandasRegistradas.Add("Linkin Park", new List<int>());

ExibirOpcoesdoMenu();

void ExibirOpcoesdoMenu()
{
    ExibirLogo();

    ExibirTituloDaOpcao("Menu Principal");

    Console.WriteLine("Opção 1 - Registrar uma banda");
    Console.WriteLine("Opção 2 - Exibir todas as bandas");
    Console.WriteLine("Opção 3 - Avaliar uma banda");
    Console.WriteLine("Opção 4 - Exibir a média de avaliação de todas as bandas");
    Console.WriteLine("Opção 0 - Encerrar a exibição");

    Console.Write("\nDigite o número da opção desejada: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica) 
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarBandas();
            break;
        case 4: MediaDasBandasAvaliadas();
            break;
        case 0: Console.WriteLine("\nBye bye :)\n\nObrigada por utilizar o Screen Sound!");
            break;
        default: Console.WriteLine("\nVocê digitou uma opção inválida!");
            break;
    }
}

void ExibirLogo()
{
    string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound\n";

    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Informe o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");

    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesdoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibição das Bandas Registradas");
    
    foreach (string banda in bandasRegistradas.Keys)
    {  
        Console.WriteLine($"Banda: {banda}"); 
    }

    Console.WriteLine("\nPressione qualquer tecla para retornar ao Menu Principal");
    Console.ReadKey();
    Console.Clear();

    ExibirOpcoesdoMenu();
}

void AvaliarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avalie Uma Banda");
    Console.Write("Informe o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que deseja dar para a banda {nomeDaBanda}? ");
        int notaRecebida = int.Parse(Console.ReadLine()!);

        bandasRegistradas[nomeDaBanda].Add(notaRecebida);
        Console.WriteLine($"\nA nota {notaRecebida} foi registrada com sucesso " +
            $"para a banda {nomeDaBanda}");

        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesdoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada\n");
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdoMenu();
    }
}

void MediaDasBandasAvaliadas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média de Avaliações de Uma Banda");

    Console.Write("Informe o nome da banda que deseja conhecer a média: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda)) 
    {
        double mediaDeAvaliacoes = bandasRegistradas[nomeDaBanda].Average();
        Console.WriteLine($"\nA nota média de avaliações da banda {nomeDaBanda} é {mediaDeAvaliacoes}\n");
        Console.WriteLine("Pressione qualquer tecla para voltar para o menu principal");

        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada\n");
        Console.WriteLine("Pressione qualquer tecla para voltar para o menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdoMenu();
    }
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeCaracteres = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeCaracteres, '*');

    Console.WriteLine($"{asteriscos}\n{titulo}\n{asteriscos}\n");

}

