
using System.Collections.Generic;
namespace Track.Core.Models
{
    public class Log
    {
        public string LogTypeID { get; set; }
        public string SessionID { get; set; }
        public string TimeStamp { get; set; }
         public List<LogKeyType> LogKeyTypes { get; set; }

         public Log()
        {
            this.LogKeyTypes = new List<LogKeyType>();

        }
    }
    public class LogKeyType
    {
        public string LogKeyTypeID { get; set; }
        public string LogKeyTypeValue { get; set; }
    }
}
