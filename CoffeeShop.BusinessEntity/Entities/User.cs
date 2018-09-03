using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.BusinessEntity.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Password { get; set; }

        [Required]
        [MaxLength(512)]
        public string Email { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
