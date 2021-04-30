using System;

namespace Programmierung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            displayShips(randomShipPlace());
        }

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
                        int help = i;
                        if (randomDirection == 0 && isFreeSpaceAndIndexInBounds(randomX, randomY, randomDirection, i, playground))
                        {
                            shipCorrect = true;
                            while (help > 0)
                            {
                                playground[randomX, randomY++] = "x";
                                help--;
                            }
                        }
                        else if (randomDirection == 1 && isFreeSpaceAndIndexInBounds(randomX, randomY, randomDirection, i, playground))
                        {
                            shipCorrect = true;
                            while (help > 0)
                            {
                                playground[randomX, randomY--] = "x";

                                help--;
                            }
                        }
                        else if (randomDirection == 2 && isFreeSpaceAndIndexInBounds(randomX, randomY, randomDirection, i, playground))
                        {
                            shipCorrect = true;
                            while (help > 0)
                            {
                                playground[randomX++, randomY] = "x";
                                help--;
                            }
                        }
                        else if (randomDirection == 3 && isFreeSpaceAndIndexInBounds(randomX, randomY, randomDirection, i, playground))
                        {
                            shipCorrect = true;
                            while (help > 0)
                            {
                                playground[randomX--, randomY] = "x";
                                help--;
                            }
                        }
                    }
                }
                shipCount++;
            }
            return playground;
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
            return true;
        }
    }
}

