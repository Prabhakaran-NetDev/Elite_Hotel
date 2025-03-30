using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elite_Hotel.Models
{
    public partial class Room
    {
        public int RoomID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int Capacity { get; set; }

        public decimal PricePerNight { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
