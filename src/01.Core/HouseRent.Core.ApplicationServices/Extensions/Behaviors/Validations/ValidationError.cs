﻿namespace HouseRent.Core.ApplicationServices.Extensions.Behaviors.Validations;
public sealed record ValidationError(string PropertyName, string ErrorMessage);