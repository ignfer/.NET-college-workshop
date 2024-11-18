using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySolution.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        public ICollection<Office> Offices { get; set; }
    }

}
