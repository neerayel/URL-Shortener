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

        public async Task<bool> CreateAsync(string longURL)
        {
            if (String.IsNullOrWhiteSpace(longURL)) return false;

            var newLink = await _linkRepository.CreateAsync( Mapper.NewLink(longURL) );
            return true;
        }

        public async Task<List<LinkModel>> GetAllAsync(string redirrectionURL)
        {
            var links = await _linkRepository.GetAllAsync();
            var models = links.Select(Mapper.LinkEntityToModel).ToList();
            foreach(var model in models)
            {
                model.ShortURL = redirrectionURL + model.ShortURLKey;
            }
            return models;
        }

        public async Task<LinkModel> GetByIdAsync(int id)
        {
            if (id < 0) return new LinkModel();

            return Mapper.LinkEntityToModel( await _linkRepository.GetByIdAsync(id) );
        }

        public async Task<string> GetLongFromShortAsync(string shortURLkey)
        {
            if (String.IsNullOrWhiteSpace(shortURLkey)) return "";

            var linkEntity = await _linkRepository.GetLongFromShortAsync(shortURLkey);
            linkEntity.ClickCount += 1;
            await _linkRepository.UpdateAsync(linkEntity);

            return linkEntity.LongURL;
        }

        public async Task<bool> UpdateAsync(LinkModel item)
        {
            if (item == null) return false;

            await _linkRepository.UpdateAsync(Mapper.LinkModelToEntity(item));
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id < 0) return false;

            await _linkRepository.DeleteAsync(id);
            return true;
        }
    }
}
