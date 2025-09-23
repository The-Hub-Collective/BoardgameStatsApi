namespace boardgameStats.Classes
{
    public class GameSessions
    {
        public int Id { get; set; }
        public int BoargameId { get; set; }
        public int Players { get; set; }
        public DateTime PlayedAt { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Outcome { get; set; }
        public string? Difficulty { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
