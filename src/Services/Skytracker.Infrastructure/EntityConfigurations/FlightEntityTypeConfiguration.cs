using Microsoft.EntityFrameworkCore;
using Skytracker.Domain.Entities;
using Skytracker.Domain.ValueObjects;

namespace Skytracker.Infrastructure.EntityConfigurations;

public class FlightEntityTypeConfiguration : IEntityTypeConfiguration<Flight>
{
    private const string Schema = "dbo";
    private const string TableName = "Flight";

    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable(TableName, Schema);

        builder.HasKey(f => f.FlightId);

        builder.Property(f => f.FlightId).HasConversion(f => f.Value, f => FlightId.Create(f));

        builder.OwnsOne(x => x.DeparturePoint, f =>
        {
            f.Property(y => y).HasColumnName("DeparturePoint");
        });


    }
}
