using Avtobus1ru_Test.Data.Entities;
using Avtobus1ru_Test.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1ru_Test.Data.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly DataContext dbContext;

        public LinkRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<LinkEntity> CreateAsync(LinkEntity item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinkEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LinkEntity> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinkEntity>> GetLongFromShortAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(LinkEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
