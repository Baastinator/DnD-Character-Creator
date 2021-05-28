using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD_Char_Creator;

namespace DnD_Char_Creator
{
    class Stat
    {
        static Random rnd = new Random();
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
        public static StatGroup MakeStats()
        {
            Stat[] stats = new Stat[6];
            stats[0] = MakeStat("STR");
            stats[1] = MakeStat("DEX");
            stats[2] = MakeStat("CON");
            stats[3] = MakeStat("INT");
            stats[4] = MakeStat("WIS");
            stats[5] = MakeStat("CON");
            StatGroup output = new StatGroup(stats);
            return output;
        }
        public static Stat MakeStat(string type)
        {
            int[] num = new int[4];
            for (int i = 0; i < 4; i++)
            {
                num[i] = DSix();
            }
            Array.Sort(num);
            int statValue = num[1] + num[2] + num[3];
            Stat output = new Stat(type, statValue);
            return output;
        }
        public static int DSix()
        {
            return rnd.Next(1, 7);
        }
    }
    class StatGroup
    {
        public Stat STR { get; set; }
        public Stat DEX { get; set; }
        public Stat CON { get; set; }
        public Stat INT { get; set; }
        public Stat WIS { get; set; }
        public Stat CHA { get; set; }
        public StatGroup(Stat[] stats)
        {
            STR = stats[0];
            DEX = stats[1];
            CON = stats[2];
            INT = stats[3];
            WIS = stats[4];
            CHA = stats[5];
        }
        public Stat[] GetStats()
        {
            Stat[] output = new Stat[6];
            output[0] = STR;
            output[1] = DEX;
            output[2] = CON;
            output[3] = INT;
            output[4] = WIS;
            output[5] = CHA;
            return output;
        }
        public string GetStatString()
        {
            string[] statNums = new string[6];
            Stat[] statArray = GetStats();
            for (int i = 0; i < 6; i++)
            {
                if (statArray[i].value >= 10)
                {
                    statNums[i] = Convert.ToString(statArray[i].value);
                } else
                {
                    statNums[i] = Convert.ToString(statArray[i].value) + " ";
                }
            }
            string a = "";
            a += "| STR | DEX | CON | INT | WIS | CHA |\n";
            a += "|  " + statNums[0] + " |  " + statNums[1] + " |  " + statNums[2] + " |  ";
            a += statNums[3] + " |  " + statNums[4] + " |  " + statNums[5] + " |";
            return a;
        }
    }
    class Personality
    {
        public bool locked;
        public string name;
        static Random rdm = new Random();
        public Personality(string name, bool locked = false)
        {
            this.locked = locked;
            this.name = name;
        }
        public static Personality GenPers(int ID)
        {
            switch (ID)
            {
                case 1:
                    return App();
                case 2:
                    return Tal();
                case 3:
                    return Man();
                case 4:
                    return Tra();
                case 5:
                    return Fla();
                case 6:
                    return Neu();
                case 7:
                    return Oth();
            }
            throw new Exception("Pers");
        }
        public static Personality[] GetPersonalities()
        {
            Personality[] output = new Personality[7];
            output[0] = App();
            output[1] = Tal();
            output[2] = Man();
            output[3] = Tra();
            output[4] = Fla();
            output[5] = Neu();
            output[6] = Oth();
            return output;
        }
        public static Personality GetArrayPers(int ID)
        {
            switch (ID)
            {
                case 1:
                    return Law();
                case 2:
                    return Ali();
                case 3:
                    return Bon();
            }
            throw new Exception("ArrayPers");
        }
        public static Personality[,] GetArrayPersonalities()
        {
            Personality[,] output = new Personality[3, 2];
            output[0, 0] = Law(); output[0, 1] = Law();
            output[1, 0] = Ali(); output[1, 1] = Ali();
            output[2, 0] = Bon(); output[2, 1] = Bon();
            return output;
        }
        public static Personality[,] ChangeArrayPersonalities(Personality[,] old, int x, int y)
        {
            switch (x)
            {
                case 1:
                    old[0, y - 1] = Law();
                    return old;
                case 2:
                    old[1, y - 1] = Ali();
                    return old;
                case 3:
                    old[2, y - 1] = Bon();
                    return old;
            }
            throw new Exception("ChangeArrayPersonalities");
        }
        static Personality App()
        {
            int ID = NumGen(18);
            switch (ID)
            {
                case 1:
                    return new Personality("Jewelry");
                case 2:
                    return new Personality("Piercings");
                case 3:
                    return new Personality("Flamboyant");
                case 4:
                    return new Personality("Formal");
                case 5:
                    return new Personality("Ragged");
                case 6:
                    return new Personality("Scarred");
                case 7:
                    return new Personality("Missing Teeth");
                case 8:
                    return new Personality("Missing Fingers");
                case 9:
                    return new Personality("Heterochromia");
                case 10:
                    return new Personality("Tattoos");
                case 11:
                    return new Personality("Birthmark");
                case 12:
                    return new Personality("Bald");
                case 13:
                    return new Personality("Unusual hair color");
                case 14:
                    return new Personality("Nervous eye twitch");
                case 15:
                    return new Personality("Destinctive nose");
                case 16:
                    return new Personality("Crooked posture");
                case 17:
                    return new Personality("Beautiful");
                case 18:
                    return new Personality("Ugly");
            }
            throw new Exception("App");
        }
        static Personality Tal()
        {
            int ID = NumGen(20);
            switch (ID)
            {
                case 1:
                    return new Personality("Plays instruments");
                case 2:
                    return new Personality("Speaks multiple Languages");
                case 3:
                    return new Personality("Very lucky");
                case 4:
                    return new Personality("Perfect memory");
                case 5:
                    return new Personality("Great with animals");
                case 6:
                    return new Personality("Great with children");
                case 7:
                    return new Personality("Solving Puzzles");
                case 8:
                    return new Personality("Great at one game");
                case 9:
                    return new Personality("Impersonations");
                case 10:
                    return new Personality("Draws beautifully");
                case 11:
                    return new Personality("Paints beautifully");
                case 12:
                    return new Personality("Sings beautifully");
                case 13:
                    return new Personality("Great drinker");
                case 14:
                    return new Personality("Expert carpenter");
                case 15:
                    return new Personality("Expert Cook");
                case 16:
                    return new Personality("Expert dart thrower");
                case 17:
                    return new Personality("Expert juggler");
                case 18:
                    return new Personality("Skilled actor");
                case 19:
                    return new Personality("Skilled dancer");
                case 20:
                    return new Personality("Knows thieves' cant");
            }
            throw new Exception("Tal");
        }
        static Personality Man()
        {
            int ID = NumGen(16);
            switch (ID)
            {
                case 1:
                    return new Personality("Sings randomly");
                case 2:
                    return new Personality("Low or High tone of voice");
                case 3:
                    return new Personality("Slurs words");
                case 4:
                    return new Personality("Speaks loudly");
                case 5:
                    return new Personality("Speaks quietly");
                case 6:
                    return new Personality("Uses wrong words often");
                case 7:
                    return new Personality("Uses Colorful exclamations");
                case 8:
                    return new Personality("Makes jokes");
                case 9:
                    return new Personality("Makes predictions of doom");
                case 10:
                    return new Personality("Fidgets");
                case 11:
                    return new Personality("Squints");
                case 12:
                    return new Personality("Stares into the middle distance");
                case 13:
                    return new Personality("Chews something");
                case 14:
                    return new Personality("Taps fingers");
                case 15:
                    return new Personality("Bites fingernails");
                case 16:
                    return new Personality("Twirls hair or tugs beard");
            }
            throw new Exception("Man");
        }
        static Personality Tra()
        {
            int ID = NumGen(12);
            switch (ID)
            {
                case 1:
                    return new Personality("Argumentative");
                case 2:
                    return new Personality("Arrogant");
                case 3:
                    return new Personality("Noisy");
                case 4:
                    return new Personality("Rude");
                case 5:
                    return new Personality("Curious");
                case 6:
                    return new Personality("Friendly");
                case 7:
                    return new Personality("Honest");
                case 8:
                    return new Personality("Hot Tempered");
                case 9:
                    return new Personality("Irritatable");
                case 10:
                    return new Personality("Ponderous");
                case 11:
                    return new Personality("Quiet");
                case 12:
                    return new Personality("Suspicious");
            }
            throw new Exception("Tra");
        }
        static Personality Fla()
        {
            int ID = NumGen(12);
            switch (ID)
            {
                case 1:
                    return new Personality("Forbidden Love");
                case 2:
                    return new Personality("Addiction");
                case 3:
                    return new Personality("Arrogance");
                case 4:
                    return new Personality("Envy");
                case 5:
                    return new Personality("Greed");
                case 6:
                    return new Personality("Prone to rage");
                case 7:
                    return new Personality("Powerful enemy");
                case 8:
                    return new Personality("Specific phobia");
                case 9:
                    return new Personality("Scandalous history");
                case 10:
                    return new Personality("Secret crime");
                case 11:
                    return new Personality("knows Forbidden lore");
                case 12:
                    return new Personality("Foolhardy");
            }
            throw new Exception("Fla");
        }
        static Personality Neu()
        {
            int ID = NumGen(6);
            switch (ID)
            {
                case 1:
                    return new Personality("Balance");
                case 2:
                    return new Personality("Knowledge");
                case 3:
                    return new Personality("Live and let live");
                case 4:
                    return new Personality("Moderation");
                case 5:
                    return new Personality("Neutrality");
                case 6:
                    return new Personality("People");
            }
            throw new Exception("Neu");
        }
        static Personality Oth()
        {
            int ID = NumGen(6);
            switch (ID)
            {
                case 1:
                    return new Personality("Aspiration");
                case 2:
                    return new Personality("Discovery");
                case 3:
                    return new Personality("Glory");
                case 4:
                    return new Personality("Nation");
                case 5:
                    return new Personality("Redemption");
                case 6:
                    return new Personality("Self-Knowledge");
            }
            throw new Exception("Oth");
        }
        static Personality Law()
        {
            int ID = NumGen(12);
            switch (ID)
            {
                case 1:
                    return new Personality("Community");
                case 2:
                    return new Personality("Fairness");
                case 3:
                    return new Personality("Honor");
                case 4:
                    return new Personality("Logic");
                case 5:
                    return new Personality("Responsiblity");
                case 6:
                    return new Personality("Tradition");
                case 7:
                    return new Personality("Change");
                case 8:
                    return new Personality("Creativity");
                case 9:
                    return new Personality("Freedom");
                case 10:
                    return new Personality("Independence");
                case 11:
                    return new Personality("No limits");
                case 12:
                    return new Personality("Whimsy");
            }
            throw new Exception("Tra");
        }
        static Personality Ali()
        {
            int ID = NumGen(12);
            switch (ID)
            {
                case 1:
                    return new Personality("Beauty");
                case 2:
                    return new Personality("Charity");
                case 3:
                    return new Personality("Greater Good");
                case 4:
                    return new Personality("Life");
                case 5:
                    return new Personality("Respect");
                case 6:
                    return new Personality("Self secrafice");
                case 7:
                    return new Personality("Domination");
                case 8:
                    return new Personality("Greed");
                case 9:
                    return new Personality("Might");
                case 10:
                    return new Personality("Pain");
                case 11:
                    return new Personality("Retribution");
                case 12:
                    return new Personality("Slaughter");
            }
            throw new Exception("Ali");
        }
        static Personality Bon()
        {
            int ID = NumGen(9);
            switch (ID)
            {
                case 1:
                    return new Personality("Life goal");
                case 2:
                    return new Personality("Family member");
                case 3:
                    return new Personality("Comrades");
                case 4:
                    return new Personality("Patron");
                case 5:
                    return new Personality("Romantic interest");
                case 6:
                    return new Personality("Place");
                case 7:
                    return new Personality("Keepsake");
                case 8:
                    return new Personality("Valuable possession");
                case 9:
                    return new Personality("Out for revenge");
            }
            throw new Exception("Bon");
        }
        public static int NumGen(int bound)
        {
            return rdm.Next(1, bound+1);
        }
    }
}
 