using System;

namespace Stephen.Webb.HR.EventLogger
{
    public interface IEventLogger
    {
        void LogException(Exception ex);
    }

    public class EventLogger : IEventLogger
    {
        public void LogException(Exception ex)
        {
            // Logging not implemented in this demo.
        }
    }
}
