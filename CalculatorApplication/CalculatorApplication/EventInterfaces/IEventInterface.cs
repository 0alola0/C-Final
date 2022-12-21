using System;
namespace CalculatorApplication.EventInterfaces
{
    public interface IEventInterface
    {
        public void NewEvent();

        public void DeleteEvent();

        public void ChangeEventStatus();

        public void ChangeDescription();

        public void SeeAllEvents();

        public void SeeEventsForDate();
    }
}

