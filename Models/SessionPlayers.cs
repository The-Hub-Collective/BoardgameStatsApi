namespace boardgameStats.Classes
{
    public class SessionPlayers
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public bool Survived { get; set; }
        public string? Character { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
