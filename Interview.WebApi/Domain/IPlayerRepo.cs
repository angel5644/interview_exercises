using Interview.WebApi.Models;

namespace Interview.WebApi.Domain
{
    public interface IPlayerRepo
    {
        Task<IList<Player>> GetPlayersAsync();
        Task AddPlayer(Player player);
    }
}
