using App.DTO;
using MediatR;

namespace App.Commands
{
    public class CreatePostCommand : IRequest
    {
       public CreatePostDto createPostDto;
    }
}
