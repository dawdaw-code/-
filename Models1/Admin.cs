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
    
    public partial class Admin
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int LoginCount { get; set; }
        public Nullable<int> DepartId { get; set; }
        public int RoleId { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int IsDelete { get; set; }
    
        public virtual Depart Depart { get; set; }
        public virtual Role Role { get; set; }
    }
}
