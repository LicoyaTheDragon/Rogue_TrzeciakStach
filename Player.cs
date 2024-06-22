using System;

namespace Rogue
{
    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('@');
        }


        //Ruch gracza

        public bool Move(Map map)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                int newX = X;
                int newY = Y;

                //Zmienia pozycję w zależności od wciśniętego klawisza

                switch (key)
                {
                    case ConsoleKey.W:
                        newY--;
                        break;
                    case ConsoleKey.S:
                        newY++;
                        break;
                    case ConsoleKey.A:
                        newX--;
                        break;
                    case ConsoleKey.D:
                        newX++;
                        break;
                }

                //Sprawdzenie czy można przejść

                if (map.IsWalkable(newX, newY))
                {
                    X = newX;
                    Y = newY;
                    return true;
                }
            }
            return false;
        }
    }
}
