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
    
    public partial class XResistanceScreen
    {
        public int XScreen_id { get; set; }
        public Nullable<int> cable_id { get; set; }
        public Nullable<int> cross_area { get; set; }
        public Nullable<int> screen_area { get; set; }
        public Nullable<double> S { get; set; }
        public Nullable<double> d { get; set; }
        public Nullable<double> dzh { get; set; }
        public string paving_type { get; set; }
        public string material { get; set; }
        public Nullable<double> X { get; set; }
    
        public virtual Resistance Resistance { get; set; }
    }
}
