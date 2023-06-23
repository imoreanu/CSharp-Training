namespace WebApplication1.DataTransferObject
{
    public class RoomDto : BaseEntityDto
    {
        public int Number { get; set; }
        public int HotelId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
