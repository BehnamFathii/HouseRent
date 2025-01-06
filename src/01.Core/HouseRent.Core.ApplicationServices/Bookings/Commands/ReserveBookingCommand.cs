using HouseRent.Core.ApplicationServices.Framework.Commands;

namespace HouseRent.Core.ApplicationServices.Bookings.Commands;
public record ReserveBookingCommand(
    long HomeId,
    long UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<long>;
