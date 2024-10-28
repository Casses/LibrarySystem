using Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Context : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<FictionBook> Factions { get; set; }
        public DbSet<NonFictionBook> NonFictionBooks { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }


        public string DbPath { get; }

        public Context()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "library.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>();
            modelBuilder.Entity<Book>()
                .HasDiscriminator(b => b.Category)
                .HasValue<FictionBook>(Common.Enum.BookType.Fiction)
                .HasValue<NonFictionBook>(Common.Enum.BookType.Nonfiction);

            modelBuilder.Entity<Book>()
                .Property(p => p.Category)
                .HasColumnName("Category");
            modelBuilder.Entity<FictionBook>()
                .Property(p => p.Genre)
                .HasColumnName("Genre");
            modelBuilder.Entity<NonFictionBook>()
                .Property(p => p.Genre)
                .HasColumnName("Genre");

            modelBuilder.Entity<Book>()
                .HasMany(p => p.CheckoutHistory)
                .WithOne(p => p.Book);
            modelBuilder.Entity<Member>()
                .HasMany(p => p.CheckoutHistory)
                .WithOne(p => p.Member);

            modelBuilder.Entity<ActivityLog>();
        }
    }
}
