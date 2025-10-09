namespace boardgameStats.Models
{
    public class NemesisGameContent
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int BoardgameId {  get; set; }

        //boardgame details
        public string GameName { get; set; }
        public int MinPLayers { get; set; }
        public int MaxPlayers { get; set; }
    }
}
