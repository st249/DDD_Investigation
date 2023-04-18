using DDD_Investigation.Domain.BuyerAggregate;
using DDD_Investigation.Domain.OrderAggregate;
using DDD_Investigation.Domain.PublicationAggregate;
using DDD_Investigation.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DDD_Investigation.Infrastructure
{
    public class DDDContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BaseOrder> Orders { get; set; }
        public DbSet<Publication> Publications { get; set; }

        public DDDContext(DbContextOptions<DDDContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly, t => t.GetInterfaces().Any(i =>
            //    i.IsGenericType &&
            //    i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseHiLo("CustomerSeq");

            modelBuilder.HasSequence("CustomerSeq")
            .IncrementsBy(100);


            modelBuilder.Entity<BaseOrder>()
                .ToTable("Orders");
            modelBuilder.Entity<VirtualOrder>()
                .ToTable("VirtualOrders");
            modelBuilder.Entity<InPersonOrder>()
              .ToTable("InPersonOrders");
            modelBuilder.Entity<OrderItem>()
              .ToTable("OrderItems");

            modelBuilder.Entity<BaseOrder>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<BaseOrder>()
                .Property(o => o.Id)
                 .UseHiLo("OrderSeq");

            modelBuilder.HasSequence("OrderSeq")
         .IncrementsBy(1);

            modelBuilder.Entity<BaseOrder>()
                .Property(o => o.Status)
                .HasConversion(status => status.Id,
                value => Enumeration.FromValue<OrderStatus>(value));

            modelBuilder.Entity<BaseOrder>()
    .Property(o => o.OrderType)
    .HasConversion(status => status.Name,
    value => Enumeration.FromDisplayName<OrderType>(value));

            modelBuilder.Entity<BaseOrder>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .IsRequired();

            modelBuilder.Entity<BaseOrder>()
               .HasMany(o => o.OrderItems)
               .WithOne()
               .HasForeignKey("OrderId")
               .IsRequired();


            modelBuilder.Entity<OrderItem>()
    .HasKey(oi => oi.Id);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Id)
                .UseHiLo("OrderItemSeq");

            modelBuilder.HasSequence("OrderItemSeq")
      .IncrementsBy(1);

            modelBuilder.Entity<OrderItem>()
               .OwnsOne(oi => oi.Price, p =>
               {
                   p.Property(x => x.Currency)
                   .HasMaxLength(3);
                   p.WithOwner();
               });

            modelBuilder.Entity<Publication>()
                .ToTable("Publications");

            modelBuilder.Entity<Book>()
                .ToTable("Books");

            modelBuilder.Entity<EBook>()
                .ToTable("EBooks");

            modelBuilder.Entity<Publication>()
.Property(o => o.PublicationType)
.HasConversion(status => status.Name,
value => Enumeration.FromDisplayName<PublicationType>(value));
        }

    }
}
