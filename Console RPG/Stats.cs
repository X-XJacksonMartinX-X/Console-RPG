using System;
using System.Text;
using System.Collections.Generic;
namespace Console_RPG
{
    struct Stats
    {
        public int attack;
        public int defense;
        public int magicAttack;
        public int magicDefense;

        public Stats(int attack, int defense, int magicAttack, int magicDefense)
        {
            this.attack = attack;
            this.defense = defense;
            this.magicAttack = magicAttack;
            this.magicDefense = magicDefense;
        }
    }
}