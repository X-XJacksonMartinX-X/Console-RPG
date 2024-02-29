using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace Console_RPG
{
    class Player : Entity
    {
        public static Player player = new Player("Player", 50, 20, new Stats(10, 10, 10, 10));


        public Player(string name, int hp, int mana, Stats stats) : base(name, hp, mana, stats) { }
        public override void Attack(Entity target)
        {
            Console.WriteLine($"{Player.player.name} attacked {target.name}!");
        }
        public override Entity ChooseTarget(List<Entity> choices)
        {
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} {choices[i].name}");
            }
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
            Attack(target);

        }
    }
}
