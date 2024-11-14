using System.ComponentModel.DataAnnotations.Schema;

namespace MySolution.Models
{
    [Table("position")]
    public class Position
    {

        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public Office Office { get; set; }

        public ICollection<Queue> Queues { get; set; }
    }
}
