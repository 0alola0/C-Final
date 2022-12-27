using System;
namespace CalculatorApplication.Events.EventTypes
{
    public class OnlineMeeting : BaseEvent
    {
        private string meetingPlatform;
        public string MeetingPlatform
        {
            get { return meetingPlatform; }
            set { meetingPlatform = value; }

        }
        public OnlineMeeting()
        {
        }
    }
}

