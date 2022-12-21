using System;
using CalculatorApplication.EventInterfaces;

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

        public enum EventStatus
        {
            active,
            ongoing,
            over
        };

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;
        public DateTime EndDate
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

            Console.WriteLine("when does your event start? please input date in this order `dd/mm/yy hour:minute am/pm`");
            var startDateString = Console.ReadLine().ToString();

            StartDate = DateTime.Parse(startDateString,
                                      System.Globalization.CultureInfo.InvariantCulture);

            Console.WriteLine("when does your event end? please input date in this order `dd/mm/yy hour:minute am/pm`");
            var endDateString = Console.ReadLine().ToString();

            EndDate = DateTime.Parse(startDateString,
                                      System.Globalization.CultureInfo.InvariantCulture);

            Console.WriteLine($"is this correct? {EventName}, {ID}, {StartDate}, {EndDate}");
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
            throw new NotImplementedException();
        }
    }
}

