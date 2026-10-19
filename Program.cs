using System.Collections;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace studio_project
{
    internal class Program
    {
        //Blake

        static void Main()
        {
            Console.WriteLine("Welcome to this as yet unnamed and unfinished game!\n\nIt is a puzzle game set in a haunted manor where your goal is to find jack-o'-lanterns. You will have preset options to pick from determining where you want to go, items you want to pick up, etc. Some options may not be available until you have gained items or knowledge from other rooms so it is worth revisiting places later on. If you are confused, just type '?' at any time and you will recieve a more in depth tutorial - not actually, the tutorial exists but is only accessible from a few areas at the moment");
            Console.WriteLine("\nPress enter to start the game");
            Console.ReadLine();
            // boolean arrays for inventory - remember to comment what number your items correspond to so we can keep track easier
            bool[] lanterns = new bool[3];
            lanterns[0] = false; lanterns[1] = false; lanterns[2] = false; // 0 = courtyard, 1 = kitchen, 2 = forest
            bool[] inv = new bool[3];
            inv[0] = false; inv[1] = false; // 0 = coins, 1 = pruning knife
            Courtyard(lanterns, inv);
        }
        static void Courtyard(bool[] lanterns, bool[] inv)
        {
            bool jack;
            if (lanterns[0] == true)
            {
                jack = true;
            }
            else
            {
                jack = false;
            }
            Console.Clear();
            Console.Write("You stand in front of an old, dilapidated manor, it's doors wide open and welcoming. The courtyard is in a state of disrepair, overgrown shrubs reach for the walls, wildflowers sprout through the cracked asphalt driveway, and cobwebs enshroud the windows. The moon-shadows of the dead trees surround you.");
            if (jack == false)
            {
                Console.WriteLine(" A jack-o'-lantern hangs in one of them.");
            }
            Console.WriteLine("\nWhat do you want to do?");
            if (jack == false)
            {
                Console.WriteLine("1. Enter manor\n2. Move to backyard\n3. Leave\n4. Approach jack-o'-lantern");
            }
            else
            {
                Console.WriteLine("1. Enter manor\n2. Backyard\n3. Leave");
            }
            string user = Console.ReadLine();
            if (user == "1")
            {
                Console.Clear();
                Console.WriteLine("You take the steps up to the front door and enter the manor.");
                Console.ReadLine();
                Hallway();
            }
            else if (user == "2")
            {
                Console.Clear();
                Console.WriteLine("You move around the manor to the backyard.");
                Backyard(lanterns, inv);
            }
            else if (user == "3")
            {
                Console.Clear();
                Console.WriteLine("The heavy gates of the couryard clang shut behind you as you leave. Thick midnight fog prevents you from properly survering your surroundings, but you are able to follow the road towards a bright glow in the distance. As you approach, you see a neon lit up welcome sign and realize you have found a dairy.");
                Console.ReadLine();
                Street(lanterns, inv);
            }
            else if (user == "4" && jack == false)
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
            else if (user == "?")
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
            bool coins;
            if (inv[0] == true)
            {
                coins = true;
            }
            else
            {
                coins = false;
            }
            Console.Clear();
            Console.WriteLine("The area is even more overgrown than the courtyard. There is a no longer running fountain and a dingy garden shed tucked away in the far corner.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Enter manor\n2. Move to courtyard\n3. Enter garden shed");
            if (coins == false)
            {
                Console.WriteLine("4. Investigate fountain");
            }
            string user = Console.ReadLine();
            if (user == "1")
            {
                Console.Clear();
                Console.WriteLine("You enter the manor through the backdoor.");
                Console.ReadLine();
                Backyard(lanterns, inv); // unsure what this room will be
            }
            else if (user == "2")
            {
                Console.Clear();
                Console.WriteLine("You move around the manor to the courtyard");
                Console.ReadLine();
                Courtyard(lanterns, inv);
            }
            else if (user == "3")
            {
                Console.Clear();
                Console.WriteLine("You trudge through the mud to enter the garden shed.");
                Console.ReadLine();
                GardenShed(lanterns, inv);
            }
            else if (user == "4" && coins == false)
            {
                Console.Clear();
                Console.WriteLine("You come closer to the fountain. The once marble structure is now slimey and covered in green. Larvae rests on the surface, the water here has been undisturbed for a long time. You can see coins lining the bottom of the fountain and are able to swipe them up");
                inv[0] = true;
                Console.ReadLine();
                Backyard(lanterns, inv);
            }
            else if (user == "?")
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
            bool knife;
            if (inv[1] == true)
            {
                knife = true;
            }
            else
            {
                knife = false;
            }
            Console.Clear();
            Console.Write("You are in a dark and cramped space that smells of mold and something rotten. Your only light is from the moon shining through cracks in the roof.");
            if (knife == false)
            {
                Console.WriteLine(" There's a pruning knife jutting out of the wall.");
            }
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Leave");
            if (knife == false)
            {
                Console.WriteLine("2. Grab pruning knife");
            }
            string user = Console.ReadLine();
            if (user == "1")
            {
                Console.Clear();
                Console.WriteLine("You leave the garden shed and return to the backyard.");
                Console.ReadLine();
                Backyard(lanterns, inv);
            }
            else if (user == "2" && knife == false)
            {
                Console.Clear();
                Console.WriteLine("You grab the pruning knife");
                inv[1] = true;
                Console.ReadLine();
                GardenShed(lanterns, inv);
            }
            else if (user == "?")
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
        static void Street(bool[] lanterns, bool[] inv)
        {
            Console.Clear();
            Console.WriteLine("You stand in front of the dairy. While the sign is bright and blinding, there are no other lights and there doesn't appear to be anyone else around.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Look around\n2. Enter dairy\n3. Return to manor");
            string user = Console.ReadLine();
            if (user == "1")
            {
                Console.Clear();
                Console.WriteLine("The road you were following appears to end at the dairy. All that surrounds you is the forest. You are alone.");
                Console.ReadLine();
                Street(lanterns, inv);
            }
            else if (user == "2")
            {
                Dairy();
            }
            else if (user == "3")
            {
                Console.Clear();
                Console.WriteLine("You follow the path back to the manor and enter the courtyard.");
                Console.ReadLine();
                Courtyard(lanterns, inv);
            }
            else if (user == "?")
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
            else if (input == chosen)
            {
                Console.WriteLine("You open the case successfully. Inside is a key radiating an sinister aura...");
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
                Console.WriteLine("You gave up and left.");
                return false;
            }
            else
            {
                Console.WriteLine("You successfully converted the binary to decimal.");
                return true;
            }
        }
        static void TextEvent()
        {
            Random rand = new Random();
            int x = rand.Next(1, 16);       //1/3 Chance to print one of these, otherwise does nothing
            switch (x)
            {
                case 1:
                    {
                        Console.WriteLine("You can feel yourself being watched...");
                        Console.WriteLine("Press ENTER to look around");
                        Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("You think you're completely alone.");
                        Console.WriteLine();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("A cold breeze passes...");
                        Console.WriteLine("Press ENTER to steady yourself");
                        Console.ReadLine();
                        Console.WriteLine();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("You feel chills down your spine...");
                        Console.WriteLine();
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("You don't feel safe here...");
                        Console.WriteLine();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("You can smell the rotting and decaying of pumpkins...");
                        Console.WriteLine();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

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
            Console.WriteLine("1. Enter kitchen");
            Console.WriteLine("2. Return to hallway");
            Console.WriteLine("3. Solve mysterious case file 1");

            string user = Console.ReadLine();

            if (user == "1")
            {
                Kitchen();
            }
            else if (user == "2")
            {
                Hallway();
            }

            //Case 1 Puzzle
            else if (user == "3")
            {
                Puzzle1();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                LivingRoom();
            }
            
        }

        // kitchen where the player can return to the living room 
        // attemp Puzzle 2
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
                Console.WriteLine("Thank you for playing our haunted manor demo!");    // Game Finished
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

                if (room == 0 && lanterns[2] == false)
                    Console.WriteLine("A glowing jack-o'-lantern rests beside a tree.");
                Console.WriteLine("\n1. Clearing\n2. Foggy path\n3. Briar patch\n4. Witch's grove");
                
                if (room == 0 && lanterns[2] == false)
                    Console.WriteLine("5. Pick up jack-o'-lantern");
                Console.WriteLine("6. Leave forest\n?. Help");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1": room = 0; break;
                    case "2": room = 1; break;
                    case "3": room = 2; break;
                    case "4": room = 3; break;
                    case "5":
                        if (room == 0 && lanterns[2] == false)
                        {
                            lanterns[2] = true;
                            Console.WriteLine("\nYou pick up the glowing jack-o'-lantern.");
                            Console.WriteLine("Its warm light cuts through the darkness.");
                            Console.WriteLine("You have collected a lantern!");
                            Console.WriteLine("\nPress ENTER to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            ShowInvalidChoice();
                        }
                        break;

                    case "6":
                        Console.WriteLine("\nAre you sure you want to leave the forest? (Y/N)");
                        string confirm = Console.ReadLine().ToUpper();

                        if (confirm == "Y")
                        {
                            Street(lanterns, inv);
                            return;
                        }
                        else if (confirm == "N")
                        {
                            Console.WriteLine("You decide to remain in the forest.");
                            Console.ReadLine();
                        }
                        else
                        {
                            ShowInvalidChoice();
                        }
                        break;

                    case "?":
                        Help();
                        break;

                    default:
                        ShowInvalidChoice();
                        break;
                }
            }
        }
        static void ShowInvalidChoice()
        {
            Console.WriteLine("\nThat is not a valid choice!");
            Console.WriteLine("Please enter 1, 2, 3, 4, 5, 6, or ? for help.");
            Console.WriteLine("Press ENTER to try again.");
            Console.ReadLine();
        }







































        //// Displays the abandoned dairy and handles the player's choices.
        static void Dairy()
        {
            Console.Clear();

            Console.WriteLine("=== Welcome to the Abandoned Dairy ===");
            Console.WriteLine("The dairy is dark, dusty and strangely quiet.");
            Console.WriteLine("Moonlight slips through the dusty windows.");
            Console.WriteLine("You feel that something mysterious is nearby.");
            Console.WriteLine();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Search the counter");
            Console.WriteLine("2. Look behind the dairy");
            Console.WriteLine("3. Inspect the shelves");
            Console.WriteLine("4. Leave the dairy");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            if (choice == "1")
            {
                Console.WriteLine("You search the dusty counter.");
                Console.WriteLine("You find an old rusty key!");
                Console.WriteLine("The key feels strangely cold in your hand.");
            }
            else if (choice == "2")
            {
                Console.WriteLine("You look behind the dairy.");
                Console.WriteLine("You hear a strange noise in the darkness.");
                Console.WriteLine("You notice fresh footprints in the dirt.");
            }
            else if (choice == "3")
            {
                Console.WriteLine("You inspect the shelves.");
                Console.WriteLine("You find an old note with a strange symbol.");
                Console.WriteLine("The symbol looks like a warning.");
            }
            else if (choice == "4")
            {
                Console.WriteLine("You leave the dairy and return to the path.");
                Console.WriteLine("You wonder what other secrets the dairy holds.");
            }
            else
            {
                Console.WriteLine("Invalid choice!");
                Console.WriteLine("Please enter a number from 1 to 4.");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to your adventure...");
            Console.ReadLine();
        }






































    }
}