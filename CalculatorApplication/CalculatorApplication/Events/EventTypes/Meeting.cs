using System;
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
        public Meeting()
        {
        }
    }
}

