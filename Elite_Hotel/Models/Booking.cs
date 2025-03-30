using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elite_Hotel.Models
{
    public partial class Booking
    {
        public int BookingID { get; set; }

        public int? UserID { get; set; }

        public int? RoomID { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
