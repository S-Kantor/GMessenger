//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GMessenger
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int message_id { get; set; }
        public int group_id { get; set; }
        public string text { get; set; }
    
        public virtual Group Group { get; set; }
    }
}
