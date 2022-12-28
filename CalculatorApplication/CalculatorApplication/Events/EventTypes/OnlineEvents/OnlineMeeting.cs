using System;
namespace CalculatorApplication.Events.EventTypes
{
    public class OnlineMeeting : Meeting
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

