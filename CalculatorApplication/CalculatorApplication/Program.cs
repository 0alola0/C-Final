using System;
using CalculatorApplication.Events;
using CalculatorApplication.Events.EventTypes;
using CalculatorApplication.Extentions;
using Newtonsoft.Json;

namespace CalculatorApplication
{
    internal class Program
    {

        static void Main(string[] args)
        {

            WelcomeText();
           

        }

        public static string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";



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
            Console.WriteLine("1. add a new event");
            Console.WriteLine("2. find an event and amend it");
            Console.WriteLine("3. see all events");
            Console.WriteLine("4. delete an event");
            Console.WriteLine("5. Read errors");

            string actionAnswer = Console.ReadLine();

            switch(actionAnswer)
            {
                case "1":
                    Console.WriteLine("ok, let's add a new event, please answer the questions below: what type of event would you like to create?");
                    Console.WriteLine("1. a general event");
                    Console.WriteLine("2. a holliday event");
                    Console.WriteLine("3. a Meeting");
                    Console.WriteLine("4. an online event");


                    string eventTypeAnswer = Console.ReadLine();
                    switch(eventTypeAnswer)
                    {
                        case "1":

                            var newEvent = new BaseEvent();

                            newEvent.NewEvent();

                            var serializedEvent = JsonConvert.SerializeObject(newEvent);

                            ProcessFile.SaveFile(serializedEvent, newEvent.fullPath);
                            break;


                        case "2":


                            var newHolliday = new Holliday();

                            newHolliday.NewEvent();

                            var serializedHolliday = JsonConvert.SerializeObject(newHolliday);

                            ProcessFile.SaveFile(serializedHolliday, newHolliday.fullPath);
                            break;

                        case "3":

                            var newMeeting = new Meeting();

                            newMeeting.NewEvent();

                            var serializedMeeting = JsonConvert.SerializeObject(newMeeting);

                            ProcessFile.SaveFile(serializedMeeting, newMeeting.fullPath);

                            break;

                        case "4":

                            var newOnlineMeeting = new OnlineMeeting();

                            newOnlineMeeting.NewEvent();

                            var serializedOnlineMeeting = JsonConvert.SerializeObject(newOnlineMeeting);

                            ProcessFile.SaveFile(serializedOnlineMeeting, newOnlineMeeting.fullPath);

                            break;


                        default:
                            Console.WriteLine("please choose from available options");
                            break;

                    }

                    break;


                case "2":

                    Console.WriteLine("for what date do you want to change an event? input month and then day");
                    var changeMonth = Console.ReadLine().ToString();
                    var changeDay = Console.ReadLine().ToString();

                    Console.WriteLine("what type of event do you want to see?");
                    Console.WriteLine("1. a general event");
                    Console.WriteLine("2. a holliday event");
                    Console.WriteLine("3. a Meeting");
                    Console.WriteLine("4. an online event");
                    string filePathAmend;

                    var amendAnswer = Console.ReadLine();


                    switch (amendAnswer)
                    {
                        case "1":

                            filePathAmend = path + $@"{changeDay}.{changeMonth}.BaseEvent.txt";

                            BaseEvent.AmendEvent(filePathAmend);


                            var newEvent = new BaseEvent();

                            newEvent.NewEvent();

                            var serializedEvent = JsonConvert.SerializeObject(newEvent);

                            ProcessFile.SaveFile(serializedEvent, newEvent.fullPath);

                            break;

                        case "2":

                            filePathAmend = path + $@"{changeDay}.{changeMonth}.Holliday.txt";
                            Holliday.AmendEvent(filePathAmend);


                            var newHolliday = new Holliday();

                            newHolliday.NewEvent();

                            var serializedHolliday = JsonConvert.SerializeObject(newHolliday);

                            ProcessFile.SaveFile(serializedHolliday, newHolliday.fullPath);

                            break;

                        case "3":

                            filePathAmend = path + $@"{changeDay}.{changeMonth}.Meeting.txt";
                            Meeting.AmendEvent(filePathAmend);


                            var newMeeting = new Meeting();

                            newMeeting.NewEvent();

                            var serializedMeeting = JsonConvert.SerializeObject(newMeeting);

                            ProcessFile.SaveFile(serializedMeeting, newMeeting.fullPath);

                            break;

                            break;

                        case "4":

                            filePathAmend = path + $@"{changeDay}.{changeMonth}.OnlineMeeting.txt";
                            OnlineMeeting.AmendEvent(filePathAmend);


                            var newOnlineMeeting = new OnlineMeeting();

                            newOnlineMeeting.NewEvent();

                            var serializedOnlineMeeting = JsonConvert.SerializeObject(newOnlineMeeting);

                            ProcessFile.SaveFile(serializedOnlineMeeting, newOnlineMeeting.fullPath);


                            break;


                        default:
                            Console.WriteLine("please choose from available options");
                            break;


                    }
                    break;

                 


                case "3":

                    Console.WriteLine("for what date do you want to see events? input month and then day");
                    var month = Console.ReadLine().ToString();
                    var day = Console.ReadLine().ToString();

                    Console.WriteLine("what type of event do you want to see?");
                    Console.WriteLine("1. a general event");
                    Console.WriteLine("2. a holliday event");
                    Console.WriteLine("3. a Meeting");
                    Console.WriteLine("4. an online event");
                    string filePath;

                    var typeAnswer = Console.ReadLine();


                    switch (typeAnswer)
                    {
                        case "1":

                            filePath = path + $@"{day}.{month}.BaseEvent.txt";

                            BaseEvent.SeeEventsForDate(filePath);
                            break;

                        case "2":

                            filePath = path + $@"{day}.{month}.Holliday.txt";
                            Holliday.SeeEventsForDate(filePath);

                            break;

                        case "3":

                            filePath = path + $@"{day}.{month}.Meeting.txt";
                            Meeting.SeeEventsForDate(filePath);

                            break;

                        case "4":

                            filePath = path + $@"{day}.{month}.OnlineMeeting.txt";
                            OnlineMeeting.SeeEventsForDate(filePath);

                            break;


                        default:
                            Console.WriteLine("please choose from available options");
                            break;


                    }
                    break;

                case "4":
                    Console.WriteLine("for what date do you want to delete an event? input month and then day");
                    var deleteMonth = Console.ReadLine().ToString();
                    var deleteDay = Console.ReadLine().ToString();

                    Console.WriteLine("what type of event do you want to see?");
                    Console.WriteLine("1. a general event");
                    Console.WriteLine("2. a holliday event");
                    Console.WriteLine("3. a Meeting");
                    Console.WriteLine("4. an online event");
                    string filePathDelete;

                    var DeleteAnswer = Console.ReadLine();


                    switch (DeleteAnswer)
                    {
                        case "1":

                            filePathDelete = path + $@"{deleteDay}.{deleteMonth}.BaseEvent.txt";

                            BaseEvent.DeleteEvent(filePathDelete);
                            break;

                        case "2":

                            filePathDelete = path + $@"{deleteDay}.{deleteMonth}.Holliday.txt";
                            Holliday.DeleteEvent(filePathDelete);

                            break;

                        case "3":

                            filePathDelete = path + $@"{deleteDay}.{deleteMonth}.Meeting.txt";
                            Meeting.DeleteEvent(filePathDelete);

                            break;

                        case "4":

                            filePathDelete = path + $@"{deleteDay}.{deleteMonth}.OnlineMeeting.txt";
                            OnlineMeeting.DeleteEvent(filePathDelete);

                            break;


                        default:
                            Console.WriteLine("please choose from available options");
                            break;


                    }
                    break;

                case "5":
                    Console.WriteLine("here is the history of errors");
                    ProcessException.ReadExceptions();
                    break;

                default:
                    Console.WriteLine("please choose from available options");
                    break;



            }
            



        }





       



    }





}



