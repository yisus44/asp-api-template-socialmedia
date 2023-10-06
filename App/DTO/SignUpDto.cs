using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO
{
    public class SignUpDto
    {
        [Required]
        [StringLength(25)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(25)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
