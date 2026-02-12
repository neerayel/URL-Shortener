using Avtobus1ru_Test.Data.Entities;
using LX.TestPad.DataAccess.Interfaces;

namespace Avtobus1ru_Test.Data.Interfaces
{
    public interface ILinkRepository : IRepository<LinkEntity>
    {
        Task<List<LinkEntity>> GetLongFromShortAsync();
    }
}
