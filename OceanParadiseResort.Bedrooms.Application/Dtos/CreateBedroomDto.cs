using System.ComponentModel.DataAnnotations;

namespace OceanParadiseResort.Bedrooms.Application.Dtos
{
    public class CreateBedroomDto
    {
        [Required]
        [MaxLength(8)]
        public string? Number { get; set; }

        [Required]
        [Range(1, 10)]
        public int Capacity { get; set; }

        public bool Available { get; set; } = true;
    }
}
