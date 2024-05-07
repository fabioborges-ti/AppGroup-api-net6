using AppGroup.Rental.Domain.Entities;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppGroup.Rental.Infrastructure.Database.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.ApplyConfiguration(new MotorcycleConfiguration());
        builder.ApplyConfiguration(new MotodriverConfiguration());
        builder.ApplyConfiguration(new PriceConfiguration());
        builder.ApplyConfiguration(new RentConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());

        #region SEEDS

        builder.Entity<MotorcycleEntity>().HasData(new MotorcycleEntity { Id = Guid.NewGuid(), Model = "Honda CB 300 R", PlateNumber = "ABC0001", Year = 2015, Status = StatusMotorcycles.Avaiable });
        builder.Entity<MotorcycleEntity>().HasData(new MotorcycleEntity { Id = Guid.NewGuid(), Model = "Honda CB 300 F", PlateNumber = "ABC0002", Year = 2017, Status = StatusMotorcycles.Avaiable });
        builder.Entity<MotorcycleEntity>().HasData(new MotorcycleEntity { Id = Guid.NewGuid(), Model = "Honda Twister 250", PlateNumber = "ABC0003", Year = 2018, Status = StatusMotorcycles.Avaiable });
        builder.Entity<MotorcycleEntity>().HasData(new MotorcycleEntity { Id = Guid.NewGuid(), Model = "Honda Twister 250", PlateNumber = "ABC0004", Year = 2019, Status = StatusMotorcycles.Avaiable });
        builder.Entity<MotorcycleEntity>().HasData(new MotorcycleEntity { Id = Guid.NewGuid(), Model = "Honda Titan 160", PlateNumber = "ABC0005", Year = 2016, Status = StatusMotorcycles.Avaiable });
        builder.Entity<MotorcycleEntity>().HasData(new MotorcycleEntity { Id = Guid.NewGuid(), Model = "Honda Titan 160", PlateNumber = "ABC0006", Year = 2017, Status = StatusMotorcycles.Avaiable });

        builder.Entity<PriceEntity>().HasData(new PriceEntity { Id = Guid.NewGuid(), Days = 7, Daily = 30 });
        builder.Entity<PriceEntity>().HasData(new PriceEntity { Id = Guid.NewGuid(), Days = 15, Daily = 28 });
        builder.Entity<PriceEntity>().HasData(new PriceEntity { Id = Guid.NewGuid(), Days = 30, Daily = 22 });

        #endregion

        base.OnModelCreating(builder);
    }
}
