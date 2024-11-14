using System.ComponentModel.DataAnnotations.Schema;

namespace MySolution.Models
{
    [Table("queue")]
    public class Queue
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("position")]
        public int Position { get; set; }

        [Column("status")]
        public string Status { get; set; }

        public Position PositionEntity { get; set; }
    }

}
