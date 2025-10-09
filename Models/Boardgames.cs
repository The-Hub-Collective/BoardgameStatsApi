namespace boardgameStats.Classes
{
    public class Boardgames
    {
        public long Id { get; init; }
        public required string Name { get; set; }
        public int MinPLayers { get; set; }
        public int MaxPlayers { get; set; }
        public int GameContentId { get; set; }
    }
}
