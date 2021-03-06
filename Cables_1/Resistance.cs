//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cables_1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resistance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resistance()
        {
            this.Current = new HashSet<Current>();
            this.Loses = new HashSet<Loses>();
            this.ThermalResistance = new HashSet<ThermalResistance>();
            this.XResistanceScreen = new HashSet<XResistanceScreen>();
        }
    
        public int cable_id { get; set; }
        public Nullable<int> cross_area { get; set; }
        public Nullable<int> screen_area { get; set; }
        public Nullable<double> R0 { get; set; }
        public Nullable<double> R_ { get; set; }
        public Nullable<double> yp { get; set; }
        public Nullable<double> yb { get; set; }
        public Nullable<double> xs { get; set; }
        public Nullable<double> xp { get; set; }
        public Nullable<double> R { get; set; }
        public string material { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Current> Current { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loses> Loses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThermalResistance> ThermalResistance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XResistanceScreen> XResistanceScreen { get; set; }
    }
}
