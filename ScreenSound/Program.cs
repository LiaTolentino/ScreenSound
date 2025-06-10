// Screen Sound

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Florence and the Machine", new List<int> { 9, 8, 6 });
bandasRegistradas.Add("U2", new List<int> { 9, 7, 6 });
bandasRegistradas.Add("Linkin Park", new List<int>());

ExibirOpcoesdoMenu();

void ExibirOpcoesdoMenu()
{
    int opcaoEscolhidaNumerica;
    do
    {
        Console.Clear();

        ExibirLogo();

        ExibirTituloDaOpcao("Menu Principal");

        var opcoes = MenuDeOpcoes();

        opcoes.ToList().ForEach(opcao => Console.WriteLine($"Opção {opcao.Key} - {opcao.Value}" + (opcao.Equals(opcoes.Last()) ? "\n" : "")));

        Console.Write("\nDigite o número da opção desejada: ");
        string opcaoEscolhida = Console.ReadLine()!;

        if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica) &&
        ValidarOpcoesDoMenu<int, string>(opcaoEscolhidaNumerica, MenuDeOpcoes()))
        {
            SelecionarMenu(opcaoEscolhidaNumerica);
            break;
        }
        else
        {
            Console.WriteLine("\nVocê digitou uma opção inválida! Tente novamente.");
            Thread.Sleep(3000);
        }

    }
    while (MenuDeOpcoes().ContainsKey(opcaoEscolhidaNumerica));

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

void SelecionarMenu(int opcaoEscolhida)
{
    switch (opcaoEscolhida)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarBandas();
            break;
        case 4:
            MediaDasBandasAvaliadas();
            break;
        case 0:
            Console.WriteLine("\nBye bye :)\n\nObrigada por utilizar o Screen Sound!");
            break;
        default:
            Console.WriteLine("\nVocê digitou uma opção inválida!");
            break;
    }
}

void RegistrarBanda()
{
    do
    {
        Console.Clear();

        ExibirTituloDaOpcao("Registro de Bandas");
        Console.Write("Informe o nome da banda que deseja registrar: ");

        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");

        Console.WriteLine($"\nDeseja adicionar mais uma banda: \n");

        var opcoes = MenuDeConfirmação();

        opcoes.ToList().ForEach(opcao => Console.WriteLine($"Opção {opcao.Key} - {opcao.Value}" + (opcao.Equals(opcoes.Last()) ? "\n" : "")));

        string opcaoEscolhida = Console.ReadLine()!;

        if (int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica) &&
            ValidarOpcoesDoMenu<int, string>(opcaoEscolhidaNumerica, MenuDeConfirmação()))
        {

            if (opcoes.TryGetValue(opcaoEscolhidaNumerica, out string? value) && "Sim".Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                continue;
            }
            else
            {
                Thread.Sleep(3000);
                Console.Clear();
                ExibirOpcoesdoMenu();
            }

        }
        else
        {
            Console.WriteLine("\nVocê digitou uma opção inválida! Tente novamente.");
            Thread.Sleep(3000);
        }
    }
    while (true);
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibição das Bandas Registradas");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    ProcessarRetornoAoMenu();
}

void AvaliarBandas()
{
    do
    {
        Console.Clear();

        ExibirTituloDaOpcao("Avalie Uma Banda");
        Console.Write("Informe o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"\nQual a nota que deseja dar para a banda {nomeDaBanda}? ");
            int notaRecebida = int.Parse(Console.ReadLine()!);

            bandasRegistradas[nomeDaBanda].Add(notaRecebida);
            Console.WriteLine($"\nA nota {notaRecebida} foi registrada com sucesso " +
                $"para a banda {nomeDaBanda}");

            Console.WriteLine($"\nDeseja avaliar mais uma banda: \n");

            var opcoes = MenuDeConfirmação();

            opcoes.ToList().ForEach(opcao => Console.WriteLine($"Opção {opcao.Key} - {opcao.Value}" + (opcao.Equals(opcoes.Last()) ? "\n" : "")));

            string opcaoEscolhida = Console.ReadLine()!;

            if (int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica) &&
                ValidarOpcoesDoMenu<int, string>(opcaoEscolhidaNumerica, MenuDeConfirmação()))
            {

                if (opcoes.TryGetValue(opcaoEscolhidaNumerica, out string? value) && "Sim".Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirOpcoesdoMenu();
                }

            }
            else
            {
                Console.WriteLine("\nVocê digitou uma opção inválida! Tente novamente.");
                Thread.Sleep(000);
            }
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada\n");

            ProcessarRetornoAoMenu();
        }


    }
    while (true);
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

        ProcessarRetornoAoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada\n");

        ProcessarRetornoAoMenu();
    }
}

void ExibirTituloDaOpcao(string titulo)
{
    string asteriscos = string.Empty.PadLeft(titulo.Length, '*');

    Console.WriteLine($"{asteriscos}\n{titulo}\n{asteriscos}\n");
}

void ProcessarRetornoAoMenu()
{
    Console.WriteLine("\nPressione qualquer tecla para voltar para o menu principal");

    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesdoMenu();
}

bool ValidarOpcoesDoMenu<TKey, TValue>(TKey numero, Dictionary<TKey, TValue> dicionario)
    where TKey : notnull
{
    ArgumentNullException.ThrowIfNull(dicionario); // Garante que o dicionário não seja nulo

    return dicionario.ContainsKey(numero); // Retorna diretamente a validação
}

Dictionary<int, string> MenuDeOpcoes()
{
    return new Dictionary<int, string>
    {
        {1, "Registrar uma banda"},
        {2, "Exibir todas as bandas"},
        {3, "Avaliar uma banda"},
        {4, "Exibir a média de avaliação de todas as bandas"},
        {0, "Encerrar a exibição"},

    };
}

Dictionary<int, string> MenuDeConfirmação()
{
    return new Dictionary<int, string>
    {
        {1, "Sim"},
        {2, "Não"},
    };
}

