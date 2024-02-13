using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreQueryBug.Models;

namespace EFCoreQueryBug
{
    internal partial class MyDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Statement> Statements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("QueryBug")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(new Transaction { Id = 1, Name = "Transaction 1" });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { Id = 2, Name = "Transaction 2" });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { Id = 3, Name = "Transaction 3" });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { Id = 4, Name = "Transaction 4" });

            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 1, Name = "Contact 1" }); //Client
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 2, Name = "Contact 2" }); //Client
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 3, Name = "Contact 3" }); //Model
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 4, Name = "Contact 4" }); //Model
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 5, Name = "Contact 5" }); //Agency
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 6, Name = "Contact 6" }); //Agency

            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 1, TransactionId = 1, Type = "Client", Name = "Statement 1", ContactId = 1, Amount=1000, IsCommission=false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 2, TransactionId = 1, Type = "Client", Name = "Statement 1b", ContactId = 1, Amount = 200, IsCommission = true });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 3, TransactionId = 1, Type = "Model", Name = "Statement 2", ContactId = 3, Amount = 1000, IsCommission = false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 4, TransactionId = 1, Type = "Model", Name = "Statement 2b", ContactId = 3, Amount = -600, IsCommission = true });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 5, TransactionId = 1, Type = "Agency", Name = "Statement 3", ContactId = 5, Amount=100, IsCommission = false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 6, TransactionId = 1, Type = "Agency", Name = "Statement 3", ContactId = 6, Amount=50, IsCommission = false });

            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 7, TransactionId = 2, Type = "Client", Name = "Statement 1", ContactId = 1, Amount = 1000, IsCommission = false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 8, TransactionId = 2, Type = "Client", Name = "Statement 1b", ContactId = 1, Amount = 200, IsCommission = true });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 9, TransactionId = 2, Type = "Model", Name = "Statement 2", ContactId = 4, Amount = 1000, IsCommission = false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 10, TransactionId = 2, Type = "Model", Name = "Statement 2b", ContactId = 4, Amount = -600, IsCommission = true });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 11, TransactionId = 2, Type = "Agency", Name = "Statement 3", ContactId = 5, Amount = 100, IsCommission = false });

            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 12, TransactionId = 3, Type = "Client", Name = "Statement 1", ContactId = 2, Amount = 1000, IsCommission = false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 13, TransactionId = 3, Type = "Client", Name = "Statement 1b", ContactId = 2, Amount = 200, IsCommission = true });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 14, TransactionId = 3, Type = "Model", Name = "Statement 2", ContactId = 3, Amount = 1000, IsCommission = false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 15, TransactionId = 3, Type = "Model", Name = "Statement 2b", ContactId = 3, Amount = -600, IsCommission = true });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 16, TransactionId = 3, Type = "Agency", Name = "Statement 3", ContactId = 6, Amount = 100, IsCommission = false });


            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 17, TransactionId = 4, Type = "Client", Name = "Statement 1", ContactId = 2, Amount = 1000, IsCommission = false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 18, TransactionId = 4, Type = "Client", Name = "Statement 1b", ContactId = 2, Amount = 200, IsCommission = true });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 19, TransactionId = 4, Type = "Model", Name = "Statement 2", ContactId = 4, Amount = 1000, IsCommission = false });
            modelBuilder.Entity<Statement>().HasData(new Statement { Id = 20, TransactionId = 4, Type = "Model", Name = "Statement 2b", ContactId = 4, Amount = -600, IsCommission = true });
       

        }
    }
}
