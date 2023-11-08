using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using WindParkService;
using WindParkService.DataModel;
using WindParkService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddSingleton<IWindParkManager, WindParkManager>();
builder.Services.AddSingleton<ITurbineRepository, InMemoryTurbineRepository>();
builder.Services.AddSingleton<ITurbineProductionService, TurbineParkProductionInfoService>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001, o => o.Protocols = HttpProtocols.Http2);
});

var app = builder.Build();


app.MapGrpcService<WindParkManagementService>();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapGet("/", () => "This server contains a gRPC service");

app.Run();