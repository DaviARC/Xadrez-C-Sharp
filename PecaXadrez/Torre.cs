using Xadrez.Tabuleiro;

namespace Xadrez.PecaXadrez
{

    internal class Torre : Peca
    {
        public Torre(Tabuleiroo tab, Cor cor)
        : base(tab, cor)
        { }
        public override string ToString() => "T";
        private bool podeMover(Posicao pos, Tabuleiroo tab)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }
        public override bool[,] MovimentosPossiveis(Tabuleiroo tab)
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            pos.definirValores(pos.Linha - 1, pos.Coluna);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            pos.definirValores(pos.Linha + 1, pos.Coluna);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            pos.definirValores(pos.Linha, pos.Coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }
            pos.definirValores(pos.Linha, pos.Coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }


            return mat;
        }
    }
}
