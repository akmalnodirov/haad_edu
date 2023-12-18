using Grpc.Services;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddGrpcReflection();

var app = builder.Build();

app.Logger.LogCritical($"LogCritical Hello");
app.Logger.LogError($"LogCritical Hello");
app.Logger.LogInformation($"LogCritical Hello");
app.Logger.LogWarning($"LogCritical Hello");

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();

//1
app.MapGrpcReflectionService();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
