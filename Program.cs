using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace studio_project
{
    internal class Program
    {
        static void Main()
        {
            //Blake
            Console.WriteLine("Welcome to this as yet unnamed and unfinished game!\n\nIt is a puzzle game set in a haunted manor where your goal is to find jack-o'-lanterns. You will have preset options to pick from determining where you want to go, items you want to pick up, etc. Some options may not be available until you have gained items or knowledge from other rooms so it is worth revisiting places later on. If you are confused, just type 'help' and you will recieve a more in depth tutorial (this is not finished yet so you actually won't - it will instead break the game)");
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
            string user = Console.ReadLine();
            if (user == "1")
            {
                Console.Clear();
                Console.WriteLine("The manor is in a state of disrepair. Overgrown shrubs reach for the walls, wildflowers sprout through the cracked asphalt driveway, and cobwebs enshroud the windows.");
                Console.ReadLine();
                Courtyard();
            }
            else if (user == "2")
            {
                Console.Clear();
                Console.WriteLine("You take the steps up to the front door and enter the manor.");
                Console.ReadLine();
                //method to call whatever the first room is
            }
            else if (user == "3")
            {
                Console.Clear();
                Console.WriteLine("The heavy gates of the couryard clang shut behind you as you leave. Thick midnight fog prevents you from properly survering your surroundings, but you are able to follow the road towards a bright glow in the distance. As you approach, you see a neon lit up welcome sign and realize you have found a dairy.");
                Console.ReadLine();
                Street();
            }
        }

        static void Street()
        {
            Console.Clear();
            Console.WriteLine("You stand in front of the dairy. While the sign is bright and blinding, there are no other lights and there doesn't appear to be anyone else around.");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Look around\n2. Enter dairy\n3. Return to manor");
            string user = (Console.ReadLine());

            if (user == "1")
            {
                Console.Clear();
                Console.WriteLine("The road you were following appears to end at the dairy. All that surrounds you is the forest. You are alone.");
                Console.ReadLine();
                Street();
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
                Courtyard();
            }
        }













            //Dominik







































            //Akirah







































            //David







































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