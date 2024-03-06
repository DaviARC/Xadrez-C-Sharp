namespace Xadrez.Tabuleiro
{
    class Posicao
    {
        // A posição definirá a localização da Peça no tabuleiro, será muito utilizada em comparações

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public void definirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public int Linha { get; set; }
        public int Coluna { get; set; }
    }
}