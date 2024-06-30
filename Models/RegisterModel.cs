using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityManagement.Models
{
    public class RegisterModel
    {
        [Required]

        public String? UserName {set; get;}
        [Required]

        public String? Password {set; get;}
        [Required]
        
        public String? Email {set; get;}
        [Required]

        public List<SelectListItem>? Roles {set; get;}
        [Required]

        public String? SelectedRole {set; get;}

    }
}