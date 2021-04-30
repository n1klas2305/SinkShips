using System;

namespace Programmierung
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] playground = randomShipPlace();
            displayShips(playground);
        }

        // create a playground with ships
        public static string[,] randomShipPlace()
        {
            int[] shipCounts = new int[] { 1, 2, 3, 4 };
            int[] shipLengths = new int[] { 5, 4, 3, 2 };
            string[,] playground = new string[20, 20];

            // iterate each ship type
            for (int shipCount = 0; shipCount < shipCounts.Length; shipCount++)
            {
                int shipLength = shipLengths[shipCount];
                // iterate count of ship type
                for (int ship = 0; ship < shipCounts[shipCount]; ship++)
                {
                    createShip(shipLength, playground);
                }
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

        // add a ship to playground
        public static string[,] createShip(int shipLength, string[,] playground)
        {
            bool valid = false;
            int randomX = 0, randomY = 0, randomDirection = 0, x, y;

            // find valid place for ship
            while (!valid)
            {
                bool error = false;
                randomX = new Random().Next(0, 20);
                randomY = new Random().Next(0, 20);
                randomDirection = new Random().Next(0, 4);

                x = randomX;
                y = randomY;

                for (int shipPart = 0; shipPart < shipLength; shipPart++)
                {
                    bool isXValid = 0 <= x && x < playground.GetLength(0);
                    bool isYValid = 0 <= y && y < playground.GetLength(1);
                    if (isXValid && isYValid && playground[x, y] == null)
                    {
                        (int X, int Y) cords = moveToDirection(x, y, randomDirection);
                        x = cords.X;
                        y = cords.Y;
                    }
                    else
                    {
                        error = true;
                    }
                    if (shipPart == shipLength - 1 && !error) valid = true;
                }
            }
            x = randomX;
            y = randomY;

            // add ships to playground
            for (int shipPart = 0; shipPart < shipLength; shipPart++)
            {
                playground[x, y] = "x";

                (int X, int Y) cords = moveToDirection(x, y, randomDirection);
                x = cords.X;
                y = cords.Y;
            }
            return playground;
        }

        // move 1 coorinate from startpoint into direction
        public static (int X, int Y) moveToDirection(int x, int y, int direction)
        {
            if (direction == 0)
                x++;
            else if (direction == 1)
                x--;
            else if (direction == 2)
                y++;
            else if (direction == 3)
                y--;
            return (x, y);
        }
    }
}