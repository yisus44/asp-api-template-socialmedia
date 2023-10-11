using App.DTO;
using App.Queries;
using Core.Interfaces.Persistance;
using MediatR;


namespace App.QueryHandlers
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCommentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommentDto?> Handle(GetCommentQuery query, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.GetOneByIdAsync(query.Id);
            if (comment is null) return null;
            return new CommentDto()
            {
                Content = comment.Content,
                Id = comment.Id
            };
        }
    }
}
