using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWithIdentityData.Data
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole()
        {
            CreatedDate = DateTime.Now;
        }
        public DateTime CreatedDate { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
