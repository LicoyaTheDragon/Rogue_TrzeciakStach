//zadaniem merchanta jest zebrać monety od gracza, jeśli oddamu mu wszystkie gra ma sie skończyć


using System;

namespace Rogue
{
    class Merchant
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int TotalCoinsCollected { get; private set; }
        public Merchant(int x, int y)
        {
            X = x;
            Y = y;
            TotalCoinsCollected = 0;
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('M');
        }
        public void CollectCoins(int coins)
        {
            TotalCoinsCollected += coins;
        }
    }
}
