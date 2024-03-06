using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

namespace Xadrez.Tabuleiro
{

    public class Tabuleiroo
    {
        public Tabuleiroo(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
            // A matriz pecas terá a mesma quantidade de linhas e colunas do tabuleiro
        }
        public int Linhas { get; set; }
        //Vai ter um número de linhas (no modelo pode variar)
        public int Colunas { get; set; }
        //Vai ter um número de colunas
        internal Peca[,] pecas;
        //Pecas do tabuleiro
        internal Peca Peca1(int linha, int coluna) => pecas[linha, coluna];
        internal Peca Peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        internal void colocaPeca(Peca p, Posicao pos)
        // colocará a peça 'P' na matriz 'pecas' do tabuleiro, e mudará a posição para a dada no método
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
        internal Peca retirarPeca(Posicao pos)
        {
            if (Peca(pos) == null)
            {
                return null;
            }
            Peca aux = Peca(pos);
            aux.Posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        internal bool existePeca(Posicao pos)
        {
            // caso a posição seja válida, verifique se existe peça
            validaPosicao(pos);
            return Peca(pos) != null;
        }
        internal bool posicaoValida(Posicao pos)
        {
            // esse método é utilizado para tratamento de erro
            // se a linha dada for menor que 0, maior ou igual o número de linhas do tabuleiro, a coluna for menor q zero ou igual o núemero de colunas
            // será retornado falso, ou seja a posição dada não é válida
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
        internal void validaPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }

    }
}