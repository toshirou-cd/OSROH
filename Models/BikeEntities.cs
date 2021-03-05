using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OSROH.Models
{
    public partial class BikeEntities : DbContext
    {
        public BikeEntities()
            : base("name=BikeEntities")
        {
        }

        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Intimacy> Intimacies { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Route>()
                .Property(e => e.Default_price)
                .IsFixedLength();

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Trips)
                .WithRequired(e => e.Route)
                .HasForeignKey(e => e.Route_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Routes)
                .WithRequired(e => e.Station)
                .HasForeignKey(e => e.Starting_point)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Routes1)
                .WithRequired(e => e.Station1)
                .HasForeignKey(e => e.Destination)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Trip>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Trip)
                .HasForeignKey(e => e.Trip_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone_number)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bikes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Intimacies)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserID1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Intimacies1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserID2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Trips)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Customer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Trips1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.Driver_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Trips2)
                .WithRequired(e => e.User2)
                .HasForeignKey(e => e.Cancel_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Wallets)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wallet>()
                .Property(e => e.Point)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Wallet>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Wallet>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Wallet)
                .HasForeignKey(e => e.From_wallet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wallet>()
                .HasMany(e => e.Transactions1)
                .WithRequired(e => e.Wallet1)
                .HasForeignKey(e => e.To_wallet)
                .WillCascadeOnDelete(false);
        }
    }
}
