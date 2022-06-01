namespace MusicStore.Models
{
    public class Liked
    {
        public int Id { get; set; }

        public int? Like { get; set; }

        public StrumentoMusicale? strumentoMusicale { get; set; }

        public int StrumentoMusicaleId { get; set; }
    }
}
