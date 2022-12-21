using System;
using CalculatorApplication.Events.EventTypes;

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
                Console.WriteLine("ok, let's add a new event, please answer the questions below: what type of event would you like to create?");
                Console.WriteLine("A. a general event");
                Console.WriteLine("B. a holliday event");
                Console.WriteLine("C. a Meeting");
                Console.WriteLine("D. an online event");

                string eventTypeAnswer = Console.ReadLine();

                if (eventTypeAnswer == "A" || eventTypeAnswer == "a")
                {
                    var newMeeting = new GeneralEvent();

                    newMeeting.NewEvent();

                    Console.WriteLine("describe your event");
                    var newEventDesc = Console.ReadLine();
                    newMeeting.EventDescription = newEventDesc.ToString();

                    Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, {newMeeting.EventDescription}");
                }


                else if (eventTypeAnswer == "B" || eventTypeAnswer == "b")
                {
                    var newMeeting = new Holliday();

                    newMeeting.NewEvent();

                    Console.WriteLine("describe your event");
                    var newEventDesc = Console.ReadLine();
                    newMeeting.HollidayName = newEventDesc.ToString();

                    Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, it's a holliday for {newMeeting.HollidayName}");
                }
                else if (eventTypeAnswer == "C" || eventTypeAnswer == "c")
                {
                    var newMeeting = new Meeting();

                    newMeeting.NewEvent();

                    Console.WriteLine("describe your event");
                    var newEventDesc = Console.ReadLine();
                    newMeeting.ColleagueName = newEventDesc.ToString();

                    Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, you are meeting with {newMeeting.ColleagueName}");
                }
                else if (eventTypeAnswer == "D" || eventTypeAnswer == "d")
                {
                    var newMeeting = new OnlineMeeting();

                    newMeeting.NewEvent();

                    Console.WriteLine("describe your event");
                    var newEventDesc = Console.ReadLine();
                    newMeeting.MeetingPlatform = newEventDesc.ToString();

                    Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, you are meeting on {newMeeting.MeetingPlatform}");
                }






            }

            else if (actionAnswer == "B" || actionAnswer == "b")
            {
                Console.WriteLine("you chose b");
            }

            else if (actionAnswer == "C" || actionAnswer == "c")
            {
                Console.WriteLine("you chose c");
            }

            else if (actionAnswer == "D" || actionAnswer == "d")
            {
                Console.WriteLine("you chose d");
            }

            else
            {
                Console.WriteLine("please choose from available answers");
                Start();
            }


        }



    }




}