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
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public int UserId { get; set; }
    }
}
