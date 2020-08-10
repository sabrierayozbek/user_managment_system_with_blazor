using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithIdentityData.Data
{
    public class PasswordHistory
    {
        [Key]
        public string passwordHistoryId { get; set; }
        public string userId { get; set; }
        public string passwordHash { get; set; }
        public PasswordHistory()
        {
            passwordHistoryId = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }
        public DateTime CreatedDate { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
