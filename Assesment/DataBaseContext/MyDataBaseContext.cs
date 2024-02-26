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
    },
    new CustomerDataModel
    {
        Id = Guid.NewGuid(),
        Name = "David Johnson",
        DNI = "456123789",
        Address = "789 Elm St",
        Phone = "555-7890",
        Mobile = "555-0987",
        Email = "david.johnson@example.com",
        State = "Some State",
        City = "Some City"
    },
    // Add more customers here...
    new CustomerDataModel
    {
        Id = Guid.NewGuid(),
        Name = "Sarah Wilson",
        DNI = "789456123",
        Address = "321 Pine St",
        Phone = "555-7896",
        Mobile = "555-6543",
        Email = "sarah.wilson@example.com",
        State = "Another State",
        City = "Another City"
    },
    new CustomerDataModel
    {
        Id = Guid.NewGuid(),
        Name = "Michael Brown",
        DNI = "654987321",
        Address = "567 Cedar St",
        Phone = "555-9876",
        Mobile = "555-3210",
        Email = "michael.brown@example.com",
        State = "Some State",
        City = "Some City"
    },
    new CustomerDataModel
    {
        Id = Guid.NewGuid(),
        Name = "Emily Davis",
        DNI = "321654987",
        Address = "890 Maple St",
        Phone = "555-5678",
        Mobile = "555-9012",
        Email = "emily.davis@example.com",
        State = "Another State",
        City = "Another City"
    },
    new CustomerDataModel
    {
        Id = Guid.NewGuid(),
        Name = "Daniel Wilson",
        DNI = "789123654",
        Address = "654 Oak St",
        Phone = "555-9012",
        Mobile = "555-3456",
        Email = "daniel.wilson@example.com",
        State = "Some State",
        City = "Some City"
    },
    new CustomerDataModel
    {
        Id = Guid.NewGuid(),
        Name = "Olivia Lee",
        DNI = "321789456",
        Address = "123 Pine St",
        Phone = "555-3456",
        Mobile = "555-7890",
        Email = "olivia.lee@example.com",
        State = "Another State",
        City = "Another City"
    }
);

        base.OnModelCreating(modelBuilder);
    }
}
