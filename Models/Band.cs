using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANDS.Models
{
    public class Band
    {
        public int Id { get; set; }

        public String Name { get; set; }

      

        public String Genre { get; set; }

        public String  Country { get; set; }

        public DateTime? EstDAte { get; set; }

        public bool Active { get; set; }
       public  String Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}