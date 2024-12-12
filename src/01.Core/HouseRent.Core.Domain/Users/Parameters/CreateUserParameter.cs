using HouseRent.Core.Domain.Users.ValueObjects;

namespace HouseRent.Core.Domain.Users.Parameters;
public record CreateUserParameter(int id,
                                  FirstName firstName,
                                  LastName lastName,
                                  Email emil);


