using App.DTO;
using App.Queries;
using Core.Interfaces.Persistance;
using Infra.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.QueryHandlers
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, PaginatedResponse<List<PostDto>> >
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPostsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResponse<List<PostDto>>> Handle(GetPostsQuery query, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.PostRepository.GetAsync(query.Pagination);
            var postsDto = posts.Select(p => new PostDto()
                {
                    Description = p.Description,
                    Title = p.Title,
                    Id = p.Id
                }).ToList();
            var totalCount = await _unitOfWork.PostRepository.Count(query.Pagination);
            var totalPages = totalCount == 0 ? 0 : Math.Ceiling((double)totalCount / query.Pagination.PerPage) ;
            return new PaginatedResponse<List<PostDto>>(postsDto, (int)totalPages, query.Pagination.Page, query.Pagination.PerPage);
        }
    }
}
