using Radzen.Blazor.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySolution.Models
{
    [Table("service")]
    public class Service
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("start")]
        public DateTime Start { get; set; }

        [Column("end")]
        public DateTime End { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
