using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Player 1", 50, 20, new Stats(10, 10, 10, 10));
            Enemy enemy = new Enemy("Slime", 50, 20, new Stats(10, 10, 10, 10), 15);
            HealthPotionItem potion1 = new HealthPotionItem("Potion I", "It'll quench ya", 20, 10, 10);
            HealthPotionItem potion2 = new HealthPotionItem("Potion II", "It'll quench ya", 50, 20, 20);
            HealthPotionItem potion3 = new HealthPotionItem("Potion III", "It'll quench ya", 100, 40, 50);



            Location playerHouse = new Location("Your house", "The house you grew up in.", 0);
            Location brightWoods = new Location("The Bright Woods", "You've been lost in there before...", 1);
            Location darkWoods = new Location("The woods", "Your mother told you to never go this deep...", 2);
            Location town = new Location("The town", "You go there for food, and supplies sometimes...", 0);
            Location theTree = new Location("The Tree", "A large Mahogany tree,  atop a small hill..", 0);
            Location lake = new Location("The Lake", "A large lake at the end of the woods.", 0);

            playerHouse.SetNearbyLocations(town, brightWoods, null, null);
            brightWoods.SetNearbyLocations(null, darkWoods, null, playerHouse);
            town.SetNearbyLocations(null, null, playerHouse, theTree);
            darkWoods.SetNearbyLocations(null, lake, null, brightWoods);
            theTree.SetNearbyLocations(town, null, null, null);



            PrintLine("Welcome to 'The Truth', a personality test + RPG. What is your name player?");
            string name = Console.ReadLine();
            PrintLine($"Hello {name}, it's great to finally meet you!");
            PrintLine("In this game you will go on a short journey, to find your truth, whatever it may be.");
            bool ready = false;
            bool Game = false;
            while (ready == false)
            {
                PrintLine($"Are you ready {name}?");
                string ifready = Console.ReadLine();
                ifready = ifready.ToLower();
                if (ifready == "yes" || ifready == "yeah" || ifready == "yep" || ifready == "sure")
                {
                    ready = true;
                }
                else if (ifready == "no" || ifready == "nope" || ifready == "not" || ifready == "nuh uh" || ifready == "nah")
                {
                    ready = false;
                    PrintLine($"See you next time {name}...");
                    Thread.Sleep(2000);
                    System.Environment.Exit(1);
                }
                else
                {
                    ready = false;
                    PrintLine($"Please enter a valid answer, {name} (yes or no).");
                }
            }
            if (ready == true)
            {
                Game = true;
            }
            while (Game == true)
            {
                
            }
        }

        public static void Print(string output)
        {
            for (int i = 0; i < output.Length; ++i)
            {
                Console.Write(output[i]);
                Thread.Sleep(10);
            }
        }
        public static void PrintLine(string output)
        {
            for (int i = 0; i < output.Length; ++i)
            {
                Console.Write(output[i]);
                Thread.Sleep(10);
            }

            Console.WriteLine();
        }
    }
}