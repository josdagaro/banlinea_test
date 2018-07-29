using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [Required]
        public int DocumentTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Password { get; set; }
    }
}
