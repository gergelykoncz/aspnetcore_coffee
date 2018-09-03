using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.BusinessEntity.Entities
{
    [Table("OrderItem")]
    public class OrderItem : BaseEntity
    {
        [Required]
        [ForeignKey("CoffeeId")]
        public virtual Coffee Coffee { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
