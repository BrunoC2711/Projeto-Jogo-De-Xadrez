using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    internal class PartidaDeXadrez {
        public Tabuleiro tab { get; set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca peca = tab.retirarPeca(origem);
            peca.incrementarQteMovimentos();
            Peca pecaCapturada = this.tab.retirarPeca(destino);
            tab.colocarPeca(peca, destino);
            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if(tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            } 
            if(jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida, não é sua!!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).podeModerPara(destino)) {
                throw new TabuleiroException("Este não é um movimento possível!!");
            }

        }
        private void mudaJogador() {
            if (this.jogadorAtual == Cor.Branca) {
                this.jogadorAtual = Cor.Preta;
            } else if (this.jogadorAtual == Cor.Preta) {
                this.jogadorAtual = Cor.Branca;
            }
        }
        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> resp = new HashSet<Peca>();
            foreach(Peca peca in capturadas) {
                if (cor == peca.cor) {
                    resp.Add(peca);
                }
            }
            return resp;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> resp = new HashSet<Peca>();
            foreach (Peca peca in pecas) {
                if (cor == peca.cor) {
                    resp.Add(peca);
                }
            }
            resp.ExceptWith(pecasCapturadas(cor));
            return resp;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas() {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Rei(tab, Cor.Preta));

            Console.WriteLine(pecas);

        }
    }
}
