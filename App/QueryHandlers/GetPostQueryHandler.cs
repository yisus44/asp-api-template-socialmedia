using App.DTO;
using App.Queries;
using Core.Interfaces.Persistance;
using MediatR;


namespace App.QueryHandlers
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPostQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PostDto?> Handle(GetPostQuery query, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetOneByIdAsync(query.Id);
            if (post is null) return null;
            return new PostDto()
            {
                Description = post.Description,
                Title = post.Title,
                Id = post.Id
            };
        }
    }
}
