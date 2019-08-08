using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace BANDS.Models
{
    public class Member
    {
        public int Id { get; set; }
        public String Name{ get; set; }

        public  String Role{ get; set; }

        public Band Band{ get; set; }

        public byte BandId { get; set; }
    }
}