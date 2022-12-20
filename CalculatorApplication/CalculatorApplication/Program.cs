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

            if (instructionAnswer == "Y")
            {
                Console.WriteLine(
                    "Welcome to Calendar, please read the instructions carefully to ensure a productive use:"
                    );
            }

            
        }



    }




}