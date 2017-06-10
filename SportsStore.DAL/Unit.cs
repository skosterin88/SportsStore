namespace SportsStore.DAL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Unit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unit()
        {
            Attributes = new HashSet<Attribute>();
        }

        public int Id { get; set; }

        [StringLength(16)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attribute> Attributes { get; set; }
    }
}
