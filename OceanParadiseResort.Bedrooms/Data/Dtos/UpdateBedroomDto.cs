using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace OceanParadiseResort.Bedrooms.Data.Dtos
{
    public class UpdateBedroomDto
    {    

        [Required]
        [MaxLength(8)]
        public string? Number { get; set; }

        [Required]
        [Range(1, 10)]
        public int Capacity { get; set; }

        public bool Available { get; set; }
    }
}
