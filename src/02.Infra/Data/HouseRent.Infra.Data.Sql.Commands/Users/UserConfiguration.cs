using HouseRent.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRent.Core.Domain.Users.ValueObjects;
using HouseRent.Core.Domain.Homes.ValueObjects;

namespace HouseRent.Infra.Data.Sql.Commands.Users;
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName)
            .HasMaxLength(50)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value));

        builder.Property(user => user.LastName)
            .HasMaxLength(50)
            .HasConversion(firstName => firstName.Value, value => new LastName(value));

        builder.Property(user => user.Email)
            .HasMaxLength(100)
            .HasConversion(email => email.Value, value => new Email(value));
        builder.Property(amenity => amenity.IsActive)
   .HasConversion(isActive => isActive.Value, value => new IsActive(value));

        builder.HasIndex(user => user.Email).IsUnique();
    }
}