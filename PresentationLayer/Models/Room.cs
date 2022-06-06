namespace PresentationLayer.Models
{
    public class Room
    {
        public int Id { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; }
        public int TypeId { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsBooked { get; set; }
        public bool IsAvailable { get; set; }
    }
}
