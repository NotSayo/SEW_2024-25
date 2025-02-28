using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model;

public class OuterrimContext : DbContext
{

    public DbSet<AircraftSpecification> AircraftSpecifications { get; set; }
    public DbSet<Aircraft> Aircrafts { get; set; }
    public DbSet<AircraftCrew> AircraftCrews { get; set; }
    public DbSet<Compartment> Compartments { get; set; }
    public DbSet<Machinery> Machineries { get; set; }
    public DbSet<Mercenary> Mercenaries { get; set; }
    public DbSet<MercenaryReputation> MercenaryReputations { get; set; }
    public DbSet<CrimeSyndicate> Syndicates { get; set; }

    public OuterrimContext(DbContextOptions<OuterrimContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Aircraft>()
            .Navigation(a => a.Specification).AutoInclude();
        builder.Entity<Aircraft>()
            .Navigation(a => a.Compartments).AutoInclude();
        builder.Entity<Compartment>()
            .Navigation(c => c.Machineries).AutoInclude();


        builder.Entity<AircraftCrew>()
            .HasKey(c => new {c.AircraftId, c.MercenaryId});

        builder.Entity<MercenaryReputation>()
            .HasKey(s => new {s.MercenaryId, s.SyndicateId});

        builder.Entity<Machinery>()
            .HasDiscriminator<string>("Name")
            .HasValue<Weapons>("Weapons")
            .HasValue<EnergySystem>("EnergySystems")
            .HasValue<EnvironmentalSystem>("EnvironmentalSystems");

        builder.Entity<AircraftSpecification>()
            .HasMany<Aircraft>(s => s.Aircrafts)
            .WithOne(s => s.Specification)
            .HasForeignKey(s => s.SpecificationId);

        builder.Entity<Machinery>()
            .HasOne<Compartment>(s => s.Compartment)
            .WithMany(s => s.Machineries)
            .HasForeignKey(s => s.CompartmentId);

        builder.Entity<Compartment>()
            .HasOne<Aircraft>(s => s.Aircraft)
            .WithMany(s => s.Compartments)
            .HasForeignKey(s => s.AircraftId);






        base.OnModelCreating(builder);
    }
}