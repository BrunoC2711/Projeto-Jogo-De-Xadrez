using System;

namespace tabuleiro {
    internal class Tabuleiro {
        public int qteLinhas { get; set; }
        public int qteColunas { get; set; }
        private Peca[,] pecas;
        public Tabuleiro(int linhas, int colunas) {
            qteLinhas = linhas;
            qteColunas = colunas;
            pecas = new Peca[qteLinhas, qteColunas];
        }
        public Peca peca(int linhas, int colunas) {
            return pecas[linhas, colunas];
        }
        public Peca peca(Posicao posicao) {
            return pecas[posicao.linha, posicao.coluna];
        }
        public bool existePeca(Posicao posicao) {
            validarPosicao(posicao);
            return peca(posicao) != null;
        }
        public void colocarPeca(Peca peca, Posicao posicao) {
            if (existePeca(posicao)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            else {
                pecas[posicao.linha, posicao.coluna] = peca;
                peca.posicao = posicao;
            }
        }
        public Peca retirarPeca(Posicao pos) {
            if(peca(pos) == null) {
                return null;
            }
            else {
                Peca aux = peca(pos);
                aux.posicao = null;
                pecas[pos.linha, pos.coluna] = null;
                return aux;
            }
        }
        public bool posicaoValida(Posicao posicao) {
            if ((posicao.linha < 0 || posicao.linha > qteLinhas) || (posicao.coluna < 0 || posicao.coluna > qteColunas)) {
                return false;
            }
            return true;
        }
        public void validarPosicao(Posicao posicao) {
            if (!posicaoValida(posicao)) {
                throw new TabuleiroException("Posição inválida!! ");
            }
        }
    }
}
