using Interview.WebApi.Domain;
using Interview.WebApi.Models;

namespace Interview.WebApi.Api
{
    public static class PlayersApi 
    {
        public static void AddPlayerEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/players", async (IPlayerRepo playerRepo) =>
            {
                var data = await playerRepo.GetPlayersAsync();

                return Results.Ok(data);
            });

            app.MapPost("/players", async (IPlayerRepo playerRepo, Player player) =>
            {
                await playerRepo.AddPlayer(player);

                return Results.NoContent();
            });
        }
    }
}
