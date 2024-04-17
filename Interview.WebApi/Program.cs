using Interview.DesignPatterns.Singleton;
using Interview.WebApi.Api;
using Interview.WebApi.Data;
using Interview.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StackExchange.Redis;
using System.Collections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//RegisterDb(builder.Services, builder.Configuration);
RegisterMongoDb(builder.Services, builder.Configuration);
RegisterServices(builder.Services, builder.Configuration);

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


static void RegisterServices(IServiceCollection services, IConfiguration config) 
{
    services.AddSingleton<RedisCache>();
    services.AddSingleton<PlayerMongoDbContext>();
    services.AddScoped<IPlayerRepo, PlayerRepoRedis>();

    services.AddSingleton<IConnectionMultiplexer>(sp =>
    {
        var connString = config.GetConnectionString("RedisCache");

        var redisConfig = ConfigurationOptions.Parse(connString);

        redisConfig.AbortOnConnectFail = false;

        return ConnectionMultiplexer.Connect(redisConfig);
    });
}

static void RegisterDb(IServiceCollection services, IConfiguration config) 
{
    services.AddDbContext<InterviewDbContext>(options =>
    {
        options.UseSqlServer(config.GetConnectionString("InterviewDbConnection"));
    });
}

static void RegisterMongoDb(IServiceCollection services, IConfiguration config) 
{
    services.AddSingleton<IMongoClient>(sp =>
    {
        var mongoConfig = config.GetConnectionString("MongoDbConnection");

        return new MongoClient(mongoConfig);
    });

    services.AddSingleton<IMongoDatabase>(sp =>
    {
        var client = sp.GetRequiredService<IMongoClient>();

        var database = client.GetDatabase("interview");

        var collectionNames = database.ListCollectionNames().ToList();
        if (!collectionNames.Contains("players"))
        {
            database.CreateCollection("players");
        }

        return database;
    });
}

