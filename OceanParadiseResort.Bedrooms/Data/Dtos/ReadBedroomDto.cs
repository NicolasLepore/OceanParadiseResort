using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OceanParadiseResort.Bedrooms.Data.Dtos
{
    public class ReadBedroomDto
    {
        
        public int Id { get; internal set; }
        public string? Number { get; internal set; }
        public int Capacity { get; internal set; }
        public bool Available { get; internal set; } 
    }
}
