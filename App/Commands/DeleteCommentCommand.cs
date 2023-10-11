using App.DTO;
using MediatR;

namespace App.Queries
{
    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
