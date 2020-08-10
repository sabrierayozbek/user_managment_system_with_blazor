using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlazorWithIdentityData.Data.Migrations;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorWithIdentityData.Data
{

    public class CustomPasswordValidator : IPasswordValidator<ApplicationUser>
    {

        private bool controlForPassword = false;
       
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            List<IdentityError> errors = new List<IdentityError>();
            
            

            user.PasswordHistory.Add(new PasswordHistory()
            {
                userId = user.Id,
                passwordHash = user.PasswordHash
            });

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            if (user.PasswordHash != null)
            {
                if (user.PasswordHistory.OrderByDescending(o => o.CreatedDate).Select(s => s.passwordHash).Take(3).Where(w => passwordHasher.VerifyHashedPassword(user, w, password) != PasswordVerificationResult.Failed).Any())
                {
                    controlForPassword = true;
                }
            }

            if (controlForPassword)
            {     
                    errors.Add(new IdentityError { Code = "Son Kullanılan Üç Şifre Tekrar Kullanılamaz.", Description = "Son Kullanılan Üç Şifre Tekrar Kullanılamaz." });
                    return Task.FromResult(IdentityResult.Failed(errors.ToArray()));        
            }

            //storesPassword.AddRange(user.PasswordHistory.OrderByDescending(o => o.CreatedDate).Select(s=>s.passwordHash).Take(3));
            //int controlForPassNumber = storesPassword.Count;
            //storesPassword.ForEach(j =>
            //{
            //    if (controlForPassNumber == 3 && storesPassword.Any(k=>k.Equals(j)))
            //        controlForPassword = true;   
            //    else
            //        controlForPassword = false;
            //});

            int counter = 0;
            List<string> patterns = new List<string> {
            @"[a-z]",          // lowercase
            @"[A-Z]",          // uppercase
            @"[0-9]",          // digits
            @"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\] ]"
        };

            foreach (string p in patterns)
            {
                if (Regex.IsMatch(password, p))
                {
                    counter++;
                }
            }

            if (counter >= 3)
            {
                return Task.FromResult(IdentityResult.Success);
            }
           
            else
            {
                errors.Add(new IdentityError { Code = "Şartlar sağlanmadı", Description = "Lütfen şu şartlardan en az 3 tanesini gerçekleştiriniz: en az bir küçük harf, en az bir büyük harf, en az bir rakam, en az bir özel semboller." });
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

        }
           
    }
}

