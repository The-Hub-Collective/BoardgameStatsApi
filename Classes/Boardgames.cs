namespace boardgameStats.Classes
{
    public class Boardgames
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? MinPLayers { get; set; }
        public int? MaxPlayers { get; set; }
        public int GameContentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
