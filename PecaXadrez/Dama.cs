using Xadrez.Tabuleiro;

namespace Xadrez.PecaXadrez
{

    internal class Dama : Peca
    {
        public Dama(Tabuleiroo tab, Cor cor)
        : base(tab, cor)
        {
        }
        public override string ToString() => "D";
        private bool podeMover(Posicao pos, Tabuleiroo tab)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis(Tabuleiroo tab)
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // esquerda
            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha, pos.Coluna - 1);
            }

            // direita
            pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha, pos.Coluna + 1);
            }

            // acima
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha - 1, pos.Coluna);
            }

            // abaixo
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha + 1, pos.Coluna);
            }

            // NO
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // NE
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // SE
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                    break;
            }
            pos.definirValores(pos.Linha + 1, pos.Coluna + 1);

            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return mat;
        }
    }
}