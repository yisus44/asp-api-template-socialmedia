using App.Commands;
using Core.Entities;
using Core.Interfaces.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CommandHandlers
{
    public class CreateCommentHandler  : IRequestHandler<CreateCommentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var post = new Comment()
            {
                Content = request.CreateCommentDto.Content,
                PostId = request.CreateCommentDto.PostId,
                UserId = request.UserId
            };
            _unitOfWork.CommentRepository.Insert(post);
            _unitOfWork.Save();
        }
    }
}
