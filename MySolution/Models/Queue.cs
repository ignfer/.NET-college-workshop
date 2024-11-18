using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("queue")]
public class Queue
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("date")]
    [Required]
    public DateTime Date { get; set; }

    [Column("status")]
    [Required]
    public string Status { get; set; }

    [Column("ci_number")]
    [Required]
    public string CINumber { get; set; }
}