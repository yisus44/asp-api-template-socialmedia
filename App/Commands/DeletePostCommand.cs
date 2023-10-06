using App.DTO;
using MediatR;

namespace App.Queries
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
    }
}
