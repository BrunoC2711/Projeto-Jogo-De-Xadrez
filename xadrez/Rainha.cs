using System;
using tabuleiro;

namespace Meu_Xadrez.xadrez {
    internal class Rainha : Peca {
        public Rainha(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.qteLinhas, tabuleiro.qteColunas];
            Posicao pos = new Posicao(0, 0);

            // CIMA
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while(tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha--;
            }
            // CIMA + DIREITA
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha--;
                pos.coluna++;
            }
            // DIREITA
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.coluna++;
            }
            // BAIXO + DIREITA
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha++;
                pos.coluna++;
            }
            // BAIXO
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha++;
            }
            // BAIXO + ESQUERDA
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha++;
                pos.coluna--;
            }
            // ESQUERDA
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.coluna--;
            }
            // CIMA + ESQUERDA
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha--;
                pos.coluna--;
            }
            return mat;
        }

        public override string ToString() {
            return "Q";
        }
    }
}
