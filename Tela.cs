using System.Globalization;
using System.Net.Http.Headers;
using Xadrez.Tabuleiro;
using Xadrez.PecaXadrez;
using System.Collections.Generic;

namespace Xadrez
{

    public class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("Xeque!");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("XEQUEMATE");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
        }
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        internal static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiroo tab)
        {


            for (int i = 0; i < tab.Linhas; i++)
            // se repetirá de acordo com o número de linhas
            {
                Console.Write(8 - i + " ");
            // na primeira linha escreverá 8 - i, resultando na numeração da esquerda
                for (int j = 0; j < tab.Colunas; j++)
                {
                    imprimirPeca(tab.Peca1(i, j));
            // o método (tab.Peca1) retornará uma peca na posição i, j (0,0 - 0,1 - 0,2...)
                }
                Console.WriteLine(); // pula a linha
            }
            Console.WriteLine("  a b c d e f g h");
            //fora do laço de repetição escreve as letras de referencia do tabuleiro
        }

        public static void imprimirTabuleiro(Tabuleiroo tab, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            // se repetirá de acordo com o número de linhas 
            for (int i = 0; i < tab.Linhas; i++)
            {
            // na primeira linha escreverá 8 - i, resultando na numeração da esquerda 
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++)
                {
                // se repetirá de acordo com o número de colunas (acontencerá dentro do laço das linhas)    
                    
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.Peca1(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        internal static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                // caso a váriavel 'peca' seja nula, irá ser escrito um traço
                Console.Write("- ");
            }
            else // se não
            {
                // caso a propiedade Cor da peca for branca, apenas escreva
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                // se não (peça vai ser preta)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                // mude a cor para amarelo e escreva a peça 
                }
                Console.Write(" ");
            }

        }
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            // char l = char.Parse(s[1].ToString());
            // int linha = (int)l - (int)'a';
            return new PosicaoXadrez(coluna, linha);
        }

    }
}