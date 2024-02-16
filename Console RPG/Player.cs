using System;
using System.Text;
using System.Collections.Generic;
namespace Console_RPG
{
    class Player : Entity
    {
        public Player(string name, int hp, int mana, Stats stats) : base(name, hp, mana, stats) { }
        public override void Attack(Entity target)
        {

        }
        public override Entity ChooseTarget(List<Entity> choices)
        {
            return choices[0];
        }

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
    }
}
