using WebApplication1.Entities;

namespace WebApplication1.DataTransferObject
{
    public class ReservationDto : BaseEntityDto
    {
        public string CustomerName { get; set; } = default!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Room Room { get; set; } = default!;
        public int RoomId { get; set; }
    }
}
