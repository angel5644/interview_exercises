using Interview.WebApi.Api;
using Interview.WebApi.Data;
using Interview.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

RegisterDb(builder.Services, builder.Configuration);
RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddPlayerEndpoints();

app.Run();


static void RegisterServices(IServiceCollection services) 
{
    services.AddScoped<IPlayerRepo, PlayerRepo>();
}

static void RegisterDb(IServiceCollection services, IConfiguration config) 
{
    services.AddDbContext<InterviewDbContext>(options =>
    {
        options.UseSqlServer(config.GetConnectionString(""));
    });
}

