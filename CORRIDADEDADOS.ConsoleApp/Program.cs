/*
Especificação do Jogo de Corrida de Dados
Objetivo do Jogo: O jogador e o computador competem em uma corrida virtual. Cada um rola um dado virtua
(geração de números aleatórios) para avançar em uma pista. O primeiro a alcançar ou ultrapassar a linha d
chegada vence.

Regras e Funcionalidades:
4. Interação:
○ O jogador rola o dado pressionando uma tecla (ex.: Enter).
○ O computador rola o dado automaticamente no seu turno.

Dificuldades e Conceitos Envolvidos:
● Geração de números aleatórios: Para simular o lançamento do dado.
● Estruturas de repetição: Para controlar os turnos dos competidores.
● Condicionais: Para verificar eventos especiais e a condição de vitória.
● Interação com o usuário: Para permitir que o jogador role o dado.
● Lógica de turnos: Alternar entre o jogador e o computador.

Eventos Especiais:
5. Para tornar o jogo mais interessante, algumas posições na pista podem ter eventos especiais:
○ Avanço extra: Se o competidor parar em uma posição específica (ex.: 5, 10, 15), ele avança +3
casas.
○ Recuo: Se o competidor parar em outra posição específica (ex.: 7, 13, 20), ele recua -2 casas.
○ Rodada extra: Se o competidor tirar 6 no dado, ele ganha uma rodada extra.
*/
int linhaDeChegada = 30;
int posicaoJogador = 0;
int posicaoComputador = 0;
Random dado = new Random();

Console.WriteLine("-------------------------------------------");
Console.WriteLine(" +-------+                    +-------+ ");
Console.WriteLine(" |       |                    | o   o | ");
Console.WriteLine(" |   o   |  CORRIDA DE DADOS  | o   o | ");
Console.WriteLine(" |       |                    | o   o | ");
Console.WriteLine(" +-------+                    +-------+ ");
Console.WriteLine("-------------------------------------------");
Console.WriteLine("Pressione Enter Para Iniciar a Corrida...");
Console.ReadLine();

while (posicaoJogador < linhaDeChegada && posicaoComputador < linhaDeChegada)
{
    Console.WriteLine("\n-------------------------------------------");
    Console.WriteLine($"Possição Inicial: Jogador = {posicaoJogador} / 30");
    Console.WriteLine($"Possição Inicial: Computador = {posicaoComputador} / 30");
    Console.WriteLine("\n-------------------------------------------");
    Console.WriteLine("Turno do Jogador:");
    Console.WriteLine("\n-------------------------------------------");
    Console.WriteLine("Pressione Enter Para Rolar o Dado...");
    Console.ReadLine();

    // Turno do jogador
    int dadoJogador = dado.Next(1, 7);
    posicaoJogador += dadoJogador;
    Console.WriteLine($"Você Rolou {dadoJogador}.");

    if (dadoJogador == 6)
    {
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Acerto CRITICO! Você Ganhou uma Rodada Extra!");
        Console.WriteLine("\n-------------------------------------------");
        Console.ReadLine();
        continue; // O jogador joga novamente
    }

    else if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15)
    {
        posicaoJogador += 3;
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Evento Especial: Avanço Extra! Você Avançou +3 Casas!");
        Console.WriteLine("\n-------------------------------------------");
    }
    else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
    {
        posicaoJogador -= 2;
        if (posicaoJogador < 0) posicaoJogador = 0; // Garantir que a posição não seja negativa
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Evento Especial: Recuo! Você Recuou -2 Casas!");
        Console.WriteLine("\n-------------------------------------------");
    }

    // Verificar se o jogador venceu
    if (posicaoJogador >= linhaDeChegada)
    {
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine(" +-------+                       +-------+ ");
        Console.WriteLine(" |       |       Parabens!       | o   o | ");
        Console.WriteLine(" |   o   |      Você Venceu      | o   o | ");
        Console.WriteLine(" |       |                       | o   o | ");
        Console.WriteLine(" +-------+                       +-------+ ");
        Console.WriteLine("\n-------------------------------------------");

        Console.WriteLine("Gostaria de Jogar Novamente? (s/n)");
        string resposta = Console.ReadLine().ToLower();
        if (resposta == "s")
        {
            Console.Clear();
            posicaoJogador = 0;
            posicaoComputador = 0;
            Console.WriteLine("Reiniciando o jogo...");
        }
        else
        {
            break; // Sair do loop e encerrar o jogo
        }
    }
    Console.WriteLine("Pressione Enter Para Continuar...");
    Console.ReadLine();

    Console.WriteLine("\n-------------------------------------------");
    Console.WriteLine("Turno do Computador:");
    Console.WriteLine("\n-------------------------------------------");

    // Turno do computador
    int dadoComputador;
    do
    {
        dadoComputador = dado.Next(1, 7);
        posicaoComputador += dadoComputador;
        Console.WriteLine($"O Computador Rolou {dadoComputador}.");

        if (dadoComputador == 6)
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Acerto CRITICO! O Computador Ganhou uma Rodada Extra!");
            Console.WriteLine("\n-------------------------------------------");
            Console.ReadLine();
            continue; // O computador joga novamente
        }

        else if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15)
        {
            posicaoComputador += 3;
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Evento Especial: Avanço Extra! O Computador Avançou +3 Casas!");
            Console.WriteLine("\n-------------------------------------------");
            Console.ReadLine();
        }
        else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
        {
            posicaoComputador -= 2;
            if (posicaoComputador < 0) posicaoComputador = 0; // Garantir que a posição não seja negativa
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Evento Especial: Recuo! O Computador Recuou -2 Casas!");
            Console.WriteLine("\n-------------------------------------------");
            Console.ReadLine();
        }
        else if (posicaoComputador >= linhaDeChegada)
        {
            break; // O computador venceu, sair do loop
        }
    } while (dadoComputador == 6); // O computador continua jogando enquanto tirar 6

    // Verificar se o computador venceu
    if (posicaoComputador >= linhaDeChegada)
    {
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine(" +-------+                       +-------+ ");
        Console.WriteLine(" |       |  O Computador Venceu! | o   o | ");
        Console.WriteLine(" |   o   |    Tente Novamente    | o   o | ");
        Console.WriteLine(" |       |                       | o   o | ");
        Console.WriteLine(" +-------+                       +-------+ ");
        Console.WriteLine("\n-------------------------------------------");

        Console.WriteLine("Gostaria de Jogar Novamente? (s/n)");
        string resposta = Console.ReadLine().ToLower();
        if (resposta == "s")
        {
            Console.Clear();
            posicaoJogador = 0;
            posicaoComputador = 0;
            Console.WriteLine("Reiniciando o jogo...");
            Console.WriteLine("Pressione Enter Para Continuar...");
            Console.ReadLine();
        }
        else
        {
            break; // Sair do loop e encerrar o jogo
        }
    }

}
Console.WriteLine("Pressione Enter para sair...");
Console.ReadLine();