namespace PopshopWEB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Photos = new HashSet<Photos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idItem { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        public string Discription { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(10)]
        public string UnitOfMeasure { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public int idCategory { get; set; }

        public int? idContract { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photos> Photos { get; set; }
    }
}
