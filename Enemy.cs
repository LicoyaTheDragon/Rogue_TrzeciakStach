using System;

namespace Rogue
{
    class Enemy
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private Random random; //Generator liczb losowych ruchu wroga

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
            random = new Random();
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('&');
        }


        //Przemieszczanie wroga w losowym kierunku

        public void Move(Map map)
        {
            int direction = random.Next(4);
            int newX = X;
            int newY = Y;

            switch (direction)
            {
                case 0: 
                    newY--;
                    break;
                case 1: 
                    newY++;
                    break;
                case 2: 
                    newX--;
                    break;
                case 3: 
                    newX++;
                    break;
            }

            if (map.IsWalkable(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
