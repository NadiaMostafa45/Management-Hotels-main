namespace WindowsFormsApp3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel_Services.Room")]
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            Customers = new HashSet<Customer>();
            customerRooms = new HashSet<customerRoom>();
            Staffs = new HashSet<Staff>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roomId { get; set; }

        [StringLength(20)]
        public string roomType { get; set; }

        public int? price { get; set; }

        [StringLength(255)]
        public string roomSize { get; set; }

        [StringLength(255)]
        public string maintenanceState { get; set; }

        [StringLength(50)]
        public string cleaningState { get; set; }

        [StringLength(50)]
        public string reservationState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customerRoom> customerRooms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
