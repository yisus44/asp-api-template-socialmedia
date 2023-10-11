using App.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Queries
{
    public class GetCommentQuery : IRequest<CommentDto?>
    {
        public int Id { get; set; }
    }
}
