/*
        Estruturação do Código
*/
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class Program
{
    // Definição de um Método para Executar a Rodada do Jogador
    static int ExecutarRodadaDoJogador
        (
            int posicaoJogador,
            int posicaoComputador,
            Random dado
        )

    {
        Console.Clear();
        Console.WriteLine($"Possição Inicial: Jogador = {posicaoJogador} / 30");
        Console.WriteLine($"Possição Inicial: Computador = {posicaoComputador} / 30");
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Turno do Jogador:");
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Pressione Enter Para Rolar o Dado...");
        Console.ReadLine();

        // 1. Turno do jogador
        int dadoJogador;
        do
        {
            dadoJogador = dado.Next(1, 7);
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

            if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15)
            {
                posicaoJogador += 3;
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("Evento Especial: Avanço Extra! Você Avançou +3 Casas!");
                Console.WriteLine("\n-------------------------------------------");
                Console.ReadLine();
            }
            else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
            {
                posicaoJogador -= 2;
                if (posicaoJogador < 0) posicaoJogador = 0;
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("Evento Especial: Recuo! Você Recuou -2 Casas!");
                Console.WriteLine("\n-------------------------------------------");
                Console.ReadLine();
            }
            else if (posicaoJogador >= 30)
            {
                break;
            }

        } while (dadoJogador == 6);

        return posicaoJogador;
    }

    static void ConfirmacaoDeVitoriaDoJogador
    (
        int posicaoJogador,
        int linhaDeChegada
    )

    {
        if (posicaoJogador >= linhaDeChegada)
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine(" +-------+                       +-------+ ");
            Console.WriteLine(" |       |       Parabens!       | o   o | ");
            Console.WriteLine(" |   o   |      Você Venceu      | o   o | ");
            Console.WriteLine(" |       |                       | o   o | ");
            Console.WriteLine(" +-------+                       +-------+ ");
            Console.WriteLine("\n-------------------------------------------");

        }

        else
        {
            Console.WriteLine("Pressione Enter Para Continuar...");
            Console.ReadLine();
        }
    }

    // Definição de um Método para Executar a Rodada do Computador
    static int ExecutarRodadaDoComputador
        (
            int posicaoComputador,
            Random dado
        )
    {
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Turno do Computador:");
        Console.WriteLine("\n-------------------------------------------");

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
            else if (posicaoComputador >= 30)
            {
                break; // O computador venceu, sair do loop
            }
        } while (dadoComputador == 6); // O computador continua jogando enquanto tirar 6

        return posicaoComputador;
    }

    static void ConfirmacaoDeVitoriaDoComputador
    (
        int posicaoComputador,
        int linhaDeChegada
    )

    {
        if (posicaoComputador >= linhaDeChegada)
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine(" +-------+                       +-------+ ");
            Console.WriteLine(" |       |  O Computador Venceu! | o   o | ");
            Console.WriteLine(" |   o   |    Tente Novamente    | o   o | ");
            Console.WriteLine(" |       |                       | o   o | ");
            Console.WriteLine(" +-------+                       +-------+ ");
            Console.WriteLine("\n-------------------------------------------");

        }

        else
        {
            Console.WriteLine("Pressione Enter Para Continuar...");
            Console.ReadLine();
        }
    }

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
            posicaoJogador = ExecutarRodadaDoJogador
            (
                posicaoJogador,
                posicaoComputador,
                dado
            );

            // Verificar se o jogador venceu
            ConfirmacaoDeVitoriaDoJogador
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
            posicaoComputador = ExecutarRodadaDoComputador
            (
                posicaoComputador,
                dado
            );

            // Verificar se o computador venceu
            ConfirmacaoDeVitoriaDoComputador
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