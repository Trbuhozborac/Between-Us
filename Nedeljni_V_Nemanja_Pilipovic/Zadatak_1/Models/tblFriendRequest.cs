//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFriendRequest
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateOfCreating { get; set; }
        public Nullable<bool> Accepted { get; set; }
        public Nullable<int> FKRequestSender { get; set; }
        public Nullable<int> FKRequestReceiver { get; set; }
    
        public virtual tblUser tblUser { get; set; }
        public virtual tblUser tblUser1 { get; set; }
    }
}