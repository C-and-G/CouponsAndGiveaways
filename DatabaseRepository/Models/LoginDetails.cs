//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseRepository.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginDetails
    {
        public string MemberId { get; set; }
        public string UserId { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public bool VerificationStatus { get; set; }
    
        public virtual UserDetails UserDetails { get; set; }
    }
}