namespace ado4.mcs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TablesManufacturer")]
    public partial class TablesManufacturer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TablesManufacturer()
        {
            newEquipment = new HashSet<newEquipment>();
            TablesModel = new HashSet<TablesModel>();
        }

        [Key]
        public int intManufacturerID { get; set; }

        [StringLength(50)]
        public string strManufacturerChecklistId { get; set; }

        [StringLength(50)]
        public string strName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<newEquipment> newEquipment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TablesModel> TablesModel { get; set; }
    }
}
