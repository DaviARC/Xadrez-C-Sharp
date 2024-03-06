using Xadrez.Tabuleiro;

namespace Xadrez.PecaXadrez
{

    internal class Cavalo : Peca
    {
        public Cavalo(Tabuleiroo tab, Cor cor)
        : base(tab, cor)
        {
        }
        public override string ToString() => "C";

        private bool podeMover(Posicao pos, Tabuleiroo tab)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis(Tabuleiroo tab)
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
