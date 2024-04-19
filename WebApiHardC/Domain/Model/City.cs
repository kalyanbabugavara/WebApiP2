namespace WebApiP2.Domain.Model
{
    public class City
    {
        public Guid Id { get; set; }

        
        public string Name { get; set; }

        public int Rank { get; set; }

        public string? State { get; set; }
    }
}
