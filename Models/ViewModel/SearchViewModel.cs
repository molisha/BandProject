using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANDS.Models.ViewModel
{
    public class SearchViewModel
    {

        
        public IEnumerable<EventSchedule> EventSchedule { get; set; }
        public Event Event { get; set; }

        public String BandName { get; set; }
        public String  EventTitle { get; set; }
        public String Venue { get; set; }
    }
}