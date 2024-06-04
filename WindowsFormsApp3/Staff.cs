namespace WindowsFormsApp3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel_Services.Staffs")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            Rooms = new HashSet<Room>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int staffId { get; set; }

       

        public int? salary { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [StringLength(25)]
        public string phone { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(20)]
        public string position { get; set; }

        [StringLength(20)]
        public string departmentType { get; set; }
        [StringLength(255)]
        public string image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
