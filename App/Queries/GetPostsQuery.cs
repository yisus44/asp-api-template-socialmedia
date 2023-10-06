using App.DTO;
using Core.Entities;
using MediatR;

namespace App.Queries
{
    public class GetPostsQuery : IRequest<PaginatedResponse<List<PostDto>>>
    {
        public PaginationDto<Post> Pagination { get; set;}
    }
}
