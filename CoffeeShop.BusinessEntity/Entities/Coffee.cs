using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.BusinessEntity.Entities
{
    [Table("Coffee")]
    public class Coffee : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public byte PreparationTime { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
