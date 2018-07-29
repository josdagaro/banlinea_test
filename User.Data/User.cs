using System;

namespace User.Data
{
    public class User
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public int DocumentTypeId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public string Password { get; set; }
    }
}
