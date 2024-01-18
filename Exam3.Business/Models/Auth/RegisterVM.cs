using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3.Business.Models.Auth
{
    public class RegisterVM
    {
        [EmailAddress]
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }

        [PasswordPropertyText]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
