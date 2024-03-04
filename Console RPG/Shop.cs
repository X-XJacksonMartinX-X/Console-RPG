using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : Event
    {
        public string shopKeeperName;
        public List<Item> items;

        public Shop(string shopKeeperName, List<Item> items) : base(false)
        {
            this.shopKeeperName = shopKeeperName;
            this.items = items;
        }
        public override void Resolve(List<Player> players)
        {
            Program.PrintLine($"Welcome to {shopKeeperName}'s shop! Buy something, will ya?");
            Item item = ChooseItem(this.items);
            Player.coinCount -= item.shopPrice;
            Player.Inventory.Add(item);

            Program.PrintLine($"You bought: {item.name}");
        }
        public Item ChooseItem(List<Item> choices)
        {
            Program.PrintLine("Type in the item you want to use");
            for (int i = 0; i < choices.Count; i++)
            {
                Program.PrintLine($"{i + i}: {choices[i].name} ({choices[i].shopPrice})");
            }
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index-1];
        }
    }
}