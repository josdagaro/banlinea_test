using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace User.Data
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Must be an email, example: some@some.com")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be integer")]
        public int UserId { get; set; }
    }
}
