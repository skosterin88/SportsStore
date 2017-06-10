using System.Data.Entity;

namespace SportsStore.DAL
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<AttributeGroup> AttributeGroups { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ListItem> ListItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<AttributeValueFloat> AttributeValuesFloat { get; set; }
        public virtual DbSet<AttributeValueList> AttributeValuesList { get; set; }
        public virtual DbSet<AttributeValueText> AttributeValuesText { get; set; }
        public virtual DbSet<CategoryAttribute> CategoryAttributes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeGroup>()
                .HasMany(e => e.Attributes)
                .WithRequired(e => e.AttributeGroup)
                .HasForeignKey(e => e.AttributeGroupId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.AttributeValuesList)
                .WithRequired(e => e.Attribute)
                .HasForeignKey(e => e.AttributeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.AttributeValuesFloat)
                .WithRequired(e => e.Attribute)
                .HasForeignKey(e => e.AttributeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.AttributeValuesText)
                .WithRequired(e => e.Attribute)
                .HasForeignKey(e => e.AttributeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.CategoryAttributes)
                .WithRequired(e => e.Attribute)
                .HasForeignKey(e => e.AttributeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.ListItems)
                .WithRequired(e => e.Attribute)
                .HasForeignKey(e => e.AttributeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryAttributes)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ListItem>()
                .HasMany(e => e.AttributeValuesList)
                .WithOptional(e => e.ListItem)
                .HasForeignKey(e => e.Value);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.AttributeValuesList)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.AttributeValuesFloat)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.AttributeValuesText)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.Attributes)
                .WithRequired(e => e.Unit)
                .HasForeignKey(e => e.UnitId)
                .WillCascadeOnDelete(false);
        }
    }
}
