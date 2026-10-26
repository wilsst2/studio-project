using System.Collections;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace studio_project
{
    internal class Program
    {
        static bool hasRustyKey = false;

        //Blake
        static void Main()
        {
            Console.WriteLine("Welcome to this as yet unnamed and unfinished game!\n\nIt is a puzzle game set in a haunted manor where your goal is to find jack-o'-lanterns. You will have preset options to pick from determining where you want to go, items you want to pick up, etc. Some options may not be available until you have gained items or knowledge from other rooms so it is worth revisiting places later on. If you are confused, just type '?' at any time and you will recieve a more in depth tutorial - not actually, the tutorial exists but is only accessible from a few areas at the moment");
            Console.WriteLine("\nPress enter to start the game");
            Console.ReadLine();
            // boolean arrays for inventory - remember to comment what number your items correspond to so we can keep track easier
            bool[] lanterns = new bool[4];
            lanterns[0] = false; lanterns[1] = false; lanterns[2] = false; lanterns[3] = false; // 0 = courtyard, 1 = kitchen, 2 = forest, 3 = bedroom
            bool[] inv = new bool[6];
            inv[0] = false; inv[1] = false; inv[2] = false; inv[3] = false; inv[4] = false; inv[5] = false; // 0 = coins, 1 = pruning knife, 3 = garden shed key, 4 = flashlight, 5 = broom
            UpHallway(lanterns, inv);
        }
        
        static char CharCheck()
        {
            char user = '0';
            bool check = false;
            do
            {
                try
                {
                    user = Convert.ToChar(Console.ReadLine());
                    check = true;
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                }
            } while (check == false);
            return user;
        }

        static void Courtyard(bool[] lanterns, bool[] inv)
        {
            Console.Clear();
            Console.Write("You stand in front of an old, dilapidated manor, it's doors wide open and welcoming. The courtyard is in a state of disrepair, overgrown shrubs reach for the walls, wildflowers sprout through the cracked asphalt driveway, and cobwebs enshroud the windows. The moon-shadows of the dead trees surround you.");
            if (lanterns[0] == false)
            {
                Console.WriteLine(" A jack-o'-lantern hangs in one of them.");
            }
            Console.WriteLine("\nWhat do you want to do?");
            if (lanterns[0] == false)
            {
                Console.WriteLine("1. Enter manor\n2. Move to backyard\n3. Leave\n4. Approach jack-o'-lantern");
            }
            else
            {
                Console.WriteLine("1. Enter manor\n2. Backyard\n3. Leave");
            }
            char user = CharCheck();
            if (user == '1')
            {
                Console.Clear();
                Console.WriteLine("You take the steps up to the front door and enter the manor.");
                Console.ReadLine();
                Hallway();
            }
            else if (user == '2')
            {
                Console.Clear();
                Console.WriteLine("You move around the manor to the backyard.");
                Backyard(lanterns, inv);
            }
            else if (user == '3')
            {
                Console.Clear();
                Console.WriteLine("The heavy gates of the courtyard clang shut behind you as you leave. Thick midnight fog prevents you from properly surveying your surroundings, but you are able to follow the road towards a bright glow in the distance. As you approach, you see a neon lit up welcome sign and realize you have found a dairy.");
                Console.ReadLine();
                Street(lanterns, inv);
            }
            else if (user == '4' && lanterns[0] == false)
            {
                Console.Clear();
                Console.Write("The jack-o'lantern is suspended within a net, which is attached to a rope keeping it firmly in the sky.");
                if (inv[1] == true)
                {
                    Console.WriteLine(" You use your pruning knife to cut the rope and the net falls to the ground. You are able to claim your jack-o'-lantern.");
                    lanterns[0] = true;
                    Console.ReadLine();
                    Courtyard(lanterns, inv);
                }
                else
                {
                    Console.WriteLine(" You might be able to cut it down if you find a sharp object.");
                    Console.ReadLine();
                    Courtyard(lanterns, inv);
                }
            }
            else if (user == '?')
            {
                Help();
                Courtyard(lanterns, inv);
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                Courtyard(lanterns, inv);
            }
        }
        static void Backyard(bool[] lanterns, bool[] inv)
        {
            Console.Clear();
            Console.WriteLine("The area is even more overgrown than the courtyard. There is a no longer running fountain and a dingy garden shed tucked away in the far corner.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Enter manor\n2. Move to courtyard\n3. Approach garden shed");
            if (inv[0] == false)
            {
                Console.WriteLine("4. Investigate fountain");
            }
            char user = CharCheck();
            if (user == '1')
            {
                Console.Clear();
                Console.WriteLine("You enter the manor through the backdoor.");
                Console.ReadLine();
                Backyard(lanterns, inv); // unsure what this room will be
            }
            else if (user == '2')
            {
                Console.Clear();
                Console.WriteLine("You move around the manor to the courtyard");
                Console.ReadLine();
                Courtyard(lanterns, inv);
            }
            else if (user == '3')
            {
                Console.Clear();
                Console.Write("You trudge through the mud to reach the garden shed.");
                if (inv[2] == false)
                {
                    Console.WriteLine(" There's a rusty padlock keeping the door locked. It doesn't budge.");
                    Console.ReadLine();
                    Backyard(lanterns, inv);
                }
                else
                {
                    Console.WriteLine("You use your key to unlock the padlock and enter.");
                    Console.ReadLine();
                    GardenShed(lanterns, inv);
                }
            }
            else if (user == '4' && inv[0] == false)
            {
                Console.Clear();
                Console.WriteLine("You come closer to the fountain. The once marble structure is now slimey and covered in green. Larvae rests on the surface, the water here has been undisturbed for a long time. You can see coins lining the bottom of the fountain and are able to swipe them up");
                inv[0] = true;
                Console.ReadLine();
                Backyard(lanterns, inv);
            }
            else if (user == '?')
            {
                Help();
                Backyard(lanterns, inv);
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                Backyard(lanterns, inv);
            }
        }
        static void GardenShed(bool[] lanterns, bool[] inv)
        {
            Console.Clear();
            Console.Write("You are in a dark and cramped space that smells of mold and something rotten. Your only light is from the moon shining through cracks in the roof.");
            if (inv[1] == false)
            {
                Console.WriteLine(" There's a pruning knife jutting out of the wall.");
            }
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Leave");
            if (inv[1] == false)
            {
                Console.WriteLine("2. Grab pruning knife");
            }
            char user = CharCheck();
            if (user == '1')
            {
                Console.Clear();
                Console.WriteLine("You leave the garden shed and return to the backyard.");
                Console.ReadLine();
                Backyard(lanterns, inv);
            }
            else if (user == '2' && inv[1] == false)
            {
                Console.Clear();
                Console.WriteLine("You grab the pruning knife");
                inv[1] = true;
                Console.ReadLine();
                GardenShed(lanterns, inv);
            }
            else if (user == '?')
            {
                Help();
                Backyard(lanterns, inv);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input");
                Backyard(lanterns, inv);
            }
        }
        static void Basement(bool[] lanterns, bool[] inv)
        {
            if (inv[4] == false)
            {
                Console.WriteLine("Without the light of the moon, it's impossible to make out your surroundings.");
            }
            else
            {
                Console.Write("You stand in a cold, damp concrete basement. Sweeping your torch across the room reveals a thick layer of dust covering your surroundings.");
                if (inv[3] == false)
                {
                    Console.WriteLine(" The only thing not covered in dust is a key on a wall hanger.");
                }
            }
            Console.WriteLine("/n What do you want to do?");
            Console.WriteLine("1. Leave basement");
            if (inv[3] == false && inv[4] == true)
            {
                Console.WriteLine("2. Take key");
            }
            char user = CharCheck();
            if (user == '1')
            {
                // method to return to whatever room takes you to the basement
            }
            else if (user == '2' && inv[3] == false && inv[4] == true)
            {
                Console.WriteLine("You take the key.");
                inv[3] = true;
                Basement(lanterns, inv);
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
            }
        }

        static void UpHallway(bool[]lanterns, bool[]inv)
        {
            Console.Clear();
            Console.WriteLine("You stand in the creaky upstairs hallway. There's a latch on the roof and various paintings on the walls that appear to be from different eras with different styles.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Enter bedroom\n2. Enter bathroom\n3. Enter attic\n4. Examine paintings");
            char user = CharCheck();
            if (user == '1')
            {
                Console.Clear();
                Console.WriteLine("You take the door to the bedroom.");
                Console.ReadLine();
                Bedroom(lanterns, inv);
            }
            else if (user == '2')
            {
                Console.Clear();
                Console.WriteLine("You take the door to the bathroom.");
                Console.ReadLine();
                UpHallway(lanterns, inv); // 2nd bathroom method
            }
            else if (user == '3' && inv[5] == false)
            {
                Console.Clear();
                Console.WriteLine("You have nothing to pull the door down with.");
                Console.ReadLine();
                UpHallway(lanterns, inv);
            }
            else if (user == '3' && inv[5] == true)
            {
                Console.Clear();
                Console.WriteLine("You use your broom to pull the door down and ascend into the attic.");
                Console.ReadLine();
                UpHallway(lanterns, inv); // attic method
            }
            else if (user == '4')
            {
                Paintings();
                UpHallway(lanterns, inv);
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                UpHallway(lanterns, inv);
            }
        }

        static void Bedroom(bool[] lanterns, bool[] inv)
        {
            Console.Clear();
            Console.WriteLine("You're in the master bedroom. The room is sparesly decorated with only a bed, a sidetable, and a painting on the wall.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Leave\n2. Search drawers\n3. Examine painting");
            if (lanterns[3] == false)
            {
                Console.WriteLine("4. Look under bed");
            }
            char user = CharCheck();
            if (user == '1')
            {
                Console.WriteLine("\nYou head back into the hallway.");
                Console.ReadLine();
                UpHallway(lanterns, inv);
            }
            if (user == '2' && inv[4] == true)
            {
                Console.WriteLine("\nThe drawers are completely empty.");
                Console.ReadLine();
                Bedroom(lanterns, inv);
            }
            else if (user == '2' && inv[4] == false)
            {
                Console.WriteLine("\nThe drawers are mostly cleaned out, the only item inside is a flashlight. You take it.");
                inv[4] = true;
                Console.ReadLine();
                Bedroom(lanterns, inv);
            }
            else if (user == '3')
            {
                Console.WriteLine("\nThe painting is of a man with no mouth. It has a plaque underneath it that reads '3'");
                Console.ReadLine();
                Bedroom(lanterns, inv);
            }
            else if (user == '4' && lanterns[3] == false)
            {
                Console.Clear();
                Console.WriteLine("You find a large lockbox underneath the bed. It has a combination lock for three numbers.");
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1. Open it\n2. Leave it");
                user = CharCheck();
                if (user == '1')
                {
                    Lockbox(lanterns);
                    Bedroom(lanterns, inv);
                }
                else if (user == '2')
                {
                    Console.WriteLine("You put the lockbox back.");
                    Console.ReadLine();
                    Bedroom(lanterns, inv);
                }
            }
        }

        static void Lockbox(bool[] lanterns)
        {
            string code = "106";
            string uCode = "0";
            bool con = true;
            do
            {
                Console.Clear();
                Console.Write("Enter code: ");
                uCode = Console.ReadLine();
                if (uCode != code)
                {
                    Console.WriteLine("\nThe box doesn't open. Do you want to try again?");
                    Console.WriteLine("\n1. Try again\n2. Leave");
                    char user = CharCheck();
                    if (user == '1')
                    {
                        con = true;
                    }
                    else if (user == '2')
                    {
                        con = false;
                    }
                }
                else if (uCode == code)
                {
                    Console.WriteLine("\nThe box unlocks. Inside is a jack-o'-lantern!");
                    lanterns[3] = true;
                    con = false;
                    Console.ReadLine();
                }
            } while (con == true);
            Console.WriteLine("");
        }
        static void Paintings()
        {
            Console.Clear();
            Console.WriteLine("There are four paintings on the wall.");
            Console.WriteLine("\nWhich one do you want to look at?");
            Console.WriteLine("1. First painting\n2. Second painting\n3. Third painting\n4. Leave the paintings");
            char user = CharCheck();
            if (user == '1')
            {
                Console.WriteLine("\nThis painting is of a man with no eyes. The plaque underneath says it was painted in 1811.");
                Console.ReadLine();
                Paintings();
            }
            else if (user == '2')
            {
                Console.WriteLine("\nThis painting is of a man with no ears. The plaque underneath says it was painted in 1803.");
                Console.ReadLine();
                Paintings();
            }
            else if (user == '3')
            {
                Console.WriteLine("\nThis painting is of a man with no mouth. The plaque unerneath says it was painted in 1861.");
                Console.ReadLine();
                Paintings();
            }
            else if (user == '4')
            {
                Console.WriteLine("\nYou leave the paintings to their solitude.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                Paintings();
            }
        }

        static void Street(bool[] lanterns, bool[] inv)
        {
            Console.Clear();
            Console.WriteLine("You stand in front of the dairy. While the sign is bright and blinding, there are no other lights and there doesn't appear to be anyone else around.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Look around\n2. Enter dairy\n3. Return to manor");
            char user = CharCheck();
            if (user == '1')
            {
                Console.Clear();
                Console.WriteLine("The road you were following appears to end at the dairy. All that surrounds you is the forest. You are alone.");
                Console.ReadLine();
                Street(lanterns, inv);
            }
            else if (user == '2')
            {
                //Dairy();
            }
            else if (user == '3')
            {
                Console.Clear();
                Console.WriteLine("You follow the path back to the manor and enter the courtyard.");
                Console.ReadLine();
                Courtyard(lanterns, inv);
            }
            else if (user == '?')
            {
                Help();
                Street(lanterns, inv);
            }
        }


        static void Help()
        {
            Console.Clear();
            Console.WriteLine("Gameplay: You will be provided with a list of options at every stage, just type and enter the corresponding number to pursue that action.");
            Console.WriteLine("Items: Items will be added to your inventory and can be used to enter previously unaccesible areas or acquire jack-o'lanters.");
            Console.WriteLine("Puzzles: Puzzles are all self contained and instructions will be within the puzzles themselves.");
            Console.ReadLine();
        }










        //Dominik
        static bool Puzzle1()
        {
            Random rand = new Random();
            string[] puzzle = { "sinister", "october", "apparition", "halloween", };
            string chosen = puzzle[rand.Next(puzzle.Length)]; //Chooses a random word from the puzzle array
            string input;
            string choice = "Y";        //Set to Y as default for checks later
            char[] letters = chosen.ToCharArray(); //Convert chosen string to array of characters                    
            for (int i = 0; i < letters.Length; i++) //Repeat for every letter in the array
            {
                int randomIndex = rand.Next(letters.Length);     //Chooses random char in the array
                char temp = letters[i];                          //Stores letter about to be changed in temp
                letters[i] = letters[randomIndex];              //Changes the stored letter that was just stored to the chosen random char
                letters[randomIndex] = temp;                    //Stores the used word in temp
            }
            string jumble = new string(letters);                //Creates a string storing the new jumbled word
            Console.Clear();
            Console.WriteLine("There's a strange set of letters carved into the case:");
            Console.WriteLine();
            Console.WriteLine("Maybe unscrambling this jumbled word will open it?");
            Console.WriteLine();
            do
            {
                Console.WriteLine(jumble);
                Console.WriteLine();
                Console.Write("Attempt to unscramble: ");
                input = Console.ReadLine().ToLower();           //Gets the user's choice and converts it to lowercase
                if (input != chosen)                            //Get user's attempt to unscramble word
                {
                    Console.Clear();
                    Console.Write("Nothing happened, try again? (Y/N): ");
                    choice = Console.ReadLine().ToUpper();      //Get user's choice on if they want to replay or leave, capitalized
                    Console.Clear();
                }
            } while (input != chosen && choice == "Y");         //Check: User hasn't gotten the puzzle correct and their choice is "Y"
            if (choice != "Y")                              //Check: User doesn't want to retry
            {
                Console.Clear();
                Console.WriteLine("You give up and leave the case.");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You open the case successfully. Inside is a key radiating an sinister aura...");
                Console.ReadLine();
                return true;
            }
        }
        static bool Puzzle2()
        {
            string choice = "Y";
            string entry;
            Console.Clear();
            Console.WriteLine("Upon approaching the door, there's lock with a series of raw binary on it.");
            Console.WriteLine();
            Console.WriteLine("You must convert this to decimal to enter...");
            Console.WriteLine();
            do
            {
                Console.WriteLine("1010011010");            //This is equal to 666 in decimal
                Console.WriteLine();
                Console.Write("Attempt to translate: ");
                entry = Console.ReadLine();
                if (entry != "666")
                {
                    Console.Clear();
                    Console.Write("Incorrect, try again? (Y/N): ");
                    choice = Console.ReadLine().ToUpper();
                    Console.Clear();
                }
            } while (entry != "666" && choice == "Y");
            if (choice != "Y")
            {
                Console.Clear();
                Console.WriteLine("You gave up and left.");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You successfully converted the binary to decimal.");
                Console.ReadLine();
                return true;
            }
        }
        static void Encounter1(bool[] lanterns, bool[] inv)
        {
            if (lanterns[5] == true)
            {
                ExploreForest(lanterns, inv);
            }
            string choice;
            Console.Clear();
            Console.WriteLine("Upon wandering through the forest, you encounter a figure in a dark robe blocking the path...");
            Console.WriteLine();
            Console.WriteLine("What will you do?");
            Console.WriteLine();
            Console.WriteLine("1. Cower in fear from his aura");
            if (inv[1] == true)
            {
                Console.WriteLine("2. Attempt to fight the figure");
            }
            choice = Console.ReadLine();
            if (choice == "1")
            {
                //Let me know which part of the map this should send you back to.
            }
            else if (choice == "2" && inv[1] == true)
            {
                Fight1(lanterns, inv);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                Encounter1(lanterns, inv);
            }
        }
        static void Fight1(bool[] lanterns, bool[] inv)
        {
            int turn = 1;
            int enemyoption, enemyatk, dmgdealt, dmgtaken, rng;
            string useroption, useratk;
            string target = "0";
            bool enemybleed = false;
            bool userbleed = false;
            bool userpoison = false;
            bool guard = false;
            bool enemyguard = false;
            int usernrg = 40;
            int userhp = 100;
            int enemyhp = 100;
            int bleedtimer = 0;
            int poisontimer = 0;
            int enemybleedtimer = 0;
            Random rand = new Random();
            Console.Clear();
            Console.WriteLine("You equip your pruning knife, preparing yourself to fight.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Get ready!");
            Thread.Sleep(2000);
            do
            {
                if (turn == 1 && userhp > 0)  //User's turn
                {
                    if (userbleed == true)          //If user is bleeding
                    {
                        bleedtimer++;        //User will bleed or be poisoned for 3 turns before status effects wear off.
                        if (bleedtimer == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("You're no longer bleeding!");
                            userbleed = false;
                            bleedtimer = 0;
                            Thread.Sleep(3000);
                        }
                    }
                    if (userpoison == true)
                    {
                        poisontimer++;
                        if (poisontimer == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("You're no longer poisoned!");
                            userpoison = false;
                            poisontimer = 0;
                            Thread.Sleep(3000);
                        }
                    }
                    guard = false;
                    while (target != "1")
                    {
                        //Menu
                        Console.Clear();
                        Console.WriteLine($"HP: {userhp}");
                        Console.WriteLine($"STAM: {usernrg}");
                        Console.WriteLine();
                        Console.WriteLine($"Select target!");
                        Console.WriteLine();
                        Console.WriteLine($"1. Mysterious Figure\t[{enemyhp} HP]");
                        target = Console.ReadLine();
                        if (target != "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid option!");
                            Thread.Sleep(1500);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"HP: {userhp}");
                    Console.WriteLine($"STAM: {usernrg}");
                    Console.WriteLine();
                    Console.WriteLine("1. Attack\n2. Guard\n3. Action\n4. Back");
                    useroption = Console.ReadLine();
                    if (useroption == "1")
                        //Attack
                    {
                        Console.Clear();
                        Console.WriteLine($"HP: {userhp}");
                        Console.WriteLine($"STAM: {usernrg}");
                        Console.WriteLine();
                        Console.WriteLine("1. Slash (25 STAM)\n2. Stab (50 STAM)\n3. Back");
                        useratk = Console.ReadLine();
                        if (useratk == "1" && usernrg < 25)
                        {
                            Console.Clear();
                            Console.WriteLine("Not enough stamina!");
                            Thread.Sleep(1500);
                        }
                        if (useratk == "1" && usernrg >= 25)
                            //Slash
                        {
                            if (enemyguard == true)
                            {
                                dmgdealt = rand.Next(3, 15);
                            }
                            else
                            {
                                dmgdealt = rand.Next(10, 26);
                            }
                            enemyhp = (enemyhp - dmgdealt);
                            Console.Clear();
                            Console.WriteLine($"You slash your target, dealing {dmgdealt} damage!");
                            Thread.Sleep(1500);
                            rng = rand.Next(0, 5);
                            usernrg = (usernrg - 25);
                            if (rng == 0)
                            {
                                enemybleedtimer = 0;
                                if (enemybleed == false)
                                {
                                    enemybleed = true;
                                    Console.WriteLine();
                                    Console.WriteLine($"You inflicted bleed!");
                                    Thread.Sleep(1500);
                                }
                            }
                            if (enemybleed == true)
                            {
                                dmgdealt = rand.Next(3, 11);
                                enemyhp = (enemyhp - dmgdealt);
                                Console.WriteLine();
                                Console.WriteLine($"Mysterious figure took {dmgdealt} bleed damage!");
                                Thread.Sleep(1500);
                            }
                            usernrg = (usernrg + 40);       //Give user stamina after turn
                            if (usernrg > 100)
                            {
                                usernrg = 100;      //Make sure user doesn't have over 100 stamina
                            }
                            Thread.Sleep(3000);
                            turn = 2;
                        }
                        else if (useratk == "2" && usernrg < 50)        //Make sure user has enough stamina for this move
                        {
                            Console.Clear();
                            Console.WriteLine("Not enough stamina!");
                            Thread.Sleep(1500);
                        }
                        else if (useratk == "2" && usernrg >= 50)
                            //Stab
                        {
                            if (enemyguard == true)
                            {
                                dmgdealt = rand.Next(6, 18);
                            }
                            else
                            {
                                dmgdealt = rand.Next(18, 32);
                            }
                            enemyhp = (enemyhp - dmgdealt);
                            Console.Clear();
                            Console.WriteLine($"You stab your target, dealing {dmgdealt} damage!");
                            Thread.Sleep(1500);
                            usernrg = (usernrg - 50);
                            if (enemybleed == false)
                            {
                                enemybleed = true;
                                Console.WriteLine();
                                Console.WriteLine("You inflicted bleed!");
                                enemybleedtimer = 0;
                                Thread.Sleep(1500);
                            }
                            if (enemybleed == true)
                            {
                                dmgdealt = rand.Next(3, 11);
                                enemyhp = (enemyhp - dmgdealt);
                                Console.WriteLine();
                                Console.WriteLine($"Mysterious figure took {dmgdealt} bleed damage!");
                                Thread.Sleep(1500);
                            }
                            usernrg = (usernrg + 40);
                            if (usernrg > 100)
                            {
                                usernrg = 100;      //Make sure user doesn't have over 100 stamina
                            }
                            Thread.Sleep(3000);
                            turn = 2;
                        }
                        else if (useratk == "3") { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid option!");
                            Thread.Sleep(1500);
                        }
                    }
                    else if (useroption == "2")
                        //Block
                    {
                        Console.Clear();
                        Console.WriteLine("You brace yourself!");
                        guard = true;
                        if (enemybleed == true)
                        {
                            dmgdealt = rand.Next(3, 11);
                            enemyhp = (enemyhp - dmgdealt);
                            Console.WriteLine();
                            Console.WriteLine($"Mysterious figure took {dmgdealt} bleed damage!");
                            Thread.Sleep(1500);
                        }
                        usernrg = (usernrg + 40);
                        if (usernrg > 100)
                        {
                            usernrg = 100;      //Make sure user doesn't have over 100 stamina
                        }
                        Thread.Sleep(3000);
                        turn = 2;
                    }
                    else if (useroption == "3")
                        //Action
                    {
                        Console.Clear();
                        Console.WriteLine($"HP: {userhp}");
                        Console.WriteLine($"STAM: {usernrg}");
                        Console.WriteLine();
                        Console.WriteLine("1. Inspect enemy\n2. Back");
                        useratk = Console.ReadLine();
                        if (useratk == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("A mysterious figure wearing a dark robe, his identity is buried in the shadows of his hood. You can smell a sweet pumpkin aroma.");
                            Console.WriteLine();
                            Console.WriteLine($"HP: {enemyhp}");
                            Console.ReadLine();
                        }
                        else if (useratk == "2") { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid option!");
                            Thread.Sleep(1500);
                        }
                    }
                    else if (useroption == "4") { target = "0"; }   //Go back
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid option!");
                        Thread.Sleep(1500);
                    }
                }
                else if (turn == 2 && enemyhp > 0)      //Opponent's turn
                {
                    if (enemybleed == true)             //Enemy will bleed for 3 turns before status effects wear off.
                    {
                        enemybleedtimer++;
                        if (enemybleedtimer == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Mysterious figure recovered from the bleeding!");
                            enemybleed = false;
                            enemybleedtimer = 0;
                            Thread.Sleep(3000);
                        }
                    }
                    target = "0";
                    enemyguard = false;
                    Console.Clear();
                    Console.WriteLine($"It's mysterious figure's turn!");
                    enemyoption = rand.Next(0, 7);
                    Thread.Sleep(1500);
                    Console.WriteLine();
                    if (enemyoption == 0)
                        //Enemy: Guard
                    {
                        Console.WriteLine($"Mysterious figure chose to guard!");
                        enemyguard = true;
                        if (userpoison == true)
                        {
                            dmgtaken = rand.Next(1, 11);
                            userhp = (userhp - dmgtaken);
                            Console.WriteLine();
                            Console.WriteLine($"You took {dmgtaken} poison damage!");
                            Thread.Sleep(1500);
                        }
                        if (userbleed == true)
                        {
                            dmgtaken = rand.Next(1, 8);
                            userhp = (userhp - dmgtaken);
                            Console.WriteLine();
                            Console.WriteLine($"You took {dmgtaken} bleed damage!");
                            Thread.Sleep(1500);
                        }
                        Thread.Sleep(3000);
                        turn = 1;
                    }
                    else if (enemyoption == 1 && enemyhp < 80)
                        //Enemy: Heal
                    {
                        Console.WriteLine($"Mysterious figure used a healing chant, healing 20 HP and sealing their wounds!");
                        enemyhp = (enemyhp + 20);
                        enemybleed = false;
                        enemybleedtimer = 0;
                        if (userpoison == true)
                        {
                            dmgtaken = rand.Next(1, 11);
                            userhp = (userhp - dmgtaken);
                            Console.WriteLine();
                            Console.WriteLine($"You took {dmgtaken} poison damage!");
                            Thread.Sleep(1500);
                        }
                        if (userbleed == true)
                        {
                            dmgtaken = rand.Next(1, 8);
                            userhp = (userhp - dmgtaken);
                            Console.WriteLine();
                            Console.WriteLine($"You took {dmgtaken} bleed damage!");
                            Thread.Sleep(1500);
                        }
                        Thread.Sleep(3000);
                        turn = 1;
                    }
                    else
                    {
                        Console.WriteLine($"Mysterious figure chose to attack!");
                        Thread.Sleep(1500);
                        Console.WriteLine();
                        enemyatk = rand.Next(0, 5);
                        if (enemyatk == 0)
                            //Enemy: Ability 1
                        {
                            if (guard == true)
                            {
                                dmgtaken = rand.Next(0, 6);
                            }
                            else
                            {
                                dmgtaken = rand.Next(4, 18);
                            }
                            Console.WriteLine($"Mysterious figure casts plague, dealing {dmgtaken} damage!");
                            Thread.Sleep(1500);
                            poisontimer = 0;
                            userhp = (userhp - dmgtaken);
                            if (userpoison == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("You're poisoned!");
                                Thread.Sleep(1500);
                                userpoison = true;
                            }
                            if (userpoison == true)
                            {
                                dmgtaken = rand.Next(1, 11);
                                userhp = (userhp - dmgtaken);
                                Console.WriteLine();
                                Console.WriteLine($"You took {dmgtaken} poison damage!");
                                Thread.Sleep(1500);
                            }
                            if (userbleed == true)
                            {
                                dmgtaken = rand.Next(1, 8);
                                userhp = (userhp - dmgtaken);
                                Console.WriteLine();
                                Console.WriteLine($"You took {dmgtaken} bleed damage!");
                                Thread.Sleep(1500);
                            }
                            Thread.Sleep(3000);
                            turn = 1;
                        }
                        else if (enemyatk == 1)
                            //Enemy: Ability 2
                        {
                            if (guard == true)
                            {
                                dmgtaken = rand.Next(0, 9);
                            }
                            else
                            {
                                dmgtaken = rand.Next(6, 21);
                            }
                            Console.WriteLine($"Mysterious figure used ritual, dealing {dmgtaken} damage!");
                            Thread.Sleep(1500);
                            bleedtimer = 0;
                            userhp = (userhp - dmgtaken);
                            if (userbleed == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("You're bleeding!");
                                Thread.Sleep(1500);
                                userbleed = true;
                            }
                            if (userpoison == true)
                            {
                                dmgtaken = rand.Next(1, 11);
                                userhp = (userhp - dmgtaken);
                                Console.WriteLine();
                                Console.WriteLine($"You took {dmgtaken} poison damage!");
                                Thread.Sleep(1500);
                            }
                            if (userbleed == true)
                            {
                                dmgtaken = rand.Next(1, 8);
                                userhp = (userhp - dmgtaken);
                                Console.WriteLine();
                                Console.WriteLine($"You took {dmgtaken} bleed damage!");
                                Thread.Sleep(1500);
                            }
                            Thread.Sleep(3000);
                            turn = 1;
                        }
                        else
                            //Enemy: Default attack
                        {
                            if (guard == true)
                            {
                                dmgtaken = rand.Next(0, 8);
                            }
                            else
                            {
                                dmgtaken = rand.Next(9, 27);
                            }
                            Console.WriteLine($"Mysterious figure used strike, dealing {dmgtaken} damage!");
                            Thread.Sleep(1500);
                            userhp = (userhp - dmgtaken);
                            if (userpoison == true)
                            {
                                dmgtaken = rand.Next(1, 11);
                                userhp = (userhp - dmgtaken);
                                Console.WriteLine();
                                Console.WriteLine($"You took {dmgtaken} poison damage!");
                                Thread.Sleep(1500);
                            }
                            if (userbleed == true)
                            {
                                dmgtaken = rand.Next(1, 8);
                                userhp = (userhp - dmgtaken);
                                Console.WriteLine();
                                Console.WriteLine($"You took {dmgtaken} bleed damage!");
                                Thread.Sleep(1500);
                            }
                            Thread.Sleep(3000);
                            turn = 1;
                        }
                    }
                }
            } while (userhp > 0 && enemyhp > 0);
            if (userhp > 0 && enemyhp <= 0)
            {
                lanterns[5] = true;
                Console.Clear();
                Console.WriteLine("You won!");
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue!");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("The mysterious figure falls backwards, a lit jack-o'lantern rolls out from the hood of his dark robe.\nUpon collecting it, the robe blows away with the wind. You may now forage deeper into the forest.");
                Thread.Sleep(5000);
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue!");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You stagger back onto the grass, succumbing to injuries and passing out.\nYou wake up in the courtyard of the manor, miraculously healed from injuries and retaining your inventory.");
                Thread.Sleep(5000);
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                Console.Clear();
                Courtyard(lanterns, inv);
            }
        }
        static void BossFight(bool[] lanterns, bool[] inv, string bosstarget)
        {
            bool zombie = true; bool skeleton = true; bool horseman = true; int bossuserhp = 500; int bossuserstam = 200; int zombiehp = 100; int skeletonhp = 150; int horsemanhp = 666; int usertarget;
            usertarget = BossFightSelectTarget(zombie, skeleton, horseman, bossuserhp, bossuserstam, zombiehp, skeletonhp, horsemanhp);
        }
        //static int BossFightOptionSelect(int[] usertarget)
        //{

        //}
        static int BossFightSelectTarget(bool zombie, bool skeleton, bool horseman, int bossuserhp, int bossuserstam, int zombiehp, int skeletonhp, int horsemanhp)
        {
            //Target 1 = Horseman, Target 2 = Skeleton, Target 3 = Zombie
            bool validchoice = false;
            Console.Clear();
            Console.WriteLine($"HP: {bossuserhp}");
            Console.WriteLine($"STAM: {bossuserstam}");
            Console.WriteLine();
            Console.WriteLine($"Select target!");
            Console.WriteLine();
            do
            {
                List<string> targets = new List<string>();
                if (horseman)
                {
                    Console.WriteLine($"{targets.Count + 1}. Headless Horseman [{horsemanhp} HP]");
                    targets.Add("horseman");
                }
                if (skeleton)
                {
                    Console.WriteLine($"{targets.Count + 1}. Skeleton [{skeletonhp} HP]");
                    targets.Add("skeleton");
                }
                if (zombie)
                {
                    Console.WriteLine($"{targets.Count + 1}. Zombie [{zombiehp} HP]");
                    targets.Add("zombie");
                }
                int choice = Convert.ToInt32(Console.ReadLine());
                string selectedTarget = targets[choice - 1];
                if (selectedTarget == "horseman") return 1;
                else if (selectedTarget == "skeleton") return 2;
                else if (selectedTarget == "zombie") return 3;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option!");
                    Thread.Sleep(1500);
                }
            } while (true);
        }
































        //Akirah

        // hallway with options to enter bathroom or living room
        static void Hallway()
        {
            Console.Clear();
            Console.WriteLine("You are in the hallway of the HAUNTED HOUSE.");
            Console.WriteLine("The hallway is dark, and the floorboards creak beneath your feet.");
            Console.WriteLine("There are two doors in front of you.");

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Enter bathroom");
            Console.WriteLine("2. Enter living room");

            string user = Console.ReadLine();

            if (user == "1")
            {
                BathRoom();
            }
            else if (user == "2")
            {
                LivingRoom();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                Hallway();
            }
        }

        //bathroom scene and added a choice to go back to the hallway
        static void BathRoom()
        {
            Console.Clear();
            Console.WriteLine("You enter the bathroom.");
            Console.WriteLine("The mirror is cracked, the sink is stained, and the room feels unusually cold.");

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Return to hallway");

            string user = Console.ReadLine();

            if (user == "1")
            {
                Hallway();
            }
        }

        //living room description and options to explore the kitchen or return to the hallway
        // attempt Puzzle 1
        static void LivingRoom()
        {
       
            Console.Clear();
            Console.WriteLine("You enter the living room.");
            Console.WriteLine("Dusty furniture fills the room, and an old fireplace stands against the wall.");
            Console.WriteLine("There is one door leading into the kitchen.");

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("2. Return to hallway");
            Console.WriteLine("3. Solve mysterious case file 1");

            string user = Console.ReadLine();
            bool Puzzle1 = false;
            if (Puzzle1)
            {
                Console.WriteLine();
            }
            else
            {
                Puzzle1 = false;
            }

              //Case 1 Puzzle
       
        }

        // kitchen where the player can return to the living room 
        // attempt Puzzle 2
        static void Kitchen()
        {
            Console.Clear();
            Console.WriteLine("You enter the kitchen.");
            Console.WriteLine("Old cupboards line the walls, and rusty pots hang from the ceiling.");
            Console.WriteLine("A rotten smell lingers in the air.");

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Return to living room");
            Console.WriteLine("2. Solve mysterious case file 2");


            string user = Console.ReadLine();

            if (user == "1")
            {
                LivingRoom();
            }

            // Case 2 Puzzle
            else if (user == "2")
            {
                Puzzle2();
                Console.WriteLine();
                Console.WriteLine("Thank you for playing our haunted house demo!");    // Game Finished
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            Console.ReadKey();
            Kitchen();
        }














































        //David Haunted Forest

        static void ExploreForest(bool[] lanterns, bool[] inv)
        {
            int room = 0;
            bool[] visited = new bool[4];
            string[] rooms =
            {
             "You step into a dark, forgotten forest. Twisted trees reach " +
              "towards the sky while cold wind whispers through the branches.",

             "Thick silver fog covers the path. Strange footsteps follow " +
              "you, but nobody is there.",

             "Thorny vines cover the ground. Something beneath the leaves " +
             "scratches and moves in the darkness.",
  
             "Dead trees surround an abandoned grove. Strange symbols glow " +
              "on their bark, and a witch's laughter echoes nearby."
            };
            while (true)
            {
                Console.Clear();
                Console.WriteLine(rooms[room]);

                if (visited[room])
                {
                    Console.WriteLine("You recognise this place, but it still feels dangerous.");
                }
                else
                {
                    Console.WriteLine("You explore this area for the first time.");
                    visited[room] = true;
                }

                if (room == 0 && lanterns[2] == false)
                    Console.WriteLine("A glowing jack-o'-lantern rests beside a tree.");
                Console.WriteLine("\n1. Clearing\n2. Foggy path\n3. Briar patch\n4. Witch's grove");
                
                if (room == 0 && lanterns[2] == false)
                    Console.WriteLine("5. Pick up jack-o'-lantern");
                Console.WriteLine("6. Leave forest\n?. Help");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        room = 0;
                        Console.WriteLine("\nYou return to the forest clearing.");
                        Console.ReadLine();
                        break;

                    case "2":
                        room = 1;
                        Console.WriteLine("\nYou follow the narrow trail into the silver fog.");
                        Console.ReadLine();
                        break;

                    case "3":
                        room = 2;
                        Console.WriteLine("\nYou carefully push through the thorny vines.");
                        Console.ReadLine();
                        break;

                    case "4":
                        room = 3;
                        Console.WriteLine("\nYou approach the mysterious Witch's Grove.");
                        Console.ReadLine();
                        break;

                    case "5":
                        if (room == 0 && lanterns[2] == false)
                        {
                            lanterns[2] = true;
                            Console.WriteLine("\nYou carefully lift the glowing jack-o'-lantern.");
                            Console.WriteLine("Its warm orange light pushes back the surrounding darkness.");
                            Console.WriteLine("For a moment, the whispers in the trees fall silent.");
                            Console.WriteLine("You have collected the forest jack-o'-lantern!");

                            Console.WriteLine("\nPress ENTER to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            ShowInvalidChoice();
                        }
                        break;

                    case "6":
                        Console.WriteLine("\nThe path behind you disappears into the fog.");
                        Console.WriteLine("Are you sure you want to leave the forest? (Y/N)");

                        string confirm = Console.ReadLine().Trim().ToUpper();

                        if (confirm == "Y")
                        {
                            Console.WriteLine("You leave the forest and return to the path.");
                            Console.ReadLine();
                            Street(lanterns, inv);
                            return;
                        }
                        else if (confirm == "N")
                        {
                            Console.WriteLine("You decide to remain among the twisted trees.");
                            Console.ReadLine();
                        }
                        else
                        {
                            ShowInvalidChoice();
                        }
                        break;

                    case "?":
                        Console.Clear();
                        Console.WriteLine("=== HAUNTED FOREST HELP ===");
                        Console.WriteLine("Choose a number to explore a forest area.");
                        Console.WriteLine("1 - Explore the Clearing");
                        Console.WriteLine("2 - Explore the Foggy Path");
                        Console.WriteLine("3 - Explore the Briar Patch");
                        Console.WriteLine("4 - Explore the Witch's Grove");
                        Console.WriteLine("5 - Collect the lantern when available.");
                        Console.WriteLine("6 - Leave the forest.");
                        Console.WriteLine("? - Display these instructions.");
                        Console.WriteLine("\nPress ENTER to return to the forest.");
                        Console.ReadLine();
                        break;

                    default:
                        ShowInvalidChoice();
                        break;
                }
            }
        }
        //Invalid choice
        static void ShowInvalidChoice()
        {
            Console.WriteLine("\nThe forest does not recognise that choice.");
            Console.WriteLine("Please choose an option from the menu.");
            Console.WriteLine("Enter 1, 2, 3, 4, 5, 6, or ? for help.");
            Console.WriteLine("Press ENTER to try again.");
            Console.ReadLine();
        }

        //Helper method for user
        static void WaitForPlayer()
        {
            Console.WriteLine("\nPress ENTER to continue.");
            Console.ReadLine();
        }





































    // john paul

//        //// Displays the abandoned dairy and handles the player's choices.
//        static void Dairy()
//        {
//            Console.Clear();
//            Console.WriteLine("A cold breeze moves through the empty building.");
//            Console.WriteLine("=== Welcome to the Abandoned Dairy ===");
//            Console.WriteLine("The dairy is dark, dusty and strangely quiet.");
//            Console.WriteLine("Moonlight slips through the dusty windows.");
//            Console.WriteLine("You feel that something mysterious is nearby.");
//            Console.WriteLine();

//            Console.WriteLine("What do you want to do?");
//            Console.WriteLine("1. Search the counter");
//            Console.WriteLine("2. Look behind the dairy");
//            Console.WriteLine("3. Inspect the shelves");
//            Console.WriteLine("4. Leave the dairy");
//            Console.WriteLine("5. Try the mysterious locked door");
//            Console.Write("Enter your choice: ");

//            string choice = Console.ReadLine()?.Trim() ?? "";

//            if (choice == "1")
//            {
//                Console.WriteLine("You search the dusty counter.");

//if (!hasRustyKey),
//                // Give the player the key only once.
//{
//    Console.WriteLine("You find an old rusty key!");
//    Console.WriteLine("The key feels strangely cold in your hand.");
//    hasRustyKey = true;
//}
//else
//{
//    Console.WriteLine("You already collected the rusty key.");
//}
//            }
//            else if (choice == "2")
//            {
//                Console.WriteLine("You look behind the dairy.");
//                Console.WriteLine("You hear a strange noise in the darkness.");
//                Console.WriteLine("You notice fresh footprints in the dirt.");
//            }
//            else if (choice == "3")
//                Console.WriteLine("The note reads: 'The key opens a hidden secret.'");
//            {
//                Console.WriteLine("You inspect the shelves.");
//                Console.WriteLine("You find an old note with a strange symbol.");
//                Console.WriteLine("The symbol looks like a warning.");
//            }
//            else if (choice == "4")
//            {
//                Console.WriteLine("You hear the door creak shut behind you.");
//                Console.WriteLine("You leave the dairy and return to the path.");
//                Console.WriteLine("You wonder what other secrets the dairy holds.");
//            else if (choice == "5")
//{
//    if (hasRustyKey)
//    {
//        Console.WriteLine("The rusty key unlocks the door!");
//        Console.WriteLine("Inside, you discover a dusty old journal.");
//    }
//    else
//    {
//        Console.WriteLine("The door is locked. Find the rusty key first.");
//    }
//}
//            }
//            else
//            {
//                Console.WriteLine("Invalid choice!");
//                Console.WriteLine("Please enter a number from 1 to 5.");
//            }

//            Console.WriteLine();
//            Console.WriteLine("Press Enter to return to your adventure...");
//            Console.ReadLine();
//        }






































    }
}
