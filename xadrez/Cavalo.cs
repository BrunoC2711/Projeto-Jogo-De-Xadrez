using System;
using tabuleiro;

namespace Meu_Xadrez.xadrez {
    internal class Cavalo : Peca{
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro,cor) {
        }
        public override string ToString() {
            return "C";
        }
        public override bool[,] movimentosPossiveis() {
            throw new NotImplementedException();
        }

    }
}
