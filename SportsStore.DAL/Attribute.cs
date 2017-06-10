namespace SportsStore.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Attribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attribute()
        {
            AttributeValuesList = new HashSet<AttributeValueList>();
            AttributeValuesFloat = new HashSet<AttributeValueFloat>();
            AttributeValuesText = new HashSet<AttributeValueText>();
            CategoryAttributes = new HashSet<CategoryAttribute>();
            ListItems = new HashSet<ListItem>();
        }

        public int Id { get; set; }

        public int AttributeGroupId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? AttributeType { get; set; }

        public int UnitId { get; set; }

        public byte? AttributeStatus { get; set; }

        public int? Ordering { get; set; }

        public virtual AttributeGroup AttributeGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttributeValueList> AttributeValuesList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttributeValueFloat> AttributeValuesFloat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttributeValueText> AttributeValuesText { get; set; }

        public virtual Unit Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListItem> ListItems { get; set; }
    }
}
