//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        public int Id { get; set; }
        public string LocationNum { get; set; }
        public string LocationName { get; set; }
        public int StorageId { get; set; }
        public int LocaTypeId { get; set; }
        public int IsForbidden { get; set; }
        public int IsDefault { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int IsDelete { get; set; }
    }
}
