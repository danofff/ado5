namespace ado4.mcs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessUser")]
    public partial class AccessUser
    {
        [Key]
        public int intAccessID { get; set; }

        public int? intUserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dCreated { get; set; }

        public int? intTabID { get; set; }

        public int? intGroupAccessId { get; set; }

        public int? intLocationId { get; set; }

        public virtual AccessTab AccessTab { get; set; }
    }
}
