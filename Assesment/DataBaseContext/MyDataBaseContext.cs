// MyDataBaseContext.cs
using Microsoft.EntityFrameworkCore;
using Assesment.DataModel;

public class MyDataBaseContext : DbContext
{
    public DbSet<CustomerDataModel> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerDataModel>().HasData(
            new CustomerDataModel
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                DNI = "123456789",
                Address = "123 Main St",
                Phone = "555-1234",
                Mobile = "555-5678",
                Email = "john.doe@example.com",
                State = "Some State",
                City = "Some City"
            },
            new CustomerDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Jane Smith",
                DNI = "987654321",
                Address = "456 Oak St",
                Phone = "555-4321",
                Mobile = "555-8765",
                Email = "jane.smith@example.com",
                State = "Another State",
                City = "Another City"
            });

        base.OnModelCreating(modelBuilder);
    }
}
