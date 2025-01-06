using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRent.Infra.Data.Sql.Commands.Homes;
internal class HomeConfiguration : IEntityTypeConfiguration<Home>
{
    public void Configure(EntityTypeBuilder<Home> builder)
    {
        builder.ToTable("Homes");
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.HasKey(home => home.Id);

        builder.OwnsOne(home => home.Address);

        builder.Property(home => home.Title)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new Title(value));

        builder.Property(home => home.Description)
            .HasConversion(description => description.Value, value => new Description(value));
        builder.Property(home => home.Price)
            .HasConversion(price => price.Amount, value => new Money(value));
        builder.Property(home => home.IsActive)
   .HasConversion(isActive => isActive.Value, value => new IsActive(value));

        builder.Property<uint>("Version").IsRowVersion();
    }
}
