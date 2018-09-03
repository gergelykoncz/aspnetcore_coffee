using CoffeeShop.BusinessEntity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.BusinessEntity.Entities
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        public Order()
        {
            this.Items = new List<OrderItem>();
        }

        [Required]
        public OrderState State { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int ETA { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
