using System;
using CalculatorApplication.Extentions;
using Newtonsoft.Json;

namespace CalculatorApplication.Events.EventTypes
{
    public class Meeting : BaseEvent
    {
        private string colleagueName;
        public string ColleagueName
        {

            get { return colleagueName; }
            set { colleagueName = value; }
        }

        public string pathSuffix = "Meeting.txt";

        public void NewEvent()
        {
            try
            {
                Console.WriteLine("first of all please input a unique number for identification");
                var newId = Convert.ToInt32(Console.ReadLine());
                ID = newId;

                Console.WriteLine("what would you like to call your event?");
                var newEventName = Console.ReadLine();
                EventName = newEventName.ToString();

                Console.WriteLine("describe your event");
                var newEventDesc = Console.ReadLine();
                EventDescription = newEventDesc.ToString();

                Console.WriteLine("when does your event start? month and then day");
                Month = Console.ReadLine().ToString();
                Day = Console.ReadLine().ToString();

                StartDate = Month + Day;

                Console.WriteLine("when does your event end? month and then day");
                var endMonth = Console.ReadLine().ToString();
                var endDay = Console.ReadLine().ToString();

                Console.WriteLine("who are ypu meeting with?");
                var colleague = Console.ReadLine();


                ColleagueName = colleague.ToString();

                Console.WriteLine($"is this correct? {EventName}, {ID}, {StartDate}, {EndDate}, you are meeting with {ColleagueName}");


                EndDate = endMonth + endDay;

                fullPath = ProcessFile.CreatePath(Month, Day, pathSuffix);

            }

            catch (Exception ex)
            {
                ProcessException.ProcessSingleException(ex.Message, ex.StackTrace);
            }

        }


        public static void SeeEventsForDate(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("no such events for that day");
                }

                else
                {
                    string fileText = File.ReadAllText(filePath);
                    var splittedDates = fileText.Split("---");

                    foreach (var item in splittedDates)
                    {
                        var deserializedEvents = JsonConvert.DeserializeObject<Meeting>(item);
                        Console.WriteLine($"event : {deserializedEvents.EventName}, {deserializedEvents.EventDescription}, {deserializedEvents.ID}, starts: {deserializedEvents.StartDate}, ends: {deserializedEvents.EndDate}, with : {deserializedEvents.colleagueName}");

                    }
                }

            }

            catch (Exception ex)
            {
                ProcessException.ProcessSingleException(ex.Message, ex.StackTrace);
            }



        }

        public static void DeleteEvent(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("no events for that day");
                }

                else
                {
                    Console.WriteLine("now browse through the events and choose which one you'd like to remove with ID");

                    string fileText = File.ReadAllText(filePath);
                    var splittedDates = fileText.Split("---");
                    List<Meeting> EventList = new List<Meeting>();

                    foreach (var item in splittedDates)
                    {
                        var deserializedEvents = JsonConvert.DeserializeObject<Meeting>(item);
                        EventList.Add(deserializedEvents);
                        Console.WriteLine($"event : {deserializedEvents.EventName}, {deserializedEvents.EventDescription}, {deserializedEvents.id}, starts: {deserializedEvents.StartDate}, ends: {deserializedEvents.EndDate}, with: {deserializedEvents.ColleagueName}");

                    }

                    Console.WriteLine("please input the id of which item you want to remove");
                    int idAnswer = Convert.ToInt32(Console.ReadLine());
                    EventList.RemoveAll(x => x.ID == idAnswer);

                    File.WriteAllText(filePath, string.Empty);

                    foreach (var item in EventList)
                    {
                        var serializedEventList = JsonConvert.SerializeObject(item);

                        using (StreamWriter sw = File.AppendText(filePath))
                        {

                            sw.WriteLine("---");
                            sw.WriteLine(serializedEventList);
                            sw.WriteLine("---");
                        }

                    }


                }



            }

            catch (Exception ex)
            {
                ProcessException.ProcessSingleException(ex.Message, ex.StackTrace);
            }



        }




        public static void AmendEvent(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("no events for that day");
                }

                else
                {
                    Console.WriteLine("now browse through the events and choose which one you'd like to change with ID");

                    string fileText = File.ReadAllText(filePath);
                    var splittedDates = fileText.Split("---");
                    List<Meeting> EventList = new List<Meeting>();

                    foreach (var item in splittedDates)
                    {
                        var deserializedEvents = JsonConvert.DeserializeObject<Meeting>(item);
                        EventList.Add(deserializedEvents);
                        Console.WriteLine($"event : {deserializedEvents.EventName}, {deserializedEvents.EventDescription}, {deserializedEvents.id}, starts: {deserializedEvents.StartDate}, ends: {deserializedEvents.EndDate}, with: {deserializedEvents.ColleagueName}");

                    }

                    Console.WriteLine("please input the id of which item you want to change");
                    int idAnswer = Convert.ToInt32(Console.ReadLine());
                    EventList.RemoveAll(x => x.ID == idAnswer);

                    File.WriteAllText(filePath, string.Empty);

                    foreach (var item in EventList)
                    {
                        var serializedEventList = JsonConvert.SerializeObject(item);

                        using (StreamWriter sw = File.AppendText(filePath))
                        {

                            sw.WriteLine("---");
                            sw.WriteLine(serializedEventList);
                            sw.WriteLine("---");
                        }

                    }

                    Console.WriteLine("please input new information");

                }



            }

            catch (Exception ex)
            {
                ProcessException.ProcessSingleException(ex.Message, ex.StackTrace);
            }



        }

        public Meeting()
        {
        }
    }
}

