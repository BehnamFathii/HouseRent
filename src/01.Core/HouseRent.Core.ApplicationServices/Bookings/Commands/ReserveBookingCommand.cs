using HouseRent.Core.ApplicationServices.Framework.Commands;

namespace HouseRent.Core.ApplicationServices.Bookings.Commands;
public record ReserveBookingCommand(
    int HomeId,
    int UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<int>;
