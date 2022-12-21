using System;

namespace CalculatorApplication
{
    internal class Program
    {

        static void Main(string[] args)
        {

            WelcomeText();
           

        }


        public static void WelcomeText()
        {
            Console.WriteLine("welcome to calendar, would you like to read the instruction before using calendar? is yes press Y, if not press any other key");

            string instructionAnswer = Console.ReadLine();

            if (instructionAnswer == "Y"|| instructionAnswer == "y")
            {
                Console.WriteLine(
                    "Welcome to Calendar, please read the instructions carefully to ensure a productive use:"
                    );
                
            }

            Start();

            
        }

        public static void Start()
        {
            Console.WriteLine("Let us start!");
            Console.WriteLine("what would you like to do? choose your oprion by typing corresponding letter");
            Console.WriteLine("A. add a new event");
            Console.WriteLine("B. find an event and amend it");
            Console.WriteLine("C. see all events");
            Console.WriteLine("D. delete an event");

            string actionAnswer = Console.ReadLine();

            if (actionAnswer == "A" || actionAnswer == "a")
            {

            }

            else if (actionAnswer == "B" || actionAnswer == "b")
            {

            }

            else if (actionAnswer == "C" || actionAnswer == "c")
            {

            }

            else if (actionAnswer == "D" || actionAnswer == "d")
            {

            }

            else
            {
                Console.WriteLine("please choose from available answers");
                Start();
            }


        }



    }




}