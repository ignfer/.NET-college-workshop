using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("appointment")]
public class Appointment
{
    [Key]
    [Column("id")]
    public long Id { get; set; }


    [Column("queue_id")]
    [Required]
    public long? QueueId { get; set; } // Foreign Key to Queue
    public Queue Queue { get; set; } // Navigation property to Queue


    [Column("start_date")]
    [Required]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime? EndDate { get; set; }


    [Column("desk_id")]
    [Required]
    public long? DeskId { get; set; } // Foreign Key to Desk
    public Desk Desk { get; set; } // Navigation property to Desk

}