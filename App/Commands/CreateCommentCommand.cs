using App.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Commands
{
    public class CreateCommentCommand : IRequest
    {
        public CreateCommentDto CreateCommentDto;
        public int UserId;
    }
}
