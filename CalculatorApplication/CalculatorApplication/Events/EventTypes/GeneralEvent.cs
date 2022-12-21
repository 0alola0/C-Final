using System;
namespace CalculatorApplication.Events.EventTypes
{
    public class GeneralEvent : BaseEvent
    {
        private string eventDescription;

        public string EventDescription
        {
            get { return eventDescription; }
            set { eventDescription = value; }

        }
        //public GeneralEvent(int ID, string EventName, EventStatus eventStatus, DateTime StartDate, DateTime EndDate)
        //{
        //    ID = id

        //}
    }
}

