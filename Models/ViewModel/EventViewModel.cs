using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANDS.Models.ViewModel
{
    public class EventViewModel
    {
        public IEnumerable<Band > Band { get; set; }
        public Event Event { get; set; }
        public IEnumerable<EventSchedule> EventSchedule { get; set; }
    }

}