using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANDS.Models
{
    public class Event
    {
        public int  Id{ get; set; }
        
        public DateTime? DateTime { get; set; }

        public String  EventDetail { get; set; }
        public String  EventTitle { get; set; }
        public String  Venue { get; set; }

    }
}