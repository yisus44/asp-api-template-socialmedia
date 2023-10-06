using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO
{
    public class UpdatePostDto
    {
    
        [StringLength(25)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
    }
}
