using System;
using System.Text;
using System.Collections.Generic;
namespace Console_RPG
{
    class HealthPotionItem : Item
    {
        public static HealthPotionItem potion1 = new HealthPotionItem("Potion I", "It'll quench ya", 20, 10, 10);
        public static HealthPotionItem potion2 = new HealthPotionItem("Potion II", "It'll quench ya", 50, 20, 20);
        public static HealthPotionItem potion3 = new HealthPotionItem("Potion III", "It'll quench ya", 100, 40, 50);


        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int sellPrice, int healAmount) : base(name, description, shopPrice, sellPrice)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP += this.healAmount;
            Console.WriteLine($"{target.name} was healed!");
        }
    }
}
