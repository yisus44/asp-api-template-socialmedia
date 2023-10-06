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
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.PostRepository.Delete(request.Id);
            _unitOfWork.Save();
        }
    }
}
