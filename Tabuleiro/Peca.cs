namespace Xadrez.Tabuleiro
{
    // peca é um objeto genérico
    abstract class Peca
    {
        public Peca(Tabuleiroo tabuleiro, Cor cor)
        {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            qTeMovimentos = 0;
        }

        public Posicao Posicao { get; set; }
        // uma Peça possui uma posição
        public Cor Cor { get; protected set; }
        // possui uma cor q é limitadas às cores definidas no enum Cor
        public int qTeMovimentos { get; protected set; }
        // quantidade de movimentos de determinada peça
        public Tabuleiroo Tabuleiro { get; protected set; }
        // a peca está em um tabuleiro
        public void IncrementarQteMovimentos()
        {
            qTeMovimentos++;
        }
        public void decrementarQteMovimentos()
        {
            qTeMovimentos--;
        }
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis(Tabuleiro);
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis(Tabuleiro)[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis(Tabuleiroo tab);

    }
}