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
    
    public partial class T_SupplierType
    {
        public T_SupplierType()
        {
            this.T_SupplierInfo = new HashSet<T_SupplierInfo>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> IsValid { get; set; }
    
        public virtual ICollection<T_SupplierInfo> T_SupplierInfo { get; set; }
    }
}
