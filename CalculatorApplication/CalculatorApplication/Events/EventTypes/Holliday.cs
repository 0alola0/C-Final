using System;
namespace CalculatorApplication.Events.EventTypes
{
    public class Holliday : BaseEvent
    {
        private string hollidayName;
        public string HollidayName
        {
            get { return hollidayName; }
            set { hollidayName = value; }

        }

        public Holliday()
        {
        }
    }
}

