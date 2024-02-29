using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {

        public static Location playerHouse = new Location("Home", "The house you grew up in.", 0, "Make some food", "Go back to bed", "Read a book", "Look Outside", null);
        public static Location brightWoods = new Location("The Bright Woods", "You've been lost in here before...", 1, "Kick a tree", "", "", "", "", new Battle(new List<Enemy>() { Enemy.slime }));
        public static Location darkWoods = new Location("The woods", "Your mother told you to never go this deep...", 2, "", "", "", "", "", new Battle(new List<Enemy>() { Enemy.wolf, Enemy.slime }));
        public static Location town = new Location("The town", "You go there for food, and supplies sometimes...", 0, "", "", "", "", "");
        public static Location theTree = new Location("The Tree", "A large Mahogany tree,  atop a small hill..", 0, "", "", "", "", "");
        public static Location lake = new Location("The Lake", "A large lake at the end of the woods.", 0, "", "", "", "", "", new Battle(new List<Enemy>() { Enemy.dragon }));

        
        public string name;
        public string description;
        public int level;
        public string option1;
        public string option2;
        public string option3;
        public string option4;
        public string option5;
        public Battle battle;

        public Location north, east, south, west;

        public Location(string name, string description, int level,  string option1,  string option2,  string option3, string option4, string option5, Battle battle = null)
        {
            this.name = name;
            this.description = description;
            this.level = level;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
            this.option4 = option4;
            this.option5 = option5;
            this.battle = battle;
        }

        public void SetNearbyLocations(Location north, Location east, Location south, Location west)
        {
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;

            if(!(north is null))
            {
                this.north = north;
                north.south = this;
            }
            if(!(east is null))
            {
                this.east = east;
                east.west = this;
            }
            if(!(south is null))
            {
                this.south = south;
                south.north = this;
            }
            if(!(west is null))
            {
                this.west = west;
                west.east = this;
            }
        }
        public void Resolve(List<Player> players)
        {

            Program.PrintLine($"You are at {this.name}, {this.description}.");
            Program.PrintLine($"What do you do, {Player.player.name}?");
            Program.PrintLine(this.option1);
            Program.PrintLine(this.option2);
            Program.PrintLine(this.option3);
            Program.PrintLine(this.option4);
            Program.PrintLine(this.option5);

            if(!(battle is null))
            battle.Resolve(players);

            if (!(this.north is null))
                Console.WriteLine($"North: {this.north.name}");
            if (!(this.east is null))
                Console.WriteLine($"East: {this.east.name}");
            if (!(this.south is null))
                Console.WriteLine($"South: {this.south.name}");
            if (!(this.west is null))
                Console.WriteLine($"West: {this.west.name}");

            string direction = Console.ReadLine();
            direction = direction.ToLower();
            Location nextlocation = null;

            if (direction == "north")
                nextlocation = this.north;
            if (direction == "east")
                nextlocation = this.east;
            if (direction == "south")
                nextlocation = this.south;
            if (direction == "west")
                nextlocation = this.west;

            nextlocation.Resolve(players);
        }
    }
}