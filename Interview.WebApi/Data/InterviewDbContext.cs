using Interview.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Interview.WebApi.Data
{
    public interface IInterviewDbContext<TEntity>
    {
        Task AddAsync(TEntity player);
        Task<TEntity> GetByIdAsync(int id);
        Task<IList<TEntity>> GetAllAsync();
    }

    public class PlayerMongoDbContext : IInterviewDbContext<Player>
    {
        private readonly IMongoDatabase database;
        private readonly string playersCollectionName = "players";
        private readonly IMongoCollection<Player> playersCollection;

        public PlayerMongoDbContext(IMongoDatabase database)
        {
            this.database = database;

            var collectionNames = database.ListCollectionNames().ToList();
            if (!collectionNames.Contains(playersCollectionName))
            {
                database.CreateCollectionAsync(playersCollectionName);
            }

            playersCollection = database.GetCollection<Player>(playersCollectionName);
        }

        public async Task AddAsync(Player player)
        {
            await playersCollection.InsertOneAsync(player);
        }

        public async Task<IList<Player>> GetAllAsync()
        {
            var query = playersCollection.Find(_ => true);

            var data = await query.ToListAsync();

            return data;
        }

        public async Task<Player> GetByIdAsync(int id)
        {
            var item = await playersCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();

            return item;
        }
    }

    public class InterviewDbContext : DbContext
    {
        public InterviewDbContext(DbContextOptions<InterviewDbContext> options): base(options) 
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
