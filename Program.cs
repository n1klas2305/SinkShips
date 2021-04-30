using System;

namespace Programmierung
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] playground = new string[20, 20];
            playground[1, 2] = "x";
            displayShips(playground);
        }

        public static void randomShipPlace()
        {
            int shipCount = 1;
            string[,] playground = new string[20, 20];
            for (int i = 5; i <= 2; i--)
            {
                for (int r = 0; r < shipCount; r++)
                {
                    int randomX = new Random().Next(0, 20);
                    int randomY = new Random().Next(0, 20);
                    playground[randomX, randomY] = "x";
                    int randomDirection = new Random().Next(0, 4);
                    if(randomDirection == 0) {
                        int help = i;
                        while(help > 0) {
                            playground[randomX, randomY++] = "x";
                            help--;
                        }
                    } else if(randomDirection == 1) {
                        int help = i;
                        while(help > 0) {
                            playground[randomX, randomY--] = "x";
                            help--;
                        }
                    } else if(randomDirection == 2) {
                        int help = i;
                        while(help > 0) {
                            playground[randomX, randomY--] = "x";
                            help--;
                        }
                    } else if(randomDirection == 3) {
                        int help = i;
                        while(help > 0) {
                            playground[randomX, randomY--] = "x";
                            help--;
                        }
                    }
                }
                shipCount++;
            }
        }
        
        // displays the playground in the console
        public static void displayShips(string[,] playground)
        {
            int arrayLength = playground.GetLength(0);
            Console.WriteLine("Schiffe versenken");
            displayBorder(arrayLength);
            Console.WriteLine();

            for (int x = 0; x < arrayLength; x++)
            {
                Console.Write("|#");
                for (int y = 0; y < arrayLength; y++)
                {
                    if (playground[x, y] == null)
                        Console.Write("| ");
                    else
                        Console.Write("|x");
                }
                Console.Write("|#|");
                Console.WriteLine();
            }
            displayBorder(arrayLength);
        }

        // displays the top/bottom border for the playground in the console
        public static void displayBorder(int arrayLength)
        {
            for (int x = 0; x < arrayLength + 2; x++)
            {
                Console.Write("|#");
            }
            Console.Write("|");
        }
    }
}

