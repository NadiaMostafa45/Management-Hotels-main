namespace WindowsFormsApp3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel_Services.Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            customerRooms = new HashSet<customerRoom>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customerId { get; set; }

       

        [StringLength(20)]
        public string customerName { get; set; }

        public int? customerAge { get; set; }

        [StringLength(50)]
        public string customerType { get; set; }

        [StringLength(50)]
        public string phone { get; set; }
        public int roomId { get; set; }
        public virtual Room Room { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customerRoom> customerRooms { get; set; }
    }
}
