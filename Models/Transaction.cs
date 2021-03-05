namespace OSROH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        [StringLength(10)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Trip_id { get; set; }

        [Required]
        [StringLength(50)]
        public string From_wallet { get; set; }

        [Required]
        [StringLength(50)]
        public string To_wallet { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Amount { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual Wallet Wallet { get; set; }

        public virtual Wallet Wallet1 { get; set; }
    }
}
