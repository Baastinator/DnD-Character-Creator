using System;

namespace DnD_Char_Creator
{
    class Char
    {
        static Random rnd = new Random();
        public bool isPlayer = false;
        public StatGroup stats;
        public string name, sex, species, appearance, talents, mannerisms, traits, flawsSecrets, neutralIdeal, otherIdeal;
        public string residence, job, Class;
        public string[] lawIdeals, alignmentIdeals, bonds;

        public Char(bool isPlayer = false)
        {
            this.isPlayer = isPlayer;
        }
        public void SetStats(StatGroup stats)
        {
            this.stats = stats;
        }
        public void SetDetails(string name, string sex, string species, string residence, string Class, string job)
        {
            this.name = name;
            this.sex = sex;
            this.species = species;
            this.residence = residence;
            this.Class = Class;
            this.job = job;
        }
        public void SetPersonality(string appearance, string talents, string mannerisms, string traits, string flawsSecrets, string[] bonds)
        {
            this.appearance = appearance;
            this.talents = talents;
            this.mannerisms = mannerisms;
            this.traits = traits;
            this.flawsSecrets = flawsSecrets;
            this.bonds = bonds;
        }
        public void SetIdeals(string[] lawIdeals, string[] alignmentIdeals, string neutralIdeal, string otherIdeal)
        {
            this.lawIdeals = lawIdeals;
            this.alignmentIdeals = alignmentIdeals;
            this.neutralIdeal = neutralIdeal;
            this.otherIdeal = otherIdeal;
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
}
