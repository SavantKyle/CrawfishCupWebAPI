namespace Models.Entity
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RatingId { get; set; }
        public int TeamId { get; set; }
    }
}