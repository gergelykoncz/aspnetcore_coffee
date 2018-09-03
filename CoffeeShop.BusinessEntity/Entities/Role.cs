using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.BusinessEntity.Entities
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
