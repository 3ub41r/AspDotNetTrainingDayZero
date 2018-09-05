namespace AspDotNetTraining.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "IC Number")]
        [StringLength(20)]
        public string IcNumber { get; set; }

        [StringLength(20)]
        public string MatricNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
