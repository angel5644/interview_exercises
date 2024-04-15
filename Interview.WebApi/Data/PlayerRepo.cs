using Interview.WebApi.Domain;
using Interview.WebApi.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IList<Player>> GetPlayersAsync()
        {
            return await dbContext.Players.ToListAsync();
        }
    }
}