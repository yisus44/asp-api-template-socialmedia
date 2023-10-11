using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO
{
    public abstract class PaginateDto
    {
        public int Page { get; set; } = 1;
        public int PerPage { get ; set ; } = 10;

        public string? Sort = null;
    }
}
