namespace WebApiP2.Domain.DTO
{
    public class CityDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public string? State { get; set; }
    }
}
