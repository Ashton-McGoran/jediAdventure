using System;

namespace greatAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int lives = 0, force = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref force, ref health, r);
            while (lives > 0 && force > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref force, ref health);
                else
                    actions(r.Next(10), ref lives, ref force, ref health);
                checkResults(ref round, ref lives, ref force, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (force <= 0)
                Console.WriteLine("Your force is low and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before it's completion");

        }

        private static void checkResults(ref int round, ref int lives, ref int force, ref int health, ref bool win)
        {
            round++; // Add 1 to the round variable

            Console.WriteLine($"Round {round}");
            Console.WriteLine($"Lives: {lives} | Force: {force} | Health: {health}");

            // Check if the round is greater than or equal to 25
            if (round >= 25)
            {
                win = true;
            }
        }

        private static void actions(int num, ref int lives, ref int force, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You met three ewoks who were not happy that their chak juice was gone.");
                    Console.WriteLine("You lose 1 unit of health and 1 force");
                    health -= 1;
                    force -= 1;
                    break;
                case 1:
                    Console.WriteLine("You were abducted by jawwas and had to be rescued by a the Mandolorian and Grogu");
                    Console.WriteLine("You lost 2 units of health and force and 1 life");
                    health -= 2;
                    force -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("You encountered a group of mischievous Rodians.");
                    Console.WriteLine("They stole 1 unit of force and caused chaos.");
                    force -= 1;
                    break;
                case 3:
                    Console.WriteLine("You fell into a Sarlacc pit but managed to climb out.");
                    Console.WriteLine("You lost 1 unit of health.");
                    health -= 1;
                    break;
                case 4:
                    Console.WriteLine("You accidentally disturbed a nest of Genosians.");
                    Console.WriteLine("You lose 1 unit of health and 1 unit of force.");
                    health -= 1;
                    force -= 1;
                    break;
                case 5:
                    Console.WriteLine("You saved a fellow traveler from a the Trandoshans.");
                    Console.WriteLine("The traveler granted you 2 units of health, force, and lives");
                    health += 2;
                    force += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You babysat for a woman who lived on Kamino.");
                    Console.WriteLine("You gain 3 units of health and force");
                    health += 3;
                    force += 3;
                    break;
                case 7:
                    Console.WriteLine("You discovered a hidden jedi temple.");
                    Console.WriteLine("You gain 2 units of force and 1 life");
                    force += 2;
                    lives += 1;
                    break;
                case 8:
                    Console.WriteLine("You encountered a wise jedi master who shared knowledge with you.");
                    Console.WriteLine("You gain 2 units of force and health");
                    force += 2;
                    health += 2;
                    break;
                case 9:
                    Console.WriteLine("You were caught in a rainstorm but found shelter in a friendly village of wookies.");
                    Console.WriteLine("You gain 1 unit of health and 2 units of force");
                    health += 1;
                    force += 2;
                    break;
                default:
                    Console.WriteLine("You saved a human from the hutts.");
                    Console.WriteLine("You gain 2 lives and 2 units of force");
                    force += 2;
                    lives += 2;
                    break;
            }
        }

        private static int chooseDirection()
        {
            int direction;

            Console.WriteLine("You have come to a crossroad, enter 1 to travel left and 2 to travel right");

            // Data validation loop
            while (!int.TryParse(Console.ReadLine(), out direction) || (direction != 1 && direction != 2))
            {
                Console.WriteLine("You entered an invalid number, please enter 1 for left or 2 for right");
            }

            return direction;
        }


        private static void initValues(ref int lives, ref int force, ref int health, Random r)
        {
            lives = r.Next(10) + 1;    // Random number between 1 and 10
            force = r.Next(15) + 5;    // Random number between 5 and 15
            health = r.Next(14) + 5;   // Random number between 5 and 14
        }
    }
}