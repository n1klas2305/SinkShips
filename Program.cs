using System;

namespace Programmierung
{
    class Program
    {
        static void Main(string[] args)
        {
            displayShips(randomShipPlace());
        }

        // add ships at random positions in playground
        public static string[,] randomShipPlace()
        {
            int shipCount = 1;
            string[,] playground = new string[20, 20];
            for (int i = 5; i >= 2; i--)
            {
                for (int r = 0; r < shipCount; r++)
                {
                    bool shipCorrect = false;
                    while (!shipCorrect)
                    {
                        int randomX = new Random().Next(0, 20);
                        int randomY = new Random().Next(0, 20);
                        int randomDirection = new Random().Next(0, 4);
                        int shipSection = i;
                        bool isShipValid = isFreeSpaceAndIndexInBounds(randomX, randomY, randomDirection, i, playground);
                        if (randomDirection == 0 && isShipValid)
                        {
                            shipCorrect = true;
                            while (shipSection > 0)
                            {
                                playground[randomX, randomY++] = "x";
                                shipSection--;
                            }
                        }
                        else if (randomDirection == 1 && isShipValid)
                        {
                            shipCorrect = true;
                            while (shipSection > 0)
                            {
                                playground[randomX, randomY--] = "x";

                                shipSection--;
                            }
                        }
                        else if (randomDirection == 2 && isShipValid)
                        {
                            shipCorrect = true;
                            while (shipSection > 0)
                            {
                                playground[randomX++, randomY] = "x";
                                shipSection--;
                            }
                        }
                        else if (randomDirection == 3 && isShipValid)
                        {
                            shipCorrect = true;
                            while (shipSection > 0)
                            {
                                playground[randomX--, randomY] = "x";
                                shipSection--;
                            }
                        }
                    }
                }
                shipCount++;
            }
            return playground;
        }

        // display the playground in the console
        public static void displayShips(string[,] playground)
        {
            Console.WriteLine("Schiffe versenken");
            displayBorder(playground.GetLength(0));
            Console.WriteLine();

            for (int x = 0; x < playground.GetLength(0); x++)
            {
                Console.Write("|#");
                for (int y = 0; y < playground.GetLength(1); y++)
                {
                    if (playground[x, y] == null)
                        Console.Write("| ");
                    else
                        Console.Write("|x");
                }
                Console.Write("|#|");
                Console.WriteLine();
            }
            displayBorder(playground.GetLength(0));
        }

        // display the top/bottom border for the playground in the console
        public static void displayBorder(int arrayLength)
        {
            for (int x = 0; x < arrayLength + 2; x++)
            {
                Console.Write("|#");
            }
            Console.Write("|");
        }

        // check if ship position is valid
        public static bool isFreeSpaceAndIndexInBounds(int x, int y, int direction, int length, string[,] playground)
        {
            if (direction == 0 && y + length < 20)
            {
                while (length > 0)
                {
                    if (playground[x, y++] != null)
                    {
                        return false;
                    }
                    length--;
                }
            }
            else if (direction == 1 && y - length >= 0)
            {
                while (length > 0)
                {
                    if (playground[x, y--] != null)
                    {
                        return false;
                    }
                    length--;
                }
            }
            else if (direction == 2 && x + length < 20)
            {
                while (length > 0)
                {
                    if (playground[x++, y] != null)
                    {
                        return false;
                    }
                    length--;
                }
            }
            else if (direction == 3 && x - length >= 0)
            {
                while (length > 0)
                {
                    if (playground[x--, y] != null)
                    {
                        return false;
                    }
                    length--;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}

