using System;
using System.Threading;

namespace Rogue
{
    class Game
    {
        //Niezbędne obiekty

        private Map map;
        private Player player;
        private Enemy[] enemies;

        //Ustalenie startowej pozycji gracza i wrogów

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
        }


        //Uruchomienie gry i stworzenie planszy z wrogami oraz graczem

        public void Run()
        {
            Console.Clear();
            map.Draw();
            player.Draw();
            foreach (var enemy in enemies)
            {
                enemy.Draw();
            }

        //Rysowanie mapy jeszcze raz z nowymi pozycjami gracza i wrogów jeśli gracz sie poruszył
        
            while (true)
            {
                bool playerMoved = player.Move(map);

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
                }
            }
        }
    }
}
