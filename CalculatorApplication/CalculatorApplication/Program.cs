using System;
using CalculatorApplication.Events;
using CalculatorApplication.Events.EventTypes;
using Newtonsoft.Json;

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
            Console.WriteLine("E. Read what went wrong");

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
                    var newMeeting = new BaseEvent();

                    newMeeting.NewEvent();

                    Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, {newMeeting.EventDescription}");

                    var serializedEvent = JsonConvert.SerializeObject(newMeeting);

                    string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

                    string filePath = path + $@"{newMeeting.Day}.{newMeeting.Month}.BaseEvent.txt";

                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath);
                    }

                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine("---");
                        sw.WriteLine(serializedEvent);
                        sw.WriteLine("---");
                    }
                }



                else if (eventTypeAnswer == "B" || eventTypeAnswer == "b")
                {
                    var newMeeting = new Holliday();

                    newMeeting.NewEvent();

                    Console.WriteLine("describe your event");
                    var newEventDesc = Console.ReadLine();
                    newMeeting.HollidayName = newEventDesc.ToString();

                    Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, it's a holliday for {newMeeting.HollidayName}");

                    var serializedEvent = JsonConvert.SerializeObject(newMeeting);

                    string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

                    string filePath = path + $@"{newMeeting.Day}.{newMeeting.Month}.Holliday.txt";

                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath);
                    }

                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine("---");
                        sw.WriteLine(serializedEvent);
                        sw.WriteLine("---");
                    }
                }



                else if (eventTypeAnswer == "C" || eventTypeAnswer == "c")
                {
                    var newMeeting = new Meeting();

                    newMeeting.NewEvent();

                    Console.WriteLine("describe your event");
                    var newEventDesc = Console.ReadLine();
                    newMeeting.ColleagueName = newEventDesc.ToString();

                    Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, you are meeting with {newMeeting.ColleagueName}");

                    var serializedEvent = JsonConvert.SerializeObject(newMeeting);

                    string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

                    string filePath = path + $@"{newMeeting.Day}.{newMeeting.Month}.Meeting.txt";

                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath);
                    }

                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine("---");
                        sw.WriteLine(serializedEvent);
                        sw.WriteLine("---");
                    }
                }



                else if (eventTypeAnswer == "D" || eventTypeAnswer == "d")
                {
                    var newMeeting = new OnlineMeeting();

                    newMeeting.NewEvent();

                    Console.WriteLine("describe your event");
                    var newEventDesc = Console.ReadLine();
                    newMeeting.MeetingPlatform = newEventDesc.ToString();

                    Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, you are meeting on {newMeeting.MeetingPlatform}");

                    var serializedEvent = JsonConvert.SerializeObject(newMeeting);

                    string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

                    string filePath = path + $@"{newMeeting.Day}.{newMeeting.Month}.OnlineEvent.txt";

                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath);
                    }

                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine("---");
                        sw.WriteLine(serializedEvent);
                        sw.WriteLine("---");
                    }
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

            else if (actionAnswer == "E" || actionAnswer == "e")
            {
                Console.WriteLine("here is the history of errors:");

                string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/ExceptionStorage/PastExceptions.txt";


                string fileText = File.ReadAllText(path);
                var splittedExs = fileText.Split("---");

                foreach (var item in splittedExs)
                {
                    var deserializedExs = JsonConvert.DeserializeObject(item);
                    Console.WriteLine(deserializedExs);

                }

            }

            else
            {
                
                Console.WriteLine("please choose from available answers");
                
            }


        }

        public static class EventObjectLibrary
        {
            static void recordEvent (string recordableObject)
            {

            }




        }



       



    }





}