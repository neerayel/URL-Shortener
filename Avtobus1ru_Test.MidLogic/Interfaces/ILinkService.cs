using Avtobus1ru_Test.MidLogic.Models;

namespace Avtobus1ru_Test.MidLogic.Interfaces
{
    public interface ILinkService
    {
        Task<LinkModel> CreateAsync(string longURL);
        Task<List<LinkModel>> GetAllAsync();
        Task<LinkModel> GetByIdAsync(int id);
        Task<LinkModel> GetLongFromShortAsync(string shortURL);
        Task UpdateAsync(LinkModel item);
        Task DeleteAsync(int id);
    }
}
