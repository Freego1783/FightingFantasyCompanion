using FightingFantasyCompanion.Shared.Models;

namespace FightingFantasyCompanion.Shared.Services
{
    public interface IAdventureService
    {
        Task<List<Adventure>> GetAll();
        Task<Adventure?> GetById(string Id);
        Task DeleteAdventure(string Id);
        Task SaveAdventure(Adventure adventure);
        Adventure CreateAdventure();
    }
}
