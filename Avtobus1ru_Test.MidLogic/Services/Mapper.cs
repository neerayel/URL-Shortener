using Avtobus1ru_Test.MidLogic.Models;
using Avtobus1ru_Test.Data;
using Avtobus1ru_Test.Data.Entities;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Avtobus1ru_Test.MidLogic.Services
{
    public static class Mapper
    {
        public static LinkModel LinkEntityToModel(LinkEntity linkEntity)
        {
            return new LinkModel {
                Id = linkEntity.Id,
                LongURL = linkEntity.LongURL,
                ShortURLKey = linkEntity.ShortURLKey,
                ShortURL = "",
                CreationDate = linkEntity.CreationDate,
                ClickCount = linkEntity.ClickCount,
            };
        }

        public static LinkEntity LinkModelToEntity(LinkModel linkEntity)
        {
            return new LinkEntity
            {
                Id = linkEntity.Id,
                LongURL = linkEntity.LongURL,
                ShortURLKey = linkEntity.ShortURLKey,
                CreationDate = linkEntity.CreationDate,
                ClickCount = linkEntity.ClickCount,
            };
        }

        public static LinkEntity NewLink(string longURL)
        {
            return new LinkEntity
            {
                LongURL = longURL,
                ShortURLKey = IdGenerator(),
                CreationDate = DateTime.Now,
                ClickCount = 0,
            };
        }


        public static string IdGenerator()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "");
        }
    }
}
