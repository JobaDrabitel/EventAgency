using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp5.Model
{
    public partial class ModelEvent : DbContext
    {
        public ModelEvent()
            : base("name=ModelEvent")
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Activity)
                .WithOptional(e => e.Event)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Event)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.OrganizerId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activity)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ModeratorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activity1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.Judge1Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activity2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.Judge2Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activity3)
                .WithOptional(e => e.User3)
                .HasForeignKey(e => e.Judge3Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activity4)
                .WithOptional(e => e.User4)
                .HasForeignKey(e => e.Judge4Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activity5)
                .WithOptional(e => e.User5)
                .HasForeignKey(e => e.Judge5Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activity6)
                .WithOptional(e => e.User6)
                .HasForeignKey(e => e.WinnerId);
        }
    }
}
