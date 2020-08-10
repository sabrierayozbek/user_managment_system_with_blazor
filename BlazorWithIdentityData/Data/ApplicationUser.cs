using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BlazorWithIdentityData.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsAdmin { get; set; }

        public virtual IList<PasswordHistory> PasswordHistory { get; set; }
    

        public ApplicationUser() : base()
        {
            PasswordHistory = new List<PasswordHistory>();
           
        }
        //public List<UserDetails> UserRoles { get; set; } = new List<UserDetails>();
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
