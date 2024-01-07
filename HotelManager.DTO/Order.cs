namespace HotelManager.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int id { get; set; }

        public DateTime? bookingToday { get; set; }
        public DateTime bookingDate { get; set; }

        public DateTime checkOutDate { get; set; }

        public double total { get; set; }

        public int roomID { get; set; }

        public int customerID { get; set; }

        public int status { get; set; }

        public int? serviceID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Room Room { get; set; }

        public virtual Service Service { get; set; }
    }
}
