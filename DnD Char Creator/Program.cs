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
                StatGroup preStats = Char.MakeStats();
                bool statLoop = true;
                while (statLoop)
                {
                    Console.Clear();
                    Console.WriteLine(DisplayStats(preStats));
                    Console.WriteLine("\n\nType numbers from 1 to 6 to Prevent stats from being rerolled");
                    Console.WriteLine("Type C to Cancel, type F to finish stat creation, type R to reroll");
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
                                preStats.STR = Char.MakeStat("STR");
                            }
                            if (!preStats.DEX.locked)
                            {
                                preStats.DEX = Char.MakeStat("DEX");
                            }
                            if (!preStats.CON.locked)
                            {
                                preStats.CON = Char.MakeStat("CON");
                            }
                            if (!preStats.INT.locked)
                            {
                                preStats.INT = Char.MakeStat("INT");
                            }
                            if (!preStats.WIS.locked)
                            {
                                preStats.WIS = Char.MakeStat("WIS");
                            }
                            if (!preStats.CHA.locked)
                            {
                                preStats.CHA = Char.MakeStat("CHA");
                            }
                            break;
                    }
                }// make Stats
                if (!programLoop)
                {
                    break;
                }
                character.SetStats(preStats);
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
    }
}
