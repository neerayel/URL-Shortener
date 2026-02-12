using System.ComponentModel.DataAnnotations;

namespace Avtobus1ru_Test.Data.Entities
{
    public class LinkEntity
    {
        [Key]
        public string Id { get; set; }
        public string LongURL { get; set; }
        public string ShortURL { get; set; }
        public DateTime CreationDate { get; set; }
        public int ClickCount { get; set; }
    }
}
