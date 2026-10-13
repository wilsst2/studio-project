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
            Console.Clear();
            Console.WriteLine("placeholder for scene setting & manor description in courtyard location");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Leave\n2. Enter manor\n3. (things that will be specific to courtyard area)");
            int user = Convert.ToInt32(Console.ReadLine());
            switch (user)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("The heavy gates of the couryard clang shut behind you as you leave. Thick midnight fog prevents you from properly survering your surroundings, but you are able to follow the road towards a bright glow in the distance. As you approach, you see a neon lit up welcome sign and realize you have found a dairy.");
                    Console.ReadLine();
                    Street();
                    break;
                case 2:
                    Console.WriteLine("Placeholder that will eventually call a method");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("placeholder that will eventually call a method");
                    Console.ReadLine();
                    break;
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
                Console.WriteLine("\nThe road you were following appears to end at the dairy. All that surrounds you is the forest. You are alone.");
                Console.ReadLine();
                Street();
            }
            else if (user == "2")
            {
                Dairy();
            }
            else if (user == "3")
            {
                Console.WriteLine("Placeholder");
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