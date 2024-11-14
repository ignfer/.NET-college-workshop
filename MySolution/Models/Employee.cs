using System.ComponentModel.DataAnnotations.Schema;

namespace MySolution.Models
{
    [Table("employee")]
    public class Employee
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<Office> Offices { get; set; }
    }

}
