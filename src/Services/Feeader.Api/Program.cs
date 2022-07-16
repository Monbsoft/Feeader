using Monbsoft.Feeader.Api.Workers;
using Monbsoft.Feeader.Application;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Infrastructure;
using Monbsoft.Feeader.Infrastructure.Http.Feeds;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<FeedWorker>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpClient<IFeedClient, FeedClient>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(setup =>
{
    setup.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
