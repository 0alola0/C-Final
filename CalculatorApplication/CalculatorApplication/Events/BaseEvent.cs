using System;
namespace CalculatorApplication.Events
{
    public class BaseEvent
    {
        private string eventName;
        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }

        private enum status
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
    }
}

