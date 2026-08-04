using System;
using System.ComponentModel;
using System.Data;


// Criação de List:
// List<string> listaDasBandas = new List<string>
// {
//     "U2", "Morada", "ONE-Sound"
// };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

bandasRegistradas.Add("Morada", new List<int> {10, 9, 8} );
bandasRegistradas.Add("ONE-Sound", new List<int> {7, 2, 9});

// 1 Referência de chamada
ExibirMsgDeBV();

// 2 Referência de chamada
ExibirOpcaoDoMenu();




void ExibirMsgDeBV()
{
    Console.WriteLine("******************************");
    Console.WriteLine("Boas Vindas ao Screen Sound");
    Console.WriteLine("******************************");
}

Console.WriteLine();

void ExibirOpcaoDoMenu()
{
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;

        case 2:
            MostrarBandasRegistradas();
            break;

        case 3:
            AvaliarUmaBanda();
            break;

        case 4:
            MostrarMediaDaBanda();
            break;

        case -1:
            Console.WriteLine("Até Logo");
            break;

        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
}


void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda desejada registrar aqui: ");
    string nomeBanda = Console.ReadLine()!;
    // Dicionário das bandas com notas:
    bandasRegistradas.Add(nomeBanda, new List<int>());

    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso.");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcaoDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    
    // For normal

    // for (int i = 0; i < listaDasBandas.Count; i++)
    // {
    //     Console.WriteLine($"Banda: {listaDasBandas[i]}");
    // }

    // Foreach

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }


    Console.WriteLine("\n Digite uma tecla pra voltar pro menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcaoDoMenu();
}


void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    // string asterics = string.Empty.PadLeft(quantidadeDeLetras);
    string asterics = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asterics);
    Console.WriteLine(titulo);
    Console.WriteLine(asterics + "\n");
    
    
    
}

// Terceira opção do menu

void AvaliarUmaBanda()
{
    // Difite qual banda deseja avaliar
    // se a banda existir no dicionario > atribuir uma nota
    // senão, volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    { 
        Console.Write($"Qual a nota que a {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcaoDoMenu();
    } else
    {
        Console.WriteLine($"A Banda {nomeDaBanda} não foi encontrado!");
        Console.WriteLine("Digite uma tecla pra voltar ao menu principal");
        Console.ReadKey();
        ExibirOpcaoDoMenu();
    }
}

void MostrarMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir Média da Banda");
    Console.WriteLine("Digite a banda que deseja ver a média: ");
    string bandaEscolhida = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(bandaEscolhida))
    {
        double mediaDaBanda = bandasRegistradas[bandaEscolhida].Average();

        Console.WriteLine($"Média da {bandaEscolhida} é: {mediaDaBanda}");
    }
    else
    {
        Console.WriteLine($"A {bandaEscolhida} não encontrada!");
    }

    Console.WriteLine("Digite uma tecla pra voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcaoDoMenu();
}
