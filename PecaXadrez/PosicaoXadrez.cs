using System.Runtime.CompilerServices;
using Xadrez.Tabuleiro;


namespace Xadrez.PecaXadrez
{
    public class PosicaoXadrez
    {
        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }
        public char Coluna { get; set; }
        public int Linha { get; set; }
        internal Posicao toPosicao()
        {
            //levando em consideração q uma matriz funciona diferente dos pontos de referência no xadrez, nós devemos adaptar
            //devemos diminuir 8 pela quantidade de linhas por conta do xadrez começar com o 8 e n com o zero esperado pela matriz
            //o 'a' será utilizado como o número 1, caso desejarmos a casa F, o calculo será 6 - 1, ou seja 5 (a matriz começa no zero )
            return new Posicao(8 - Linha, Coluna - 'a');
        }
        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}