﻿using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Bookings.ValueObjects;
public record DateRange
{
    public DateRange()
    {

    }

    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new DomainValidationException("تاریخ پایان از شروع کوچکتر است");
        }

        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}
