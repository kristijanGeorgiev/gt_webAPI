using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class CreateUserDto
    {
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [Required]
        public string Role { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? WorkPositionId { get; set; }
        public bool Available { get; set; }
    }

}
