using System;

namespace DnD_Char_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programLoop = true;
            while (true)
            {
                Char character;
                bool isPlayer = false;
                while (true)
                {
                    Console.WriteLine("Please note that this Program is case sensitive");
                    Console.WriteLine();
                    Console.WriteLine("Are you creating a player character? (Y|n)");

                    string input = Console.ReadLine();
                    if (input == "Y" || input == "n")
                    {
                        switch (input)
                        {
                            case "Y":
                                isPlayer = true;
                                break;
                            case "n":
                                isPlayer = false;
                                break;
                        }
                        break;
                    }
                    Console.Clear();
                }// check for NPC
                character = new Char(isPlayer);
                StatGroup preStats = Stat.MakeStats();
                bool statLoop = true;
                while (statLoop)
                {
                    Console.Clear();
                    Console.WriteLine(DisplayStats(preStats));
                    Console.WriteLine("\n\nType numbers from (1) to (6) to Prevent stats from being rerolled (X for locked)");
                    Console.WriteLine("Type (C) to Cancel, type (F) to finish and save stats, type (R) to reroll");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (preStats.STR.locked)
                            {
                                preStats.STR.locked = false;
                            }
                            else
                            {
                                preStats.STR.locked = true;
                            }
                            break;
                        case "2":
                            if (preStats.DEX.locked)
                            {
                                preStats.DEX.locked = false;
                            }
                            else
                            {
                                preStats.DEX.locked = true;
                            }
                            break;
                        case "3":
                            if (preStats.CON.locked)
                            {
                                preStats.CON.locked = false;
                            }
                            else
                            {
                                preStats.CON.locked = true;
                            }
                            break;
                        case "4":
                            if (preStats.INT.locked)
                            {
                                preStats.INT.locked = false;
                            }
                            else
                            {
                                preStats.INT.locked = true;
                            }
                            break;
                        case "5":
                            if (preStats.WIS.locked)
                            {
                                preStats.WIS.locked = false;
                            }
                            else
                            {
                                preStats.WIS.locked = true;
                            }
                            break;
                        case "6":
                            if (preStats.CHA.locked)
                            {
                                preStats.CHA.locked = false;
                            }
                            else
                            {
                                preStats.CHA.locked = true;
                            }
                            break;
                        case "F":
                            statLoop = false;
                            break;
                        case "C":
                            statLoop = false;
                            programLoop = false;
                            break;
                        case "R":
                            if (!preStats.STR.locked)
                            {
                                preStats.STR = Stat.MakeStat("STR");
                            }
                            if (!preStats.DEX.locked)
                            {
                                preStats.DEX = Stat.MakeStat("DEX");
                            }
                            if (!preStats.CON.locked)
                            {
                                preStats.CON = Stat.MakeStat("CON");
                            }
                            if (!preStats.INT.locked)
                            {
                                preStats.INT = Stat.MakeStat("INT");
                            }
                            if (!preStats.WIS.locked)
                            {
                                preStats.WIS = Stat.MakeStat("WIS");
                            }
                            if (!preStats.CHA.locked)
                            {
                                preStats.CHA = Stat.MakeStat("CHA");
                            }
                            break;
                        case "Josh":
                            preStats.STR.value = 18;
                            preStats.DEX.value = 18;
                            preStats.CON.value = 18;
                            preStats.INT.value = 18;
                            preStats.WIS.value = 18;
                            preStats.CHA.value = 18;
                            break;
                    }
                }// make Stats
                if (!programLoop)
                {
                    break;
                }
                character.SetStats(preStats);
                bool detailLoop = true;
                while (detailLoop)
                {
                    Console.Clear();
                    Console.Write("Please insert your character's name: ");
                    string name = Console.ReadLine();
                    Console.Write("Is your character Male (1) or Female (2)? (R) for Random: ");
                    string gender = Console.ReadLine();
                    if (gender == "1") { gender = "Male"; }
                    else if (gender == "2") { gender = "Female"; }
                    else if (gender == "R") { gender = Char.GetSex(); }
                    else throw new Exception("Gender");
                    Console.Write("What Species is your character? (R) for Random: ");
                    string species = Console.ReadLine();
                    if (species == "R") { species = Char.GetSpecies(); }
                    Console.Write("What is your character's hometown? (R) for Random: ");
                    string homeTown = Console.ReadLine();
                    if (homeTown == "R") { homeTown = Char.GetTown(); }
                    Console.Write("What is your character's Class? (R) For Random, (0) for classless");
                    string Class = Console.ReadLine();
                    if (Class == "R") { Class = Char.GetClass(); } else if (Class == "0") { Class = "None"; }
                    Console.Write("What is your character's Job?\n(R) for Random, (0) for Unemployed, \"Student\" for Student: ");
                    string job = Console.ReadLine();
                    if (job == "R") { job = Char.GetJob(); } else if (job == "0") { job = "Unemployed"; }
                    bool[] locks = { false, false, false, false, false, false };
                    while (true)
                    {
                        DisplayDetails(name, gender, species, homeTown, Class, job, locks);
                    }
                }
                bool personalityLoop = true;
                while (personalityLoop)
                {
                    Console.Clear();

                    string input = Console.ReadLine();

                } // make personality and appearance
                if (!programLoop)
                {
                    break;
                }
            }
        }
        static string DisplayStats(StatGroup stats)
        {
            string output = "";

            output += "1 | " + stats.STR.IsLocked() + " | STR: " + stats.STR.value + "\n";
            output += "2 | " + stats.DEX.IsLocked() + " | DEX: " + stats.DEX.value + "\n";
            output += "3 | " + stats.CON.IsLocked() + " | CON: " + stats.CON.value + "\n";
            output += "4 | " + stats.INT.IsLocked() + " | INT: " + stats.INT.value + "\n";
            output += "5 | " + stats.WIS.IsLocked() + " | WIS: " + stats.WIS.value + "\n";
            output += "6 | " + stats.CHA.IsLocked() + " | CHA: " + stats.CHA.value + "\n";

            return output;
        }
        static string DisplayDetails(string name, string sex, string species, string residence, string Class, string job, bool[] locks)
        {
            string[] locks2 = new string[6];
            for (int i = 0; i < 6; i++)
            {
                if (locks[i]) { locks2[i] = "X"; } else locks2[i] = " ";
            }
            string a = "";
            int i = 0;
            a += "| " + locks2[i] + " | Name: " + name + "\n";i++;
            a += "| " + locks2[i] + " | Sex: " + sex + "\n"; i++;
            a += "| " + locks2[i] + " | Species: " + species + "\n"; i++;
            a += "| " + locks2[i] + " | Home Town: " + residence + "\n"; i++;
            a += "| " + locks2[i] + " | Class: " + Class + "\n"; i++;
            a += "| " + locks2[i] + " | Job: " + job;
            return a;
        }
    }
}
