
using App.Queries;
using App.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Core.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginateProductsDto paginationDto)
        {
            var posts = await _mediator.Send(new GetPostsQuery() { Pagination = paginationDto });
            return Ok(posts);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDto createPostDto)
        {
            await _mediator.Send(
                new CreatePostCommand() { createPostDto = createPostDto });
            return Ok(new ResponseDto<bool>(true));
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostDto updatePostDto)
        {
            var post = await _mediator.Send(new GetPostQuery() { Id = id });
            if (post is null) return NotFound(new ResponseDto<bool>(false, false, "Not found post"));
            await _mediator.Send(
                new UpdatePostCommand()
                {
                    updatePostDto = updatePostDto,
                    Id = id
                });
            return Ok(new ResponseDto<bool>(true));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var post = await _mediator.Send(new GetPostQuery() { Id = id });
            if (post is null) return NotFound(new ResponseDto<bool>(false, false, "Not found post"));
            return Ok(new ResponseDto<PostDto>(post));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var post = await _mediator.Send(new GetPostQuery() { Id = id });
            if (post is null) return NotFound(new ResponseDto<bool>(false, false, "Not found post"));
            await _mediator.Send(new DeletePostCommand() { Id = id });
            return Ok(new ResponseDto<bool>(true));
        }

        [HttpGet("demo")]
        [Authorize]
        public IActionResult GetSecure()
        {
            return Ok(new ResponseDto<bool>(true));
        }
    }
}
