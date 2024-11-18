using MySolution.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("office")]
public class Office
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [Required]
    public string Name { get; set; }

    [Column("address")]
    public string Address { get; set; }

    public long? EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public ICollection<Desk> Desks { get; set; }
}