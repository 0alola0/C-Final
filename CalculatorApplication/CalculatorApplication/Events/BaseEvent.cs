using System;
using CalculatorApplication.EventInterfaces;
using CalculatorApplication.Extentions;
using Newtonsoft.Json;

namespace CalculatorApplication.Events
{
    public class BaseEvent : IEventInterface
    {

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string pathSuffix = "BaseEvent.txt";

        public string fullPath;

        private string eventName;
        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }

        private string eventDescription;
        public string EventDescription
        {
            get { return eventDescription; }
            set { eventDescription = value; }

        }

        public enum EventStatus
        {
            active,
            ongoing,
            over
        };
        public string Month;
        public string Day;

        private string startDate;
        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private string endDate;
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }


        public BaseEvent()
        {
        }



        public void NewEvent()
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

            EndDate = endMonth + endDay;

            Console.WriteLine($"is this correct? {EventName}, {ID}, {StartDate}, {EndDate}, {EventDescription}");

            fullPath = ProcessFile.CreatePath(Month, Day, pathSuffix);

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
                        var deserializedEvents = JsonConvert.DeserializeObject<BaseEvent>(item);
                        Console.WriteLine($"event : {deserializedEvents.EventName}, {deserializedEvents.EventDescription}, {deserializedEvents.id}, starts: {deserializedEvents.StartDate}, ends: {deserializedEvents.EndDate}");

                    }
                }

            }

            catch(Exception ex)
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
                    Console.WriteLine("now browse through the events and choose which one you'd like to change with ID");

                    string fileText = File.ReadAllText(filePath);
                    var splittedDates = fileText.Split("---");
                    List<BaseEvent> EventList = new List<BaseEvent>();

                    foreach (var item in splittedDates)
                    {
                        var deserializedEvents = JsonConvert.DeserializeObject<BaseEvent>(item);
                        EventList.Add(deserializedEvents);
                        Console.WriteLine($"event : {deserializedEvents.EventName}, {deserializedEvents.EventDescription}, {deserializedEvents.id}, starts: {deserializedEvents.StartDate}, ends: {deserializedEvents.EndDate}");

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

                    Console.WriteLine("now please input new information");

                    
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
                    Console.WriteLine("now browse through the events and choose which one you'd like to remove with ID");

                    string fileText = File.ReadAllText(filePath);
                    var splittedDates = fileText.Split("---");
                    List<BaseEvent> EventList = new List<BaseEvent>();

                    foreach (var item in splittedDates)
                    {
                        var deserializedEvents = JsonConvert.DeserializeObject<BaseEvent>(item);
                        EventList.Add(deserializedEvents);
                        Console.WriteLine($"event : {deserializedEvents.EventName}, {deserializedEvents.EventDescription}, {deserializedEvents.id}, starts: {deserializedEvents.StartDate}, ends: {deserializedEvents.EndDate}");

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






    }
}

