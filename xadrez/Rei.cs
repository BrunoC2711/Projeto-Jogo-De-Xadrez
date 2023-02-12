using System;
using tabuleiro;

namespace xadrez {
    internal class Rei : Peca{
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

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
            if(tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // CIMA + DIREITA
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) || podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // DIREITA
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) || podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // BAIXO + DIREITA
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) || podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // BAIXO
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) || podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // BAIXO + ESQUERDA
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) || podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // ESQUERDA
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) || podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // CIMA + ESQUERDA
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) || podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }
        public override string ToString() {
            return "K";
        }
    }
}
