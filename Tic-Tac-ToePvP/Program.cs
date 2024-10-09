

using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Tic_Tac_ToePvP
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] board = new char[9];
            for (int i = 0; i < 9; i++)
            {
                board[i] = ' ';
            }
            
            char symbol = 'X';
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J"); // escape sequence to clear all the console
                Console.WriteLine("Board:");
                Console.Write("---+---+---\n");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write($" {board[i]} |");
                    if (i == 2 || i == 5 || i == 8)
                    {
                        Console.Write("\n---+---+---\n");
                    }
                }

                Console.WriteLine("Pick cell from 1 to 9:");
                Console.Write("---+---+---\n");
                for (int i = 1; i <= 9; i++)
                {
                    Console.Write($" {i} |");

                    if (i == 3 || i == 6 || i == 9)
                    {
                        Console.Write("\n---+---+---\n");
                    }
                }
                
             
                
                Console.Write($"Put a {symbol}: ");
                
                while (true)
                {
                    string pos = Console.ReadLine();
                    if (int.TryParse(pos, out int position))
                    {
                        if (position <= 0 || position >= 10)
                        {
                            Console.Write("Type a valid number from 1 to 9: ");
                        }
                        else
                        {
                            if (board[position - 1] == ' ')
                            {
                                board[position - 1] = symbol;
                            }
                            else
                            {
                                Console.WriteLine("This cell is already played!");
                                continue;
                            }

                            break;
                        }
                    }
                    else
                    {
                        Console.Write("Type an integer from 1 to 9: ");
                    }
                    
                }

                if (CheckForWinner(board, symbol))
                {
                    Console.WriteLine($"Player {symbol} wins!");
                    return;
                }

                if (CheckForTie(board))
                {
                    Console.WriteLine("Its a tie!");
                    return;
                }
                
                if (symbol == 'X')
                {
                    symbol = 'O';
                }
                else
                {
                    symbol = 'X';
                }
                

            }
        }


        static bool CheckForWinner(char[] board,char symbol)
        {
            if ((board[0] == symbol && board[1] == symbol && board[2] == symbol) ||
                (board[3] == symbol && board[4] == symbol && board[5] == symbol) ||
                (board[6] == symbol && board[7] == symbol && board[8] == symbol) ||
                (board[0] == symbol && board[3] == symbol && board[6] == symbol) ||
                (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
                (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
                (board[0] == symbol && board[4] == symbol && board[8] == symbol) ||
                (board[2] == symbol && board[4] == symbol && board[6] == symbol))
            {
                return true;
            }
            
            return false;
            
        }
        
        static bool CheckForTie(char[] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                    return false;
            }

            return true;
        }
    }
}
