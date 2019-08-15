using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANDS.Models
{
    public class EventSchedule
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }

        public TimeSpan Time { get; set; }
        public Band Band { get; set; }
        public int BandId { get; set; }

        public Event Event { get; set; }
        public int EventId { get; set; }
       
        public String Song { get; set; }


    }
}