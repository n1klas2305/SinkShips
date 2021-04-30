using System;

namespace Programmierung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
    }
}
