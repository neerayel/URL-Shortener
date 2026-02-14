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

        public async Task<LinkEntity> CreateAsync(LinkEntity item)
        {
            try
            {
                await dbContext.Links.AddAsync(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new LinkEntity();
            }

            return item;
        }

        public async Task<List<LinkEntity>> GetAllAsync()
        {
            return await dbContext.Links.ToListAsync();
        }

        public async Task<LinkEntity> GetByIdAsync(int id)
        {
            return await dbContext.Links.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LinkEntity> GetLongFromShortAsync(string shortURLKey)
        {
            return await dbContext.Links.FirstOrDefaultAsync(x => x.ShortURLKey == shortURLKey);
        }

        public async Task<bool> UpdateAsync(LinkEntity item)
        {
            try
            {
                if (await DeleteAsync(item.Id)) await CreateAsync(item);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await dbContext.Links.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                try
                {
                    dbContext.Links.Remove(item);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
