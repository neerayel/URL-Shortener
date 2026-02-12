using Avtobus1ru_Test.MidLogic.Interfaces;
using Avtobus1ru_Test.MidLogic.Models;
using Avtobus1ru_Test.Data.Interfaces;

namespace Avtobus1ru_Test.MidLogic.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepository;
        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task<LinkModel> CreateAsync(string longURL)
        {
            var newLink = await _linkRepository.CreateAsync( Mapper.NewLink(longURL) );
            return Mapper.LinkEntityToModel(newLink);
        }

        public async Task<List<LinkModel>> GetAllAsync()
        {
            var links = await _linkRepository.GetAllAsync();
            return links.Select(Mapper.LinkEntityToModel).ToList();
        }

        public async Task<LinkModel> GetByIdAsync(int id)
        {
            return Mapper.LinkEntityToModel( await _linkRepository.GetByIdAsync(id) );
        }

        public async Task<LinkModel> GetLongFromShortAsync(string shortURLkey)
        {
            return Mapper.LinkEntityToModel( await _linkRepository.GetLongFromShortAsync(shortURLkey) );
        }

        public async Task UpdateAsync(LinkModel item)
        {
            await _linkRepository.UpdateAsync(Mapper.LinkModelToEntity(item));
        }

        public async Task DeleteAsync(int id)
        {
            await _linkRepository.DeleteAsync(id);
        }
    }
}
