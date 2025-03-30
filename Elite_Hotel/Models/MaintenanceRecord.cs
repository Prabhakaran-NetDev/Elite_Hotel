using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elite_Hotel.Models
{
    public partial class MaintenanceRecord
    {
        [Key]
        public int MaintenanceID { get; set; }

        public int? RoomID { get; set; }

        public DateTime MaintenanceDate { get; set; }

        public string Description { get; set; }

        public decimal? Cost { get; set; }

        [StringLength(100)]
        public string ServiceProvider { get; set; }
    }
}
