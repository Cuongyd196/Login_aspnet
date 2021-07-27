namespace test2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class user : DbContext
    {
        public user()
            : base("name=user")
        {
        }

        public virtual DbSet<Genner> Genners { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<userName> userNames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genner>()
                .Property(e => e.NameGenner)
                .IsFixedLength();

            modelBuilder.Entity<Genner>()
                .HasMany(e => e.userNames)
                .WithOptional(e => e.Genner)
                .HasForeignKey(e => e.IDGenner);

            modelBuilder.Entity<userName>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<userName>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<userName>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<userName>()
                .Property(e => e.OldMail)
                .IsFixedLength();
        }

        public System.Data.Entity.DbSet<test2.Models.loginModel> loginModels { get; set; }
    }
}
