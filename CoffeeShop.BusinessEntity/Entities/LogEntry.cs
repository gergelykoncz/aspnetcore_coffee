using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.BusinessEntity.Entities
{
    [Table("LogEntry")]
    public class LogEntry : BaseEntity
    {
        [Required]
        public string Message { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public long LogId { get; set; }

        [Required]
        [ForeignKey("LogId")]
        public virtual Log Log { get; set; }
    }
}
