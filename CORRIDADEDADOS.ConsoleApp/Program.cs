/*
        Estruturação do Código
*/
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class Program
{
    public static int linhaDeChegada = 30;
    public static Random dado = new Random();
    // Método de Ponto de Entrada
    static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine(" +-------+                    +-------+ ");
        Console.WriteLine(" |       |                    | o   o | ");
        Console.WriteLine(" |   o   |  CORRIDA DE DADOS  | o   o | ");
        Console.WriteLine(" |       |                    | o   o | ");
        Console.WriteLine(" +-------+                    +-------+ ");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Pressione Enter Para Iniciar a Corrida...");
        Console.ReadLine();

        while (Jogador.posicaoJogador < linhaDeChegada && Computador.posicaoComputador < linhaDeChegada)
        {
            // Rodada do jogador
            Jogador.posicaoJogador = Jogador.ExecutarRodada();

            // Verificar se o jogador venceu
            Jogador.ConfirmacaoDeVitoria();

            // Rodada do computador
            Computador.posicaoComputador = Computador.ExecutarRodada();

            // Verificar se o computador venceu
            Computador.ConfirmacaoDeVitoria();
        }
    }
}