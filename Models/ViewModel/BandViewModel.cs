using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANDS.Models.ViewModel
{
    public class BandViewModel
    {

        public Band Band { get; set; }
        public IEnumerable<Event> Events { get; set; }
        
        
        public IEnumerable<Member> Members { get; set; }


    }
}