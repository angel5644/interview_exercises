using Interview.DesignPatterns.Singleton;
using Interview.WebApi.Domain;
using Interview.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Text.Json;

namespace Interview.WebApi.Data
{

    public class PlayerRepo : IPlayerRepo
    {
        private readonly InterviewDbContext dbContext;

        public PlayerRepo(InterviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPlayer(Player player)
        {
            await dbContext.AddAsync(player);
        }

        public Task<Player> GetPlayerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Player>> GetPlayersAsync()
        {
            return await dbContext.Players.ToListAsync();
        }
    }

    public class PlayerRepoRedis : IPlayerRepo
    {
        private RedisCache redisCache;
        private readonly string playersCacheKey = "players";
        private readonly TimeSpan defaultCacheExpiration = new TimeSpan(0, 0, 30);

        private readonly PlayerMongoDbContext playersDbContext;

        public PlayerRepoRedis(PlayerMongoDbContext mongoDbContext, RedisCache redisCache)
        {
            this.playersDbContext = mongoDbContext;
            this.redisCache = redisCache;
        }

        public async Task AddPlayer(Player player)
        {
            await playersDbContext.AddAsync(player);
        }

        public async Task<IList<Player>> GetPlayersAsync()
        {
            return await playersDbContext.GetAllAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(int id) 
        {
            var playerFromCache = GetPlayerByIdFromCache(id);

            if (playerFromCache is null) 
            {
                var player = await playersDbContext.GetByIdAsync(id);

                if (player != null) 
                {
                    AddToCache(player);
                }

                return player;
            }

            return playerFromCache;
        }

        private void AddToCache(Player player) 
        {
            var playerAsJson = JsonSerializer.Serialize(player);

            redisCache.AddToCache($"{playersCacheKey}-{player.Id}", playerAsJson, defaultCacheExpiration);
        }

        private Player GetPlayerByIdFromCache(int id) 
        {
            var playerAsJson = redisCache.GetStringFromCache($"{playersCacheKey}-{id}");

            if (playerAsJson is null) 
            {
                return null;
            }

            var player = JsonSerializer.Deserialize<Player>(playerAsJson);

            return player;
        }
    }
}