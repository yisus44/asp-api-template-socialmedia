using App.Commands;
using Core.Entities;
using Core.Interfaces.Persistance;
using MediatR;

namespace App.CommandHandlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post()
            {
                Description = request.createPostDto.Description,
                Title = request.createPostDto.Title,
                UserId=request.UserId
            };
            _unitOfWork.PostRepository.Insert(post);
            _unitOfWork.Save();
        }
    }
}
