using System;
using System.Threading;

namespace Rogue
{
    class Game
    {
        private Map map;
        private Player player;
        private Enemy[] enemies;
        private Coin[] coins;
        private Merchant merchant;

        public Game()
        {
            map = new Map();
            player = new Player(1, 1);
            enemies = new Enemy[]
            {
                new Enemy(2, 8),
                new Enemy(18, 7),
                new Enemy(6, 6)
            };
            coins = new Coin[] 
            {
                new Coin(4, 3),
                new Coin(10, 6),
                new Coin(15, 8)
            };
            merchant = new Merchant(10, 1);
        }

        public void Run()
        {
            Console.Clear();
            map.Draw();
            player.Draw();
            foreach (var enemy in enemies)
            {
                enemy.Draw();
            }
            foreach (var coin in coins)
            {
                coin.Draw();
            }
            merchant.Draw();
            DrawCoinCount();

            while (true)
            {
                bool playerMoved = player.Move(map, coins, merchant);

                if (playerMoved)
                {
                    Console.Clear();
                    map.Draw();
                    player.Draw();
                    foreach (var enemy in enemies)
                    {
                        enemy.Move(map);
                        enemy.Draw();
                    }
                    foreach (var coin in coins)
                    {
                        if (!coin.Collected)
                        {
                            coin.Draw();
                        }
                    }
                    merchant.Draw();
                    DrawCoinCount();
                }

                if (merchant.TotalCoinsCollected == coins.Length)
                {
                    EndGame();
                    break;
                }

                Thread.Sleep(100);
            }
        }





        private void DrawCoinCount()
        {
            Console.SetCursorPosition(0, map.MapHeight + 1);
            Console.Write($"Coins Collected: {player.CoinsCollected}");
        }



        private void EndGame()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game Over!");
        }
    }
}
