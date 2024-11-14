﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MySolution.Models
{
    [Table("office")]
    public class Office
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }

        public ICollection<Position> Positions { get; set; }

        public Employee Employee { get; set; }
    }
}
