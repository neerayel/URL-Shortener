using Avtobus1ru_Test.Data.Entities;

namespace Avtobus1ru_Test.Data.Interfaces
{
    public interface ILinkRepository
    {
        Task<LinkEntity> CreateAsync(LinkEntity item);
        Task<List<LinkEntity>> GetAllAsync();
        Task<LinkEntity> GetByIdAsync(int id);
        Task<LinkEntity> GetLongFromShortAsync(string shortURLKey);
        Task<bool> UpdateAsync(LinkEntity item);
        Task<bool> DeleteAsync(int id);
    }
}
