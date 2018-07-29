using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public int DocumentId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public int DocumentTypeId { get; set; }

        [Required]
        [RegularExpression(@"^[A-z\sñÑ]*$")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-z\sñÑ]*$")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public string MobileNumber { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Password { get; set; }

        [RegularExpression(@"^[A-z\sñÑ]*$")]
        public string ResidenceCountry { get; set; }

        [RegularExpression(@"^[A-z\sñÑ]*$")]
        public string ResidenceCity { get; set; }

        [RegularExpression(@"^[0-9]*$")]
        public Nullable<int> Age { get; set; }

        [RegularExpression(@"^[A-z\sñÑ]*$")]
        public string Address { get; set; }

        [RegularExpression(@"^[A-z\sñÑ]*$")]
        public string Company { get; set; }
    }
}
