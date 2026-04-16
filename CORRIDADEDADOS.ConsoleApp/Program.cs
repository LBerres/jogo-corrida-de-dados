/*
        Estruturação do Código
*/
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class Program
{
    // Método de Ponto de Entrada
    static void Main(string[] args)
    {
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
            // Rodada do jogador
            posicaoJogador = Jogador.ExecutarRodada
            (
                posicaoJogador,
                posicaoComputador,
                dado
            );
            // Verificar se o jogador venceu
            Jogador.ConfirmacaoDeVitoria
            (
                posicaoJogador,
                linhaDeChegada
            );
            if (posicaoJogador >= linhaDeChegada)
            {
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
                    Console.WriteLine("Obrigado Por Jogar!");
                    Console.WriteLine("Pressione Enter para sair...");
                    Console.ReadLine();
                    break; // Sair do loop e encerrar o jogo
                }
            }
            // Rodada do computador
            posicaoComputador = Computador.ExecutarRodada
            (
                posicaoComputador,
                dado
            );
            // Verificar se o computador venceu
            Computador.ConfirmacaoDeVitoria
            (
                posicaoComputador,
                linhaDeChegada
            );
            if (posicaoComputador >= linhaDeChegada)
            {
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
                    Console.WriteLine("Obrigado Por Jogar!");
                    Console.WriteLine("Pressione Enter para sair...");
                    Console.ReadLine();
                    break; // Sair do loop e encerrar o jogo
                }
            }
        }
    }
}