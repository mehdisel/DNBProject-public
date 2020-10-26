using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DNBProject.UI.Models
{
    public class UserLoginViewModel
    {
        public int UserID { get; set; }
        public bool RememberMe { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }
        public User User { get; set; }
    }
}
