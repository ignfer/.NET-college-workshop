using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("position")]
public class Desk
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [Required]
    public string Name { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

}
