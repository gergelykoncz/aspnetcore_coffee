using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.BusinessEntity.Entities
{
    [Table("Log")]
    public class Log : BaseEntity
    {
        public Log()
        {
            this.Entries = new List<LogEntry>();
        }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [InverseProperty("Log")]
        public virtual ICollection<LogEntry> Entries { get; set; }
    }
}
