using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Battle
    {
        public List<Enemy> enemies;
        public bool isResolved;

        public Battle(List<Enemy> enemies)
        {
            this.enemies = enemies;
            this.isResolved = false;
        }
        public void Resolve(List<Player> players)
        {
            // loop the turn system
            while (true)
            {
                // loop through all the players
                foreach (var item in players)
                {
                    Program.PrintLine($"It's {item.name}'s turn.");
                    item.DoTurn(players, enemies);
                }
                // if the players win
                if (enemies.TrueForAll(enemies => enemies.currentHP <= 0))
                {
                    Program.PrintLine("You win!");
                    break;
                }
                foreach (var item in enemies)
                {
                    Program.PrintLine($"It's {item.name}'s turn.");
                    item.DoTurn(players, enemies);
                }
                // if the players lose
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Program.PrintLine("Womp Womp, U died. :(");
                    break;
                }
            }
        }
    }
}