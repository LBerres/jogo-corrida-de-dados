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
        Abertura.abertura();

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