using System;
using System.IO;

namespace DnD_Char_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programLoop = true;
            bool isPlayer = false;
            StatGroup preStats = Stat.MakeStats();
            string[] details = new string[6];
            Personality[] persArray = new Personality[7];
            Personality[,] persArrayArray = new Personality[3, 2];
            Char character;
            while (true)
            {
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
                } // check for NPC
                character = new Char(isPlayer);
                bool statLoop = true;
                while (statLoop)
                {
                    Console.Clear();
                    Console.WriteLine(DisplayStats(preStats));
                    Console.WriteLine("\n\nType numbers from (1) to (6) to Prevent stats from being rerolled (X for locked)");
                    Console.WriteLine("Type (C) to Cancel, type (F) to finish and save stats, type (S) to finish rolling and switch stats, type (R) to reroll");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1": if (preStats.STR.locked) preStats.STR.locked = false; else preStats.STR.locked = true; break;
                        case "2": if (preStats.DEX.locked) preStats.DEX.locked = false; else preStats.DEX.locked = true; break;
                        case "3": if (preStats.CON.locked) preStats.CON.locked = false; else preStats.CON.locked = true; break;
                        case "4": if (preStats.INT.locked) preStats.INT.locked = false; else preStats.INT.locked = true; break;
                        case "5": if (preStats.WIS.locked) preStats.WIS.locked = false; else preStats.WIS.locked = true; break;
                        case "6": if (preStats.CHA.locked) preStats.CHA.locked = false; else preStats.CHA.locked = true; break;
                        case "F": statLoop = false; break; case "C": statLoop = false; programLoop = false; break;
                        case "R":
                            if (!preStats.STR.locked) preStats.STR = Stat.MakeStat("STR");
                            if (!preStats.DEX.locked) preStats.DEX = Stat.MakeStat("DEX");
                            if (!preStats.CON.locked) preStats.CON = Stat.MakeStat("CON");
                            if (!preStats.INT.locked) preStats.INT = Stat.MakeStat("INT");
                            if (!preStats.WIS.locked) preStats.WIS = Stat.MakeStat("WIS");
                            if (!preStats.CHA.locked) preStats.CHA = Stat.MakeStat("CHA");
                            break;
                        case "S":
                            Stat[] tempStats = preStats.GetStats();
                            while (statLoop)
                            {
                                Console.Clear();
                                Console.Write(DisplayStats(new StatGroup(tempStats)));
                                Console.Write("Type (F) for Finish, (C) to Cancel\n");
                                Console.Write("Type a number to select: ");
                                string input1 = Console.ReadLine();
                                if (input1 == "F") statLoop = false;
                                else if (input1 == "C") { statLoop = false; programLoop = false; }
                                else
                                {
                                    int selNum = Convert.ToInt32(input1);
                                    Console.Write("Type a number to swap the selected with: ");
                                    int input2 = Convert.ToInt32(Console.ReadLine());
                                    int tempStat = tempStats[selNum - 1].value;
                                    tempStats[selNum - 1].value = tempStats[input2 - 1].value;
                                    tempStats[input2 - 1].value = tempStat;
                                }
                            }
                            preStats = new StatGroup(tempStats);
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
                } // make Stats
                if (!programLoop) { break; }
                character.SetStats(preStats);
                bool detailLoop = true;
                while (detailLoop)
                {
                    bool[] locks = { false, false, false, false, false, false };
                    Console.Clear();
                    Console.Write("Please insert your character's name: ");
                    string name = Console.ReadLine();
                    Console.Write("Is your character Male (1) or Female (2)? (R) for Random: ");
                    string gender = Console.ReadLine();
                    if (gender == "1") { gender = "Male"; locks[1] = true; }
                    else if (gender == "2") { gender = "Female"; locks[1] = true; }
                    else if (gender == "R") { gender = Char.GetSex(); }
                    else throw new Exception("Gender");
                    Console.Write("What Species is your character? (R) for Random: ");
                    string species = Console.ReadLine();
                    if (species == "R") { species = Char.GetSpecies(); } else { locks[2] = true; }
                    Console.Write("What is your character's hometown? (R) for Random: ");
                    string homeTown = Console.ReadLine();
                    if (homeTown == "R") { homeTown = Char.GetTown(); } else { locks[3] = true; }
                    Console.Write("What is your character's Class? (R) For Random, (0) for classless: ");
                    string Class = Console.ReadLine();
                    if (Class == "R") { Class = Char.GetClass(); } else if (Class == "0") 
                    { Class = "None"; locks[4] = true; } else { locks[4] = true; }
                    Console.Write("What is your character's Job?\n(R) for Random, (0) for Unemployed, \"Student\" for Student: ");
                    string job = Console.ReadLine();
                    if (job == "R") { job = Char.GetJob(); } else if (job == "0") 
                    { job = "Unemployed"; locks[5] = true; } else { locks[5] = true; }
                    while (true)
                    {
                        Console.Clear();
                        Console.Write(DisplayDetails(name, gender, species, homeTown, Class, job, locks) + "\n\n");
                        Console.Write("use numbers from (1) to (6) to lock details from being rerolled (X for locked)\n");
                        Console.Write("(R) to reroll unlocked, (F) to save, (C) to cancel: ");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                if (locks[0])
                                {
                                    locks[0] = false;
                                }
                                else
                                {
                                    locks[0] = true;
                                }
                                break;
                            case "2":
                                if (locks[1])
                                {
                                    locks[1] = false;
                                }
                                else
                                {
                                    locks[1] = true;
                                }
                                break;
                            case "3":
                                if (locks[2])
                                {
                                    locks[2] = false;
                                }
                                else
                                {
                                    locks[2] = true;
                                }
                                break;
                            case "4":
                                if (locks[3])
                                {
                                    locks[3] = false;
                                }
                                else
                                {
                                    locks[3] = true;
                                }
                                break;
                            case "5":
                                if (locks[4])
                                {
                                    locks[4] = false;
                                }
                                else
                                {
                                    locks[4] = true;
                                }
                                break;
                            case "6":
                                if (locks[5])
                                {
                                    locks[5] = false;
                                }
                                else
                                {
                                    locks[5] = true;
                                }
                                break;
                            case "F":
                                detailLoop = false;
                                break;
                            case "C":
                                detailLoop = false;
                                programLoop = false;
                                break;
                            case "R":
                                if (!locks[0])
                                {
                                    
                                }
                                if (!locks[1])
                                {
                                    gender = Char.GetSex();
                                }
                                if (!locks[2])
                                {
                                    species = Char.GetSpecies();
                                }
                                if (!locks[3])
                                {
                                    homeTown = Char.GetTown();
                                }
                                if (!locks[4])
                                {
                                    Class = Char.GetClass();
                                }
                                if (!locks[5])
                                {
                                    job = Char.GetJob();
                                }
                                break;
                        }
                        if (!detailLoop)
                        {
                            break;
                        }
                    }
                    if (!detailLoop)
                    {
                        details[0] = name; details[1] = gender; details[2] = species;
                        details[3] = homeTown; details[4] = Class; details[5] = job;
                        break;
                    }
                } // make details
                if (!programLoop) { break; }
                character.SetDetails(details);
                bool personalityLoop = true; bool personalitySinLoop = true; bool personalityArrLoop = true;
                while (personalityLoop)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Would you like to randomise personalities? (Y/n): ");
                        string randomise = Console.ReadLine();
                        if (randomise == "Y") {
                            persArray = Personality.GetPersonalities();
                            persArrayArray = Personality.GetArrayPersonalities();break;
                        } else if (randomise == "n"){
                            Console.WriteLine("Please Describe your character's Appearance in one word");
                            persArray[0] = new Personality(Console.ReadLine());
                            Console.WriteLine("Please Describe your character's Talent in one word");
                            persArray[1] = new Personality(Console.ReadLine());
                            Console.WriteLine("Please Describe your character's Mannerisms in one word");
                            persArray[2] = new Personality(Console.ReadLine());
                            Console.WriteLine("Please Describe your character's Traits in one word");
                            persArray[3] = new Personality(Console.ReadLine());
                            Console.WriteLine("Please Describe your character's Flaws in one word");
                            persArray[4] = new Personality(Console.ReadLine());
                            Console.WriteLine("Please Describe your character's neutral Ideals in one word");
                            persArray[5] = new Personality(Console.ReadLine());
                            Console.WriteLine("Please Describe your character's other Ideals in one word");
                            persArray[6] = new Personality(Console.ReadLine());break;
                        }
                    }
                    while (personalitySinLoop)
                    {
                        Console.Clear();
                        Console.WriteLine(DisplayPersonalities(persArray));
                        Console.WriteLine("\n\nType numbers from (1) to (7) to Prevent Personalities from being rerolled (X for locked)");
                        Console.WriteLine("Type (C) to Cancel, type (F) to finish and save stats, type (R) to reroll");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "C":
                                personalitySinLoop = false; programLoop = false; break;
                            case "F":
                                personalitySinLoop = false; break;
                            case "R":
                                Personality[] temp = Personality.GetPersonalities();
                                
                                for (int i = 0; i < 7; i++) 
                                { 
                                    if (!persArray[i].locked)
                                    {
                                        persArray[i] = temp[i];
                                    }
                                }
                                break;
                            case "1": if (persArray[0].locked) persArray[0].locked = false; else persArray[0].locked = true; break;
                            case "2": if (persArray[1].locked) persArray[1].locked = false; else persArray[1].locked = true; break;
                            case "3": if (persArray[2].locked) persArray[2].locked = false; else persArray[2].locked = true; break;
                            case "4": if (persArray[3].locked) persArray[3].locked = false; else persArray[3].locked = true; break;
                            case "5": if (persArray[4].locked) persArray[4].locked = false; else persArray[4].locked = true; break;
                            case "6": if (persArray[5].locked) persArray[5].locked = false; else persArray[5].locked = true; break;
                            case "7": if (persArray[6].locked) persArray[6].locked = false; else persArray[6].locked = true; break;
                        }
                        if (!personalitySinLoop) break;
                    }
                    while (personalityArrLoop)
                    {
                        Console.Clear();
                        Console.WriteLine(DisplayArrayPersonalities(persArrayArray));
                        Console.WriteLine("\n\nType numbers from (1) to (3) to Prevent Personalities from being rerolled (X for locked)");
                        Console.WriteLine("Type (C) to Cancel, type (F) to finish and save stats, type (R) to reroll");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "C":
                                personalityArrLoop = false; programLoop = false; break;
                            case "F":
                                personalityArrLoop = false; break;
                            case "R":
                                Personality[,] temp = Personality.GetArrayPersonalities();

                                for (int y = 0; y < 2; y++)
                                {
                                    for (int x = 0; x < 3; x++)
                                    {
                                        if (!persArrayArray[x, y].locked)
                                        {
                                            persArrayArray[x, y] = temp[x, y];
                                        }
                                    }
                                }
                                break;
                            case "1": if (persArrayArray[0, 0].locked) persArrayArray[0, 0].locked = false; else persArrayArray[0, 0].locked = true; break;
                            case "2": if (persArrayArray[0, 1].locked) persArrayArray[0, 1].locked = false; else persArrayArray[0, 1].locked = true; break;
                            case "3": if (persArrayArray[1, 0].locked) persArrayArray[1, 0].locked = false; else persArrayArray[1, 0].locked = true; break;
                            case "4": if (persArrayArray[1, 1].locked) persArrayArray[1, 1].locked = false; else persArrayArray[1, 1].locked = true; break;
                            case "5": if (persArrayArray[2, 0].locked) persArrayArray[2, 0].locked = false; else persArrayArray[2, 0].locked = true; break;
                            case "6": if (persArrayArray[2, 1].locked) persArrayArray[2, 1].locked = false; else persArrayArray[2, 1].locked = true; break;
                        }
                    }
                        if (!personalityArrLoop) break;
                } // make personality and appearance
                if (!programLoop) break;
                character.SetPers(persArray);
                character.SetPersArrays(persArrayArray);
                bool finalCheckLoop = true;
                while (finalCheckLoop)
                {
                    Console.Clear();
                    Console.Write(DisplayAll(character));
                    Console.Write("\n\nTo save to file, type (S)\n");
                    string input = Console.ReadLine();
                    bool saveLoop = true; string saveLoopString = "";
                    if (input == "S")
                    {
                        while (saveLoop) { 
                            Console.Clear();
                            Console.Write("Please specify a" + saveLoopString + " filename: ");
                            string path = Environment.CurrentDirectory + "\\";
                            if (!Directory.Exists(path + "Characters\\")){
                                Directory.CreateDirectory(path + "Characters\\");
                            }
                            path += "Characters\\";
                            string fileName = Console.ReadLine();
                            path += fileName + ".txt";
                            if (!File.Exists(path))
                            {
                                using (StreamWriter sw = File.CreateText(path))
                                {
                                    sw.Write(DisplayAll(character));
                                    saveLoop = false;
                                }
                            }
                            else saveLoopString = "n unused";
                        }
                    }
                } // show everything
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
            a += "| " + locks2[0] + " | Name:       " + name + "\n";
            a += "| " + locks2[1] + " | Sex:        " + sex + "\n";
            a += "| " + locks2[2] + " | Species:    " + species + "\n";
            a += "| " + locks2[3] + " | Home Town:  " + residence + "\n";
            a += "| " + locks2[4] + " | Class:      " + Class + "\n";
            a += "| " + locks2[5] + " | Job:        " + job + "\n";
            return a;
        }
        static string DisplayPersonalities(Personality[] PersArray)
        {
            string[] locks = new string[7];
            for (int i = 0; i < 7; i++)
            {
                if (PersArray[i].locked) locks[i] = "X"; else locks[i] = " ";
            }
            string a = "";
            a += "| " + locks[0] + " | Appearance:      | " + PersArray[0].name + "\n";
            a += "| " + locks[1] + " | Talents:         | " + PersArray[1].name + "\n";
            a += "| " + locks[2] + " | Mannerisms:      | " + PersArray[2].name + "\n";
            a += "| " + locks[3] + " | Traits:          | " + PersArray[3].name + "\n";
            a += "| " + locks[4] + " | Flaws / Secrets: | " + PersArray[4].name + "\n";
            a += "| " + locks[5] + " | Neutral Ideal:   | " + PersArray[5].name + "\n";
            a += "| " + locks[6] + " | Other Ideal:     | " + PersArray[6].name + "\n";
            return a; 
        }
        static string DisplayArrayPersonalities(Personality[,] PersArrayArray)
        {
            string[] locks = new string[6];
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (PersArrayArray[x, y].locked) locks[x + 3 * y] = "X"; else locks[x + 3 * y] = " ";
                }
            }
            string a = "";
            a += "|---| " + "Law Ideals:\n";
            a += "| " + locks[0] + " | " + PersArrayArray[0, 0].name + "\n";
            a += "| " + locks[3] + " | " + PersArrayArray[0, 1].name + "\n";
            a += "|---| " + "Alignment Ideals:\n";
            a += "| " + locks[1] + " | " + PersArrayArray[1, 0].name + "\n";
            a += "| " + locks[4] + " | " + PersArrayArray[1, 1].name + "\n";
            a += "|---| " + "Bonds:\n";
            a += "| " + locks[2] + " | " + PersArrayArray[2, 0].name + "\n";
            a += "| " + locks[5] + " | " + PersArrayArray[2, 1].name + "\n";
            return a;
        }
        static string DisplayAll(Char chara)
        {
            string a = "";
            string isNPC; if (chara.isPlayer) isNPC = "PC"; else isNPC = "NPC";
            string Class = ""; if (chara.Class == "None") Class = ""; else Class = chara.Class;
            a += "(" + isNPC + ") " + chara.name + ", " + chara.sex + " " + chara.species + " " + Class;
            a += "\n\n" + chara.stats.GetStatString() + "\n\n" + "Hometown: " + chara.residence;
            a += "\nJob:      " + chara.job + "\n";
            a += "\nAppearance      : " + chara.appearance.name;
            a += "\nTalents         : " + chara.talents.name;
            a += "\nMannerisms      : " + chara.mannerisms.name;
            a += "\nTraits          : " + chara.traits.name;
            a += "\nFlaws/Secrets   : " + chara.flawsSecrets.name;
            a += "\nLaw Ideals      : " + CombinePersArrays(chara.lawIdeals[0].name,chara.lawIdeals[1].name);
            a += "\nAlighment Ideals: " + CombinePersArrays(chara.alignmentIdeals[0].name,chara.alignmentIdeals[1].name);
            a += "\nNeutral Ideals  : " + chara.neutralIdeal.name;
            a += "\nOther Ideals    : " + chara.otherIdeal.name;
            a += "\nBonds           : " + CombinePersArrays(chara.bonds[0].name,chara.bonds[1].name);
            return a;
        }
        static string CombinePersArrays(string string1, string string2)
        {
            string a = "";
            if (string1 == string2) a = string1; else a = string1 + ", " + string2;
            return a;
        }
    }
}
