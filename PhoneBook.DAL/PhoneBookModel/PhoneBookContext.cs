namespace PhoneBook.DAL.PhoneBookModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhoneBookContext : DbContext
    {
        public PhoneBookContext()
            : base("name=PhoneBookEntity")
        {
        }


        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactField> ContactField { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                   .HasMany(e => e.ContactField)
                   .WithRequired(e => e.Contact)
                   .WillCascadeOnDelete(true);
        }
    }
}
