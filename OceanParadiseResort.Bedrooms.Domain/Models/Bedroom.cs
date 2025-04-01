using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanParadiseResort.Bedrooms.Domain.Models
{

    // Vai ser utilizado para a integração com as reservas a partir de uma lógica de disponibilidade
    // Adicionar descrição futuramente e talvez uma IA?

    public class Bedroom
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        public string? Number { get; set; }

        [Required]
        [Range(1, 10)]
        public int Capacity { get; set; }

        // Por enquanto, não é uma propriedade obrigatoria por conta da arquiterura de multiplos microservices

        public bool Available { get; set; } = true;
    }
}