//backup


//if (actionAnswer == "A" || actionAnswer == "a")
//{
//    Console.WriteLine("ok, let's add a new event, please answer the questions below: what type of event would you like to create?");
//    Console.WriteLine("A. a general event");
//    Console.WriteLine("B. a holliday event");
//    Console.WriteLine("C. a Meeting");
//    Console.WriteLine("D. an online event");

//    string eventTypeAnswer = Console.ReadLine();



//    if (eventTypeAnswer == "A" || eventTypeAnswer == "a")
//    {
//        var newMeeting = new BaseEvent();

//        newMeeting.NewEvent();

//        Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, {newMeeting.EventDescription}");

//        var serializedEvent = JsonConvert.SerializeObject(newMeeting);

//        string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

//        string filePath = path + $@"{newMeeting.Day}.{newMeeting.Month}.BaseEvent.txt";

//        if (!File.Exists(filePath))
//        {
//            File.Create(filePath);
//        }

//        using (StreamWriter sw = File.AppendText(filePath))
//        {
//            sw.WriteLine("---");
//            sw.WriteLine(serializedEvent);
//            sw.WriteLine("---");
//        }
//    }



//    else if (eventTypeAnswer == "B" || eventTypeAnswer == "b")
//    {
//        var newMeeting = new Holliday();

