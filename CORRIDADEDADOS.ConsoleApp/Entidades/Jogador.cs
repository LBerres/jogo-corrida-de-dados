class Jogador
{
    public static int posicaoJogador = 0;
    // Definição de um Método para Executar a Rodada do Jogador
    public static int ExecutarRodada()
    {
        Console.Clear();
        Console.WriteLine($"Possição Inicial: Jogador = {posicaoJogador} / 30");
        Console.WriteLine($"Possição Inicial: Computador = {Computador.posicaoComputador} / 30");
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Turno do Jogador:");
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Pressione Enter Para Rolar o Dado...");
        Console.ReadLine();

        // 1. Turno do jogador
        int dadoJogador;
        do
        {
            dadoJogador = Program.dado.Next(1, 7);
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

    public static void ConfirmacaoDeVitoria()
    {
        if (posicaoJogador >= Program.linhaDeChegada)
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

        if (Jogador.posicaoJogador >= Program.linhaDeChegada)
        {
            Console.WriteLine("Gostaria de Jogar Novamente? (s/n)");
            string resposta = Console.ReadLine().ToLower();
            if (resposta == "s")
            {
                Console.Clear();
                posicaoJogador = 0;
                Computador.posicaoComputador = 0;
                Console.WriteLine("Reiniciando o jogo...");
                Console.WriteLine("Pressione Enter Para Continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Obrigado Por Jogar!");
                Console.WriteLine("Pressione Enter para sair...");
                Console.ReadLine();
                return; // Sair do loop e encerrar o jogo
            }
        }
    }
}
