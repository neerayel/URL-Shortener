namespace Avtobus1ru_Test.MidLogic.Models
{
    public class LinkModel
    {
        public int Id { get; set; }
        public string LongURL { get; set; }
        public string ShortURLKey { get; set; }
        public string ShortURL { get; set; }
        public DateTime CreationDate { get; set; }
        public int ClickCount { get; set; }
    }
}
