namespace SportsStore.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListItem()
        {
            AttributeValuesList = new HashSet<AttributeValueList>();
        }

        public int Id { get; set; }

        public int AttributeId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? Ordering { get; set; }

        public bool? IsAvailable { get; set; }

        public virtual Attribute Attribute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttributeValueList> AttributeValuesList { get; set; }
    }
}
