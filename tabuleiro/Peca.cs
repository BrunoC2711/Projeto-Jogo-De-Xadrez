using System;

namespace tabuleiro {
    abstract class Peca {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; set; }

        public Peca(Tabuleiro tabuleiro , Cor cor ) {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.qteMovimentos = 0;
        }
        public void incrementarQteMovimentos() {
            qteMovimentos++;
        }
        public void decrementarQteMovimentos() {
            qteMovimentos--;
        }
        public abstract bool[,] movimentosPossiveis();
        public bool podeModerPara(Posicao pos) {
            if ((pos.linha <= 8 && pos.linha > 0) && (pos.coluna <= 8 && pos.coluna > 0)) {
                return movimentosPossiveis()[pos.linha, pos.coluna];
            } else {
                throw new TabuleiroException("Digite um destino válido!");
            }
        }
        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.qteLinhas; i++) {
                for (int j = 0; j < tabuleiro.qteColunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