//        newMeeting.NewEvent();

//        Console.WriteLine("describe your event");
//        var newEventDesc = Console.ReadLine();
//        newMeeting.HollidayName = newEventDesc.ToString();

//        Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, it's a holliday for {newMeeting.HollidayName}");

//        var serializedEvent = JsonConvert.SerializeObject(newMeeting);

//        string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

//        string filePath = path + $@"{newMeeting.Day}.{newMeeting.Month}.Holliday.txt";

//        if (!File.Exists(filePath))
//        {
//            File.Create(filePath);
//        }

//        using (StreamWriter sw = File.AppendText(filePath))
//        {
//            sw.WriteLine("---");
//            sw.WriteLine(serializedEvent);
//            sw.WriteLine("---");
//        }
//    }



//    else if (eventTypeAnswer == "C" || eventTypeAnswer == "c")
//    {
//        var newMeeting = new Meeting();

//        newMeeting.NewEvent();

//        Console.WriteLine("describe your event");
//        var newEventDesc = Console.ReadLine();
//        newMeeting.ColleagueName = newEventDesc.ToString();

//        Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, you are meeting with {newMeeting.ColleagueName}");

//        var serializedEvent = JsonConvert.SerializeObject(newMeeting);

//        string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

//        string filePath = path + $@"{newMeeting.Day}.{newMeeting.Month}.Meeting.txt";

//        if (!File.Exists(filePath))
//        {
//            File.Create(filePath);
//        }

//        using (StreamWriter sw = File.AppendText(filePath))
//        {
//            sw.WriteLine("---");
//            sw.WriteLine(serializedEvent);
//            sw.WriteLine("---");
//        }
//    }



//    else if (eventTypeAnswer == "D" || eventTypeAnswer == "d")
//    {
//        var newMeeting = new OnlineMeeting();

//        newMeeting.NewEvent();

//        Console.WriteLine("describe your event");
//        var newEventDesc = Console.ReadLine();
//        newMeeting.MeetingPlatform = newEventDesc.ToString();

//        Console.WriteLine($"is this correct? {newMeeting.EventName}, {newMeeting.ID}, {newMeeting.StartDate}, {newMeeting.EndDate}, you are meeting on {newMeeting.MeetingPlatform}");

//        var serializedEvent = JsonConvert.SerializeObject(newMeeting);

//        string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

//        string filePath = path + $@"{newMeeting.Day}.{newMeeting.Month}.OnlineEvent.txt";

//        if (!File.Exists(filePath))
//        {
//            File.Create(filePath);
//        }

//        using (StreamWriter sw = File.AppendText(filePath))
//        {
//            sw.WriteLine("---");
//            sw.WriteLine(serializedEvent);
//            sw.WriteLine("---");
//        }
//    }






//}

//else if (actionAnswer == "B" || actionAnswer == "b")
//{
//    Console.WriteLine("you chose b");
//}

//else if (actionAnswer == "C" || actionAnswer == "c")
//{
//    Console.WriteLine("you chose c");
//}

//else if (actionAnswer == "D" || actionAnswer == "d")
//{
//    Console.WriteLine("you chose d");
//}

//else if (actionAnswer == "E" || actionAnswer == "e")
//{
//    Console.WriteLine("here is the history of errors:");

//    string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/ExceptionStorage/PastExceptions.txt";


//    string fileText = File.ReadAllText(path);
//    var splittedExs = fileText.Split("---");

//    foreach (var item in splittedExs)
//    {
//        var deserializedExs = JsonConvert.DeserializeObject(item);
//        Console.WriteLine(deserializedExs);

//    }

//}

//else
//{

//    Console.WriteLine("please choose from available answers");

//}