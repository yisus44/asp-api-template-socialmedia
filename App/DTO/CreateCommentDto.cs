using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO
{
    public class CreateCommentDto
    {
        [Required]
        [StringLength(25)]
        public string Content { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid post id")]
        public int PostId { get; set; }
    }
}
