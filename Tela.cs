using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace Meu_Xadrez {
    internal class Tela {
        public static void imprimirTabuleiro(Tabuleiro tabuleiro) {
            for (int i=0; i < tabuleiro.qteLinhas ; i++) {
                Console.Write(tabuleiro.qteLinhas - i + " ");
                for(int j=0; j < tabuleiro.qteColunas; j++) {
                    imprimirPeca(tabuleiro.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[ ");
            foreach(Peca peca in conjunto) {
                Console.Write(peca);
                Console.Write(" , ");
            }
            Console.WriteLine(" ]");

        }
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("PEÇAS CAPTURADAS ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor= aux;
            Console.WriteLine();
        }
        public static void imprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Peça " + partida.jogadorAtual + ", sua vez");
        }
        public static void imprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;


            for (int i = 0; i < tabuleiro.qteLinhas; i++) {
                Console.Write(tabuleiro.qteLinhas - i + " ");
                for (int j = 0; j < tabuleiro.qteColunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tabuleiro.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            try {
                string s = Console.ReadLine();
                char coluna = s[0];
                int linha = int.Parse(s[1] + "");
                return new PosicaoXadrez(coluna, linha);
            }
            catch {
                throw new TabuleiroException("Por favor, escolher valor válido! Ex: <letras de 'a' a 'h'><numero de '1' a '8'>" );
            }
        }

        public static void imprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("- ");
            }
            else {
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }


        }
    }
}
