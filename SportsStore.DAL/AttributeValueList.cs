namespace SportsStore.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttributeValueList
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttributeId { get; set; }

        public int? Value { get; set; }

        public virtual Attribute Attribute { get; set; }

        public virtual ListItem ListItem { get; set; }

        public virtual Product Product { get; set; }
    }
}