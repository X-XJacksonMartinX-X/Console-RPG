using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy slime = new Enemy("Slime", 50, 20, new Stats(10, 10, 10, 10), 15);
        public static Enemy wolf = new Enemy("Wolf", 50, 20, new Stats(10, 10, 10, 10), 15);
        public static Enemy dragon = new Enemy("Dragon", 50, 20, new Stats(10, 10, 10, 10), 15);

        public int EXPGiven;

        public Enemy(string name, int hp, int mana, Stats stats, int EXPGiven) : base(name, hp, mana, stats)
        {
            this.EXPGiven = EXPGiven;
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Random random = new Random();
            return choices[random.Next(0, choices.Count)];
        }

        public override void Attack(Entity target)
        {
            Console.WriteLine($"{this.name} attacked {target.name}!");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
