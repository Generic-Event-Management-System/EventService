namespace EventService.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Fee { get; set; }
        public required string Venue { get; set; }
        public required DateTime EventDate { get; set; }
        public required int MaxTeamsAllowed { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
