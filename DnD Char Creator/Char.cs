using System;

namespace DnD_Char_Creator
{
    class Char
    {
        static Random rnd = new Random();
        public bool isPlayer = false;
        public StatGroup stats;
        public string name, sex, species, residence, job, Class;
        public Personality appearance, talents, mannerisms;
        public Personality traits, flawsSecrets, neutralIdeal, otherIdeal;
        public Personality[] lawIdeals, alignmentIdeals, bonds;

        public Char(bool isPlayer = false)
        {
            this.isPlayer = isPlayer;
        }
        public void SetStats(StatGroup stats)
        {
            this.stats = stats;
        }
        public void SetDetails(string[] details)
        {
            name = details[0];
            sex = details[1];
            species = details[2];
            residence = details[3];
            Class = details[4];
            job = details[5];
        }
        public void SetPers(Personality[] persArray)
        {
            appearance = persArray[0];
            talents = persArray[1];
            mannerisms = persArray[2];
            traits = persArray[3];
            flawsSecrets = persArray[4];
            neutralIdeal = persArray[5];
            otherIdeal = persArray[6];
        }
        public void SetPersArrays(Personality[,] input) //Personality[] lawIdeals, Personality[] alignmentIdeals, Personality[] bonds)
        {
            lawIdeals = new Personality[] { input[0, 0], input[0, 1] };
            alignmentIdeals = new Personality[] { input[1, 0], input[1, 1] };
            bonds = new Personality[] { input[2, 0], input[2, 1] };
        }
        public static string GetTown()
        {
            return "Not implemented (me and josh gotta make towns first)";
            /*int ID = rnd.Next(1, 101);
            double math = 175 / (ID + 16);
            switch ((int)(math))
            {
                case 1:
                    return "Vrever";
                case 2:
                    return "Northam";
                case 3:
                    return "Mournstead";
                case 4:
                    return "Thesvons";
                case 5:
                    return "Jolborg";
                case 6:
                    return "Sarton";
                case 7:
                    return "Westbourne";
                case 8:
                    return "Howe";
                case 9:
                    return "Cirrane";
                case 10:
                    return "Snowbush";
            }
            throw new Exception("GenTown");*/
        }
        public static string GetSex()
        {
            int ID = rnd.Next(1, 3);
            switch (ID)
            {
                case 1:
                    return "Male";
                case 2:
                    return "Female";
            }
            throw new Exception("Sex");
        }
        public static string GetSpecies()
        {
            int ID = rnd.Next(1, 101);
            double math = 13.9 * Math.Pow(0.93632, ID) + 1;
            switch ((int)math)
            {
                case 1:
                    return "Human";
                case 2:
                    return "Elf";
                case 3:
                    return "Dwarf";
                case 4:
                    return "Halfling";
                case 5:
                    return "Half Elf";
                case 6:
                    return "Gnome";
                case 7:
                    return "Goliath";
                case 8:
                    return "Tiefling";
                case 9:
                    return "Orc";
                case 10:
                    return "Centaur";
                case 11:
                    return "Goblin";
                case 12:
                    return "Half Orc";
                case 13:
                    return "Luxodon";
                case 14:
                    return "Minotaur";
            }
            throw new Exception("Species");
        }
        public static string GetJob()
        {
            int ID = rnd.Next(1, 14);
            switch (ID)
            {
                case 1:
                    return "Labourer";
                case 2:
                    return "Guard";
                case 3:
                    return "Farmer";
                case 4:
                    return "Doctor";
                case 5:
                    return "Woodcutter";
                case 6:
                    return "Barkeep";
                case 7:
                    return "Mason";
                case 8:
                    return "Carpenter";
                case 9:
                    return "Tailor";
                case 10:
                    return "Smith";
                case 11:
                    return "Merchant";
                case 12:
                    return "Teacher";
                case 13:
                    return "Judge";
            }
            throw new Exception("Job");
        }
        public static string GetClass()
        {
            int ID = rnd.Next(1,14);
            switch (ID)
            {
                case 1:
                    return "Artificer";
                case 2:
                    return "Barbarian";
                case 3:
                    return "Bard";
                case 4:
                    return "Cleric";
                case 5:
                    return "Druid";
                case 6:
                    return "Fighter";
                case 7:
                    return "Monk";
                case 8:
                    return "Paladin";
                case 9:
                    return "Ranger";
                case 10:
                    return "Rogue";
                case 11:
                    return "Sorcerer";
                case 12:
                    return "Warlock";
                case 13:
                    return "Wizard";
            }
            throw new Exception("Class");
        }
    }
}
