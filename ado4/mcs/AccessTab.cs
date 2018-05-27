namespace ado4.mcs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessTab")]
    public partial class AccessTab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccessTab()
        {
            AccessUser = new HashSet<AccessUser>();
        }

        [Key]
        public int intTabID { get; set; }

        [StringLength(255)]
        public string strTabName { get; set; }

        [StringLength(512)]
        public string strDescription { get; set; }

        [StringLength(255)]
        public string strTabUrl { get; set; }

        [StringLength(255)]
        public string strTabGroupName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccessUser> AccessUser { get; set; }
    }
}
