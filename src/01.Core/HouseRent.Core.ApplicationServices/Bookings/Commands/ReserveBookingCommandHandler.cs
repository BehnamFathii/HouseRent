﻿using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.ApplicationServices.Framework.Commands;
using HouseRent.Core.Domain.Amenities.Entities;
using HouseRent.Core.Domain.Amenities.Repositories;
using HouseRent.Core.Domain.Bookings.Entities;
using HouseRent.Core.Domain.Bookings.Errors;
using HouseRent.Core.Domain.Bookings.Repositories;
using HouseRent.Core.Domain.Bookings.Services;
using HouseRent.Core.Domain.Bookings.ValueObjects;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.Errors;
using HouseRent.Core.Domain.Homes.Repositories;
using HouseRent.Core.Domain.Users.Errors;
using HouseRent.Core.Domain.Users.Repositories;

namespace HouseRent.Core.ApplicationServices.Bookings.Commands;
internal sealed class ReserveBookingCommandHandler(IIdGenerator<long> idGenerator,
                                    IUserRepository userRepository,
                                    IHomeRepository homeRepository,
                                    IBookingRepository bookingRepository,
                                    IAmentyRepository amentyRepository,
                                    IUnitOfWork unitOfWork,
                                    IDateTimeProvider dateTimeProvider) : ICommandHandler<ReserveBookingCommand, long>
{
    #region private fields
    private readonly IIdGenerator<long> _idGenerator = idGenerator;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IHomeRepository _homeRepository = homeRepository;
    private readonly IBookingRepository _bookingRepository = bookingRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    #endregion


    #region Constructors
    #endregion

    public async Task<Result<long>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<long>(UserErrors.NotFound);
        }

        var home = await _homeRepository.GetByIdAsync(request.HomeId, cancellationToken);

        if (home is null)
        {
            return Result.Failure<long>(HomeErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);


        if (await _bookingRepository.IsOverlappingAsync(home, duration, cancellationToken))
        {
            return Result.Failure<long>(BookingErrors.Overlap);
        }

        List<Amenity> homeAmenities = home.HomeAmenities.Select(c => c.Amenity).ToList();


        PricingService pricingService = new(homeAmenities);

        var booking = Booking.Reserve(
            _idGenerator.GetId(),
            home,
            user.Id,
            duration,
            _dateTimeProvider.GetUtcNow(),
            pricingService);

        await _bookingRepository.Add(booking, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return booking.Id;
    }
}
