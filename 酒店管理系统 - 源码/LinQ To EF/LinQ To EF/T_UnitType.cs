//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinQ_To_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_UnitType
    {
        public T_UnitType()
        {
            this.T_OutInInfo = new HashSet<T_OutInInfo>();
            this.T_StockInfo = new HashSet<T_StockInfo>();
        }
    
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public Nullable<bool> IsValid { get; set; }
    
        public virtual ICollection<T_OutInInfo> T_OutInInfo { get; set; }
        public virtual ICollection<T_StockInfo> T_StockInfo { get; set; }
    }
}
