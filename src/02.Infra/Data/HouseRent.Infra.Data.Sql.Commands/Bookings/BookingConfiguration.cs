using HouseRent.Core.Domain.Bookings.Entities;
using HouseRent.Core.Domain.Bookings.ValueObjects;
using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Core.Domain.Shared.ValueObjects;
using HouseRent.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRent.Infra.Data.Sql.Commands.Bookings;
internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.HasKey(booking => booking.Id);
        builder.Property(booking => booking.PriceForPeriod)
           .HasConversion(price => price.Amount, value => new Money(value));
        builder.Property(booking => booking.AmenitiesUpCharge)
           .HasConversion(price => price.Amount, value => new Money(value));
        builder.OwnsOne(booking => booking.Duration);
        builder.HasOne<Home>()
            .WithMany()
            .HasForeignKey(booking => booking.HomeId);
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(booking => booking.UserId);
    }
}