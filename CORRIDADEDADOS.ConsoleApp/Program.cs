/*
Especificação do Jogo de Corrida de Dados
Objetivo do Jogo: O jogador e o computador competem em uma corrida virtual. Cada um rola um dado virtua
(geração de números aleatórios) para avançar em uma pista. O primeiro a alcançar ou ultrapassar a linha d
chegada vence.

Regras e Funcionalidades:
1. Pista:
○ A pista é representada por uma linha numérica (ex.: de 0 a 30).
○ O jogador e o computador começam na posição 0.

2. Turnos:
○ O jogador e o computador alternam turnos para rolar um dado (gerar um número aleatório
entre 1 e 6).
○ O número gerado é somado à posição atual do competidor.
○ O jogo exibe a posição atual do jogador e do computador após cada rodada.

*/
int linhaDeChegada = 30;
int posicaoJogador = 0;
int posicaoComputador = 0;
Random random = new Random();

Console.WriteLine("-------------------------------------------");
Console.WriteLine("JOGO DE CORRIDA DE DADOS");
Console.WriteLine("-------------------------------------------");

while (posicaoJogador < linhaDeChegada && posicaoComputador < linhaDeChegada)
{
    Console.WriteLine("Pressione Enter Para Rolar o Dado...");
    Console.ReadLine();

    // Turno do jogador
    int dadoJogador = random.Next(1, 7);
    posicaoJogador += dadoJogador;
    Console.WriteLine($"Você Rolou {dadoJogador}. Sua Posição Atual: {posicaoJogador}");

    // Verificar se o jogador venceu
    if (posicaoJogador >= linhaDeChegada)
    {
        Console.WriteLine("Parabéns! Você Venceu a Corrida!");
        break;
    }

    // Turno do computador
    int dadoComputador = random.Next(1, 7);
    posicaoComputador += dadoComputador;
    Console.WriteLine($"O computador Rolou {dadoComputador}. Posição Atual do Computador: {posicaoComputador}");

    // Verificar se o computador venceu
    if (posicaoComputador >= linhaDeChegada)
    {
        Console.WriteLine("O computador Venceu a Corrida! Tente novamente.");
        break;
    }


}





Console.WriteLine("-------------------------------------------");
Console.WriteLine("Pressione Enter para sair...");
Console.ReadLine();