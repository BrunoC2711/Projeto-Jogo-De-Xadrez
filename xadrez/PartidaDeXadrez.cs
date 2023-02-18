using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    internal class PartidaDeXadrez {
        public Tabuleiro tab { get; set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        public bool xeque { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            xeque = false;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }
        public Peca executaMovimento(Posicao origem, Posicao destino) {
            Peca peca = tab.retirarPeca(origem);
            peca.incrementarQteMovimentos();
            Peca pecaCapturada = this.tab.retirarPeca(destino);
            tab.colocarPeca(peca, destino);
            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca peca = tab.retirarPeca(destino);
            peca.decrementarQteMovimentos();
            if(pecaCapturada != null) {
                tab.colocarPeca(pecaCapturada, origem);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(peca, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino);
            if (estaEmXeque(jogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque! ");
            }
            if (estaEmXeque(adversaria(jogadorAtual))) {
                xeque = true;
            } else {
                xeque = false;
            }
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

        public bool estaEmXeque(Cor cor) {
            Peca r = rei(cor);
            if (r == null) {
                throw new TabuleiroException("Não tem rei da cor "+ cor +" no tabuleiro");
            }
            foreach (Peca peca in pecasEmJogo(adversaria(cor))) {
                bool[,] mat = peca.movimentosPossiveis();
                if (mat[r.posicao.linha,r.posicao.coluna]) {
                    return true;
                }
            }
            return false;
        }

        private Cor adversaria(Cor cor) {
            if(cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor) {
            foreach(Peca peca in pecasEmJogo(cor)) {
                if(peca is Rei) {
                    return peca;
                }
            }
            return null;
        }
        private void mudaJogador() {
            if (this.jogadorAtual == Cor.Branca) {
                this.jogadorAtual = Cor.Preta;
            }
            else if (this.jogadorAtual == Cor.Preta) {
                this.jogadorAtual = Cor.Branca;
            }
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
