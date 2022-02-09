using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WEBAPI.Models
{
    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB1")
        {
        }

        public virtual DbSet<people> people { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<people>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
