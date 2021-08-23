using System;

namespace TicTacToeEnd
{
    class Program
    {
        static int[] board = new int[9];
        static void Main(string[] args)
        {
            showMenu();
        }

        private static void showMenu()
        {
            bool cont = true;

            while (cont)
{
                Console.WriteLine("Select the # of players (1 or 2)");
                Console.WriteLine("Ready (3)");

                int opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        //pass 1 to game()
                        break;

                    case 2:
                        //pass 2 to game()
                        break;

                    case 3:
                        game(); 
                        break;

                    
                    default:
                        cont = false;
                        break;
                }
            }
        }

        private static void game()
        {
            board[0] = 0;
            board[1] = 0;
            board[2] = 0;
            board[3] = 0;
            board[4] = 0;
            board[5] = 0;
            board[6] = 0;
            board[7] = 0;
            board[8] = 0;

            int userTurn = -1;
            int computerTurn = -1;
            Random rand = new Random();

            //gameloop
            while (checkForWinner() == 0)
            {
                // avoid player to choose occupied square
                while (userTurn == -1 || board[userTurn] != 0)
                {
                    Console.WriteLine("Enter a number from 0 to 8");
                    userTurn = int.Parse(Console.ReadLine());
                    Console.WriteLine("You tiped " + userTurn);
                }

                board[userTurn] = 1;

                // avoid computer to choose occupied square
                while (computerTurn == -1 || board[computerTurn] != 0)
                {
                    computerTurn = rand.Next(8);
                    Console.WriteLine("Computer Chooses " + computerTurn);
                }

                board[computerTurn] = 2;

                printBoard();


            }
            //show winner
            Console.WriteLine("Player " + checkForWinner() + " won the game");
        }

        private static int checkForWinner()

        {
            int ans=0;
            //rows
            if (board[0] == board[1] && board[1] == board[2])
            {
                ans = board[0];
            }
            if (board[3] == board[4] && board[4] == board[5])
            {
                ans = board[3];
            }
            if (board[8] == board[7] && board[7] == board[8])
            {
                ans = board[8];
            }
            //columns
            if (board[0] == board[3] && board[3] == board[6])
            {
                ans = board[0];
            }
            if (board[1] == board[4] && board[4] == board[7])
            {
                ans = board[1];
            }
            if (board[2] == board[5] && board[5] == board[8])
            {
                ans = board[2];
            }
            //diagonals
            if (board[0] == board[4] && board[4] == board[8])
            {
                ans = board[0];
            }
            if (board[2] == board[4] && board[4] == board[6])
            {
                ans = board[2];
            }
           return ans;

        }
        private static void printBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                // Console.WriteLine("Square " + i + " contains " + board[i]);            
                // print x or o for each square
                // 0 = occupied. 1 = p1 (x). 2 = p2 (o)
                if (board[i] == 0)
                {
                    Console.Write(" . ");
                }
                if (board[i] == 1)
                {
                    Console.Write(" X ");
                }
                if (board[i] == 2)
                {
                    Console.Write(" O ");
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }

            }
        }
    }
}
