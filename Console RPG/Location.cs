using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public string name;
        public string description;
        public int level;
        public string option1;
        public string option2;
        public string option3;
        public string option4;
        public string option5;

        public Location north, east, south, west;

        public Location(string name, string description, int level,  string option1,  string option2,  string option3, string option4, string option5)
        {
            this.name = name;
            this.description = description;
            this.level = level;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
            this.option4 = option4;
            this.option5 = option5;
        }

        public void SetNearbyLocations(Location north, Location east, Location south, Location west)
        {
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;

            if(!(north is null))
                north.south = this;
            if(!(east is null))
                east.west = this;
            if(!(south is null))
                south.north = this;
            if(!(west is null))
                west.east = this;
        }
        public void Resolve()
        {

            Program.PrintLine($"You are at {this.name}, {this.description}.");
            Program.PrintLine($"What do you do, {name}?");
            Program.PrintLine(this.option1);
            Program.PrintLine(this.option2);
            Program.PrintLine(this.option3);
            Program.PrintLine(this.option4);
            Program.PrintLine(this.option5);

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

            nextlocation.Resolve();
        }
    }
}