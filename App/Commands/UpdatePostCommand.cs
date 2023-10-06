using App.DTO;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Commands
{
    public class UpdatePostCommand : IRequest
    {
        public int Id { get; set; }
        public UpdatePostDto updatePostDto { get; set; }
        public Post post { get; set; }
    }
}
