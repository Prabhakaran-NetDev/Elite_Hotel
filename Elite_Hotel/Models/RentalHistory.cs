using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elite_Hotel.Models
{
    public partial class RentalHistory
    {
        public int RentalHistoryID { get; set; }

        public int? UserID { get; set; }

        public int? RoomID { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
