using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManagement.Models
{
    public class LoginModel
    {
        [Required]
        public String? UserName {set; get;}
        public String? Password {set; get;}
    }
}