using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO
{
    public class PaginatedResponse<T> : ResponseDto<T>
    {
        public PaginatedResponse(T? Data, int totalPages, int page, int perPage, bool success = true, params string[] errors) : base(Data, success, errors)
        {
            TotalPages = totalPages;
            Page = page;
            PerPages = perPage;
        }

        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int PerPages { get; set; }
    }
}
