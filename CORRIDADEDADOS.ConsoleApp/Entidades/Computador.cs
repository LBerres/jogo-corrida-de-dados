/*
        Estruturação do Código
*/
class Computador
{
    public static int posicaoComputador = 0;
    // Definição de um Método para Executar a Rodada do Computador
    public static int ExecutarRodada()
    {
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Turno do Computador:");
        Console.WriteLine("\n-------------------------------------------");

        int dadoComputador;
        do
        {
            dadoComputador = Program.dado.Next(1, 7);
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

    public static void ConfirmacaoDeVitoria()
    {
        if (posicaoComputador >= Program.linhaDeChegada)
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

        if (Computador.posicaoComputador >= Program.linhaDeChegada)
        {
            Console.WriteLine("Gostaria de Jogar Novamente? (s/n)");
            string resposta = Console.ReadLine().ToLower();
            if (resposta == "s")
            {
                Console.Clear();
                Jogador.posicaoJogador = 0;
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
