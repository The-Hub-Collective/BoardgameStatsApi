namespace boardgameStats.Classes
{
    public class UsersCreateRequest
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
