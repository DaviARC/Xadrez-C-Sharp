using Xadrez.Tabuleiro;

namespace Xadrez.PecaXadrez
{

    internal class Rei : Peca
    {
        public Rei(Tabuleiroo tab, Cor cor, PartidaDeXadrez partida)
        : base(tab, cor)
        {
            Partida = partida;
        }
        private PartidaDeXadrez Partida;
        public override string ToString() => "R";

        private bool podeMover(Posicao pos, Tabuleiroo tab)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }
        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);

            return p != null && p is Torre && p.Cor == Cor && p.qTeMovimentos == 0;

        }

        public override bool[,] MovimentosPossiveis(Tabuleiroo tab)
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            };
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            };
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            };
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            };
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            };
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            };
            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            };
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos, tab))
            {
                mat[pos.Linha, pos.Coluna] = true;
            };

            // #jogadaespecial roque
            if (qTeMovimentos == 0 && !Partida.xeque)
            {
                // #Jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (tab.Peca(p1) == null && tab.Peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
                if (qTeMovimentos == 0 && !Partida.xeque)
                {
                    // #Jogadaespecial roque grande
                    Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                    if (testeTorreParaRoque(posT2))
                    {
                        Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                        Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                        Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                        if (tab.Peca(p1) == null && tab.Peca(p2) == null && tab.Peca(p3) == null)
                        {
                            mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                        }
                    }
                }
            }

            return mat;

        }
    }

}

