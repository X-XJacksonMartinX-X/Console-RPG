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

        public Location north, east, south, west;

        public Location(string name, string description, int level)
        {
            this.name = name;
            this.description = description;
            this.level = level;
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