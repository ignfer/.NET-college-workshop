using System.ComponentModel.DataAnnotations.Schema;

namespace MySolution.Models
{
    [Table("appointment")]
    public class Appointment
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("ci_number")]
        public string CINumber { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }


        public Service Service { get; set; }
    }

}
