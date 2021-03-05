namespace OSROH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Intimacy")]
    public partial class Intimacy
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string UserID1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string UserID2 { get; set; }

        public bool isBlock { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
