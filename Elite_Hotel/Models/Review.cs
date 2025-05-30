using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elite_Hotel.Models
{
    public partial class Review
    {
        public int ReviewID { get; set; }

        public int? BookingID { get; set; }

        public int? UserID { get; set; }

        public int? Rating { get; set; }

        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
