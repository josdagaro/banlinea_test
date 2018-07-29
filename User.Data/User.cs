using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be integer")]
        public int DocumentId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be integer")]
        public int DocumentTypeId { get; set; }

        [Required]
        [RegularExpression(@"^[A-z\sñÑáéíóú]*$", ErrorMessage = "Must be string, no special characters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-z\sñÑáéíóú]*$", ErrorMessage = "Must be string, no special characters")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be integer")]
        public string MobileNumber { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Password { get; set; }

        [RegularExpression(@"^[A-z\sñÑáéíóú]*$", ErrorMessage = "Must be string, no special characters")]
        public string ResidenceCountry { get; set; }

        [RegularExpression(@"^[A-z\sñÑáéíóú]*$", ErrorMessage = "Must be string, no special characters")]
        public string ResidenceCity { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be integer")]
        public Nullable<int> Age { get; set; }

        [RegularExpression(@"^[A-z\sñÑáéíóú]*$", ErrorMessage = "Must be string, no special characters")]
        public string Address { get; set; }

        [RegularExpression(@"^[A-z\sñÑáéíóú]*$", ErrorMessage = "Must be string, no special characters")]
        public string Company { get; set; }
    }
}
