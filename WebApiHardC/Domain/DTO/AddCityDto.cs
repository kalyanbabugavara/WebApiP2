using System.ComponentModel.DataAnnotations;

namespace WebApiP2.Domain.DTO
{
    public class AddCityDto
    {
        [Required]
        public string Name { get; set; }

        [Range(0, 10)]
        public int Rank { get; set; }

        [MinLength(2, ErrorMessage ="the length should be minimum of 2 chars") ]
        [MaxLength(3, ErrorMessage ="The length should be minimum of 3 chars")]
        public string State { get; set; }
    }
}
