using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANDS.Models.ViewModel
{
    public class EventScheduleViewModel
    {
        public IEnumerable<Event> Event { get; set; }


        public IEnumerable<Band> Band { get; set; }

        public IEnumerable<EventSchedule> EventSchedule { get; set; }
 
        public int BandId { get; set; }
    }
}