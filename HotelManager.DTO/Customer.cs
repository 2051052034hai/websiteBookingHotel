namespace HotelManager.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public Customer(string HoTen, string DiaChi, string SDT, string MatKhau, string Email, int DeleteFlg, int RoleID)
        {
            this.name = HoTen;
            this.address = DiaChi;
            this.phone = SDT;
            this.password = MatKhau;
            this.email = Email;
            this.deleteFlg = DeleteFlg;
            this.roleID = RoleID;
            this.Orders = new HashSet<Order>();
        }
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(250)]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        public string phone { get; set; }

        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public int roleID { get; set; }

        public int? deleteFlg { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
