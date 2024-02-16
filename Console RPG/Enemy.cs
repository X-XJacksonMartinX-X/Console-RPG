using System;
using System.Text;
using System.Collections.Generic;
namespace Console_RPG
{
    class Enemy : Entity
    {
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

    }
}
