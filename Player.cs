using System;

namespace Rogue
{
    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int CoinsCollected { get; private set; } 
        public Player(int x, int y)
        {
            X = x;
            Y = y;
            CoinsCollected = 0;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('@');
        }
        public bool Move(Map map, Coin[] coins, Merchant merchant)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                int newX = X;
                int newY = Y;

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
                if (map.IsWalkable(newX, newY) || (newX == merchant.X && newY == merchant.Y))
                {
                    X = newX;
                    Y = newY;
                    CollectCoin(newX, newY, coins, map);
                    InteractWithMerchant(newX, newY, merchant);
                    return true;
                }
            }
            return false;
        }

        private void CollectCoin(int x, int y, Coin[] coins, Map map)
        {
            foreach (var coin in coins)
            {
                if (coin != null && coin.X == x && coin.Y == y)
                {
                    CoinsCollected++;
                    coin.Collect(); 
                    map.UpdateCoin(coin); 
                }
            }
        }private void InteractWithMerchant(int x, int y, Merchant merchant)
        {
            if (x == merchant.X && y == merchant.Y)
            {
                merchant.CollectCoins(CoinsCollected);
                CoinsCollected = 0;
            }
        }
    }
}
