using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Char_Creator
{
    class Stat
    {
        public string type;
        public int value;
        public bool locked;
        public Stat(string type, int value, bool locked = false)
        {
            this.type = type;
            this.value = value;
            this.locked = locked;
        }
        public string IsLocked()
        {
            string output;
            if (locked)
            {
                output = "X"; 
            } 
            else 
            { 
                output = " "; 
            }
            return output;
        }
    }
    class StatGroup
    {
        public Stat STR, DEX, CON, INT, WIS, CHA;
        public StatGroup(Stat[] stats)
        {
            STR = stats[0];
            DEX = stats[1];
            CON = stats[2];
            INT = stats[3];
            WIS = stats[4];
            CHA = stats[5];
        }
    }
}
