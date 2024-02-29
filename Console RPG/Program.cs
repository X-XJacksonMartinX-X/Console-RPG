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

            Location.playerHouse.SetNearbyLocations(Location.town, Location.brightWoods, null, null);
            Location.brightWoods.SetNearbyLocations(null, Location.darkWoods, null, Location.playerHouse);
            Location.town.SetNearbyLocations(null, null, Location.playerHouse, Location.theTree);
            Location.darkWoods.SetNearbyLocations(null, Location.lake, null, Location.brightWoods);
            Location.theTree.SetNearbyLocations(Location.town, null, null, null);



            PrintLine("Welcome to 'The Truth', a personality test + RPG. What is your name player?");
            string playerName = Console.ReadLine();
            PrintLine($"Hello {playerName}, it's great to finally meet you!");
            PrintLine("In this game you will go on a short journey, to find your truth, whatever it may be.");
            bool ready = false;
            bool Game = false;
            while (ready == false)
            {
                PrintLine($"Are you ready {playerName}?");
                string ifready = Console.ReadLine();
                ifready = ifready.ToLower();
                if (ifready == "yes" || ifready == "yeah" || ifready == "yep" || ifready == "sure")
                {
                    ready = true;
                }
                else if (ifready == "no" || ifready == "nope" || ifready == "not" || ifready == "nuh uh" || ifready == "nah")
                {
                    ready = false;
                    PrintLineOminous($"See you next time {playerName}...");
                    Thread.Sleep(500);
                    System.Environment.Exit(1);
                }
                else
                {
                    ready = false;
                    PrintLine($"Please enter a valid answer, {playerName} (yes or no).");
                }
            }
            if (ready == true)
            {
                Game = true;
                PrintLine("You awaken in your bed, looking around the walls are worn. You wonder the last time you ate, what do you do?");
            }
            while (Game == true)
            {
                Location.brightWoods.Resolve(new List<Player>() {Player.player});     
            }
        }

        public static void Print(string output)
        {
            if (output is null)
            {
                return;
            }

            for (int i = 0; i < output.Length; ++i)
            {


                Console.Write(output[i]);
                Thread.Sleep(10);
            }
        }
        public static void PrintLine(string output)
        {
            if(output is null)
            {
                return;
            }

            for (int i = 0; i < output.Length; ++i)
            {
                Console.Write(output[i]);
                Thread.Sleep(10);
            }

            Console.WriteLine();
        }
        public static void PrintLineOminous(string output)
        {
            if (output is null)
            {
                return;
            }

            for (int i = 0; i < output.Length; ++i)
            {
                Console.Write(output[i]);
                Thread.Sleep(1);

                if (i == output.Length - 1)
                {
                    Thread.Sleep(500);
                }
                if (i == output.Length - 2)
                {
                    Thread.Sleep(500);
                }
                if (i == output.Length - 3)
                {
                    Thread.Sleep(500);
                }
            }
            Console.WriteLine();
        }
    }
}