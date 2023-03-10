using tabuleiro;
using System;
using Meu_Xadrez;
using xadrez;

namespace MeuXadrez{
    internal class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) {
                    try {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        Console.Clear();
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException ex) {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}