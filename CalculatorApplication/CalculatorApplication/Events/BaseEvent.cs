using System;
using CalculatorApplication.EventInterfaces;
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




        }

        public void DeleteEvent()
        {
            throw new NotImplementedException();
        }

        public void ChangeEventStatus()
        {
            throw new NotImplementedException();
        }

        public void ChangeDescription()
        {
            throw new NotImplementedException();
        }

        public void SeeAllEvents()
        {
            throw new NotImplementedException();
        }

        public void SeeEventsForDate()
        {
            try
            {
                Console.WriteLine("for what date do you want to see events? input month and then day");
                var month = Console.ReadLine().ToString();
                var day = Console.ReadLine().ToString();

                string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

                Console.WriteLine("what tyoe of ecent do you want to see?");
                Console.WriteLine("A. a general event");
                Console.WriteLine("B. a holliday event");
                Console.WriteLine("C. a Meeting");
                Console.WriteLine("D. an online event");

                var actionAnswer = Console.ReadLine();

                string filePath = path + $@"{day}.{month}.Meeting.txt";

                if (actionAnswer == "A" || actionAnswer == "a")
                {
                    filePath = path + $@"{day}.{month}.BaseEvent.txt";
                }

                else if (actionAnswer == "B" || actionAnswer == "b")
                {
                    filePath = path + $@"{day}.{month}.Holliday.txt";
                }

                else if (actionAnswer == "C" || actionAnswer == "c")
                {
                    filePath = path + $@"{day}.{month}.Meeting.txt";
                }

                else if (actionAnswer == "D" || actionAnswer == "d")
                {
                    filePath = path + $@"{day}.{month}.OnlineMeeting.txt";
                }




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
                var serializedEx = JsonConvert.SerializeObject(ex);

                string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/ExceptionStorage/PastExceptions.txt";

                
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("---");
                    sw.WriteLine(serializedEx);
                    sw.WriteLine("---");
                }
            }



        }
    }
}

