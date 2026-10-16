using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace studio_project
{
    internal class Program
    {
        static void Main()
        {
            //Blake
            Console.WriteLine("Welcome to this as yet unnamed and unfinished game!\n\nIt is a puzzle game set in a haunted manor where your goal is to find jack-o'-lanterns. You will have preset options to pick from determining where you want to go, items you want to pick up, etc. Some options may not be available until you have gained items or knowledge from other rooms so it is worth revisiting places later on. If you are confused, just type '?' at any time and you will recieve a more in depth tutorial");
            Console.WriteLine("\nPress enter to start the game");
            Console.ReadLine();
            Courtyard();
        }

        static void Courtyard()
        {
            Console.Clear();
            Console.WriteLine("You stand in front of an old manor. The building looms over you, trapping you between itself and the moon-shadows of the trees. The front doors are open wide and welcoming.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Look around\n2. Enter manor\n3. Leave");
            char user = Convert.ToChar(Console.ReadLine());
            if (user == '1')
            {
                Console.Clear();
                Console.WriteLine("The manor is in a state of disrepair. Overgrown shrubs reach for the walls, wildflowers sprout through the cracked asphalt driveway, and cobwebs enshroud the windows.");
                Console.ReadLine();
                Courtyard();
            }
            else if (user == '2')
            {
                Console.Clear();
                Console.WriteLine("You take the steps up to the front door and enter the manor.");
                Console.ReadLine();
                //method to call whatever the first room is
            }
            else if (user == '3')
            {
                Console.Clear();
                Console.WriteLine("The heavy gates of the couryard clang shut behind you as you leave. Thick midnight fog prevents you from properly survering your surroundings, but you are able to follow the road towards a bright glow in the distance. As you approach, you see a neon lit up welcome sign and realize you have found a dairy.");
                Console.ReadLine();
                Street();
            }
            else if (user == '?')
            {
                Help();
                Courtyard();
            }
        }

        static void Street()
        {
            Console.Clear();
            Console.WriteLine("You stand in front of the dairy. While the sign is bright and blinding, there are no other lights and there doesn't appear to be anyone else around.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Look around\n2. Enter dairy\n3. Return to manor");
            char user = Convert.ToChar(Console.ReadLine());
            if (user == '1')
            {
                Console.Clear();
                Console.WriteLine("The road you were following appears to end at the dairy. All that surrounds you is the forest. You are alone.");
                Console.ReadLine();
                Street();
            }
            else if (user == '2')
            {
                Dairy();
            }
            else if (user == '3')
            {
                Console.Clear();
                Console.WriteLine("You follow the path back to the manor and enter the courtyard.");
                Console.ReadLine();
                Courtyard();
            }
            else if (user == '?')
            {
                Help();
                Street();
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
        static void Puzzle1()
        {
            Random rand = new Random();
            string[] puzzle = { "sinister", "october", "apparition", "halloween", };
            string chosen = puzzle[rand.Next(puzzle.Length)]; //Chooses a random word from the puzzle array
            string input;
            string choice = "Y";
            char[] letters = chosen.ToCharArray(); //Convert chosen string to array of characters                    
            for (int i = 0; i < letters.Length; i++) //Repeat for every letter in the array
            {
                int randomIndex = rand.Next(letters.Length);     //Chooses random char in the array
                char temp = letters[i];                          //Stores letter about to be changed in temp
                letters[i] = letters[randomIndex];              //Changes the stored letter that was just stored to the chosen random char
                letters[randomIndex] = temp;                    //Stores the used word in temp
            }
            string jumble = new string(letters);                //Creates a string with the new jumbled word
            Console.WriteLine("There's a strange set of letters carved into the case:");
            Console.WriteLine();
            Console.WriteLine(jumble);
            Console.WriteLine();
            Console.WriteLine("Maybe unscrambling this jumbled word will open it?");
            do
            {
                Console.Write("Attempt to unscramble: ");
                input = Console.ReadLine().ToLower();
                if (input != chosen)                            //Get user's attempt to unscramble word
                {
                    Console.Write("Nothing happened, try again? (Y/N): ");
                    choice = Console.ReadLine().ToUpper();      //Get user's choice on if they want to replay or leave
                }
            } while (input != chosen && choice == "Y");         //Check: User hasn't gotten the puzzle correct and insists on retrying
            if (choice != "Y")
            {
                Console.WriteLine("You give up and leave the case.");
            }
            if (input == chosen)
            {
                Console.WriteLine("You open the case successfully. Inside is a key radiating an sinister aura...");
                Console.WriteLine("You've won, thank you for playtesting our demo! We hope you enjoyed.");
                Console.ReadLine();
            }
        }
        static void Puzzle2()
        {

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
            Console.WriteLine("You are in the hallway of the haunted manor.");
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
        static void LivingRoom()
        {
            Console.Clear();
            Console.WriteLine("You enter the living room.");
            Console.WriteLine("Dusty furniture fills the room, and an old fireplace stands against the wall.");
            Console.WriteLine("There is one door leading into the kitchen.");

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Enter kitchen");
            Console.WriteLine("2. Return to hallway");

            string user = Console.ReadLine();

            if (user == "1")
            {
                Kitchen();
            }
            else if (user == "2")
            {
                Hallway();
            }
        }

        // kitchen that include an option to go back to the living rooom
        static void Kitchen()
        {
            Console.Clear();
            Console.WriteLine("You enter the kitchen.");
            Console.WriteLine("Old cupboards line the walls, and rusty pots hang from the ceiling.");
            Console.WriteLine("A rotten smell lingers in the air.");

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Return to living room");

            string user = Console.ReadLine();

            if (user == "1")
            {
                LivingRoom();
            }
        }














































        //David
        // ==========================================
        // David's Haunted Forest Game Loop Method
        // ==========================================
        //static void ExploreForest()
        //{
        //    while (forestRoom != "exit")
        //    {
        //        Console.Clear();

        //        // 1. BLAKE-STYLE ROOM DESCRIPTIONS & OPTIONS
        //        if (forestRoom == "clearing")
        //        {
        //            Console.WriteLine("--- THE FOREST CLEARING ---\nMist clings to the trees. The wind howls.");
        //            Console.WriteLine("\nWhat do you want to do?\n1. Look around\n2. Go to Foggy Path (West)\n3. Go to Briar Patch (East)\n4. Go to Witch's Grove (South)\n5. Return to street");
        //        }
        //        else if (forestRoom == "foggy_path")
        //        {
        //            Console.WriteLine("--- THE FOGGY PATH ---");
        //            Console.WriteLine(hasForestLantern ? "The stump is empty." : "🎃 A Jack-o'-Lantern glows on a stump!");
        //            Console.WriteLine("\nWhat do you want to do?\n1. Look around\n2. " + (hasForestLantern ? "Turn back" : "Grab Lantern") + "\n3. Turn back");
        //        }
        //        else if (forestRoom == "briar_patch")
        //        {
        //            Console.WriteLine("--- THE BRIAR PATCH ---\nOuch! You stumbled into sharp thorns.");
        //            Console.WriteLine("\nWhat do you want to do?\n1. Look around\n2. Back away to clearing");
        //        }
        //        else if (forestRoom == "witch_grove")
        //        {
        //            Console.WriteLine("--- THE WITCH'S GROVE ---\nA quiet grove with an old stone altar.");
        //            Console.WriteLine("\nWhat do you want to do?\n1. Look at altar\n2. Back away to clearing");
        //        }

        //        // 2. GET USER INPUT (MATCHING BLAKE'S VARIABLE NAME)
        //        string user = Console.ReadLine();

        //        // 3. SHORT MOVEMENT LOGIC
        //        if (forestRoom == "clearing")
        //        {
        //            if (user == "1") { Console.Clear(); Console.WriteLine("The forest is thick and spooky."); Console.ReadLine(); }
        //            else if (user == "2") forestRoom = "foggy_path";
        //            else if (user == "3") forestRoom = "briar_patch";
        //            else if (user == "4") forestRoom = "witch_grove";
        //            else if (user == "5") forestRoom = "exit";
        //        }
        //        else if (forestRoom == "foggy_path")
        //        {
        //            if (user == "1") { Console.Clear(); Console.WriteLine("The fog shifts like shadows."); Console.ReadLine(); }
        //            else if (user == "2" && !hasForestLantern) { Console.Clear(); hasForestLantern = true; Console.WriteLine("🎉 Grabbed the Jack-o'-Lantern!"); Console.ReadLine(); }
        //            else if (user == "3" || (user == "2" && hasForestLantern)) forestRoom = "clearing";
        //        }
        //        else if (forestRoom == "briar_patch")
        //        {
        //            if (user == "1") { Console.Clear(); Console.WriteLine("Thorns catch your clothes."); Console.ReadLine(); }
        //            else if (user == "2") forestRoom = "clearing";
        //        }
        //        else if (forestRoom == "witch_grove")
        //        {
        //            if (user == "1") { Console.Clear(); Console.WriteLine("The altar is covered in runes."); Console.ReadLine(); }
        //            else if (user == "2") forestRoom = "clearing";
        //        }
        //    }

        //    // 4. HANDOFF BACK TO BLAKE'S STREET METHOD
        //    forestRoom = "clearing"; // Reset location for next time they enter
        //    Console.Clear();
        //    Console.WriteLine("You follow the path back out to the open road.");
        //    Console.ReadLine();
        //    Street();
        //}






































        //John
        static void Dairy()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Abandoned Dairy!");
            Console.WriteLine("The dairy is dark, dusty and strangely quiet.");
            Console.WriteLine("You feel that something mysterious is nearby.");
            Console.WriteLine();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Search the counter");
            Console.WriteLine("2. Look behind the dairy");
            Console.WriteLine("3. Inspect the shelves");
            Console.WriteLine("4. Leave the dairy");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("You search the dusty counter.");
                Console.WriteLine("You find an old rusty key!");
            }
            else if (choice == "2")
            {
                Console.WriteLine("You look behind the dairy.");
                Console.WriteLine("You hear a strange noise in the darkness.");
            }
            else if (choice == "3")
            {
                Console.WriteLine("You inspect the shelves.");
                Console.WriteLine("You find an old note with a strange symbol.");
            }
            else if (choice == "4")
            {
                Console.WriteLine("You leave the dairy and return to the path.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }





































    }
}