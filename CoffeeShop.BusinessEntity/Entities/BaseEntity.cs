using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.BusinessEntity.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }

        [Required]
        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [Required]
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
