using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManagement.Models
{
    public class RegisterModel
    {
        public String? UserName {set; get;}
        public String? Password {set; get;}
        public String? Email {set; get;}
    }
}