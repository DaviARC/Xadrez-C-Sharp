using Xadrez.Tabuleiro;

namespace Xadrez.PecaXadrez
{

    internal class Peao : Peca
    {
        public Peao(Tabuleiroo tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.Partida = partida;
        }
        public override string ToString() => "P";
        private PartidaDeXadrez Partida;
        private bool existeInimigo(Posicao pos, Tabuleiroo tab)
        {
            Peca p = tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tabuleiro.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis(Tabuleiroo tab)
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);
            if (Cor == Cor.Branca)
            {
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (tab.posicaoValida(p2) && livre(p2) && tab.posicaoValida(pos) && livre(pos) && qTeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos, tab))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos, tab))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant

                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda, tab) && tab.Peca(esquerda) == Partida.vulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita, tab) && tab.Peca(direita) == Partida.vulneravelEnPassant)
                    {
                        mat[direita.Linha - 1, esquerda.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (tab.posicaoValida(p2) && livre(p2) && tab.posicaoValida(pos) && livre(pos) && qTeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                    if (tab.posicaoValida(pos) && existeInimigo(pos, tab))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                    pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                    if (tab.posicaoValida(pos) && existeInimigo(pos, tab))
                        mat[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda, tab) && tab.Peca(esquerda) == Partida.vulneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita, tab) && tab.Peca(direita) == Partida.vulneravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}