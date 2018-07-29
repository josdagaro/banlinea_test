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
        public string Address { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
