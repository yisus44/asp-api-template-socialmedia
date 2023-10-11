using App.Queries;
using Core.Interfaces.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CommandHandlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.CommentRepository.Delete(request.Id);
            _unitOfWork.Save();
        }
    }
}
