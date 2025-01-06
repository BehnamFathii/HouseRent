using HouseRent.Core.Domain.Amenities.Entities;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRent.Infra.Data.Sql.Commands.Amenities;
internal class AmenitiesConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.ToTable("Amenities");
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.HasKey(x => x.Id);
        builder.Property(amenity => amenity.Title)
          .HasMaxLength(200)
          .HasConversion(title => title.Value, value => new Title(value));
        builder.Property(amenity => amenity.Price)
           .HasConversion(price => price.Amount, value => new Money(value));
        builder.Property(amenity => amenity.Description)
           .HasConversion(description => description.Value, value => new Description(value));     
        builder.Property(amenity => amenity.IsActive)
           .HasConversion(isActive => isActive.Value, value => new IsActive(value));
    }
}