//monety leżące na mapie do zbierania

using System;

namespace Rogue
{
    class Coin
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Collected { get; private set; }

        public Coin(int x, int y)
        {
            X = x;
            Y = y;
            Collected = false;
        }

        public void Draw()
        {
            if (!Collected)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write('$');
            }
        }

        public void Collect()
        {
            Collected = true;
        }
    }
}
