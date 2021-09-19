using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends_api.Models
{
    public class Friends
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
