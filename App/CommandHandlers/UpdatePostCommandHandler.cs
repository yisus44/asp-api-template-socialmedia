

using App.Commands;
using Core.Interfaces.Persistance;
using MediatR;

namespace App.CommandHandlers
{
    internal class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetOneByIdAsync(request.Id);
            if (request.updatePostDto.Title != null)
                post.Title= request.updatePostDto.Title;
            if (request.updatePostDto.Description != null)
                post.Description = request.updatePostDto.Description;
            _unitOfWork.PostRepository.Update(post);
            _unitOfWork.Save();
        }
    }
}
