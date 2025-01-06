using HouseRent.Endpoints.RestAPI.Extensions;

WebApplication.CreateBuilder(args).ConfigureService().ConfigurePipeline().Run();
