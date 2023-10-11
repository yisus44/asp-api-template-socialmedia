using App.Commands;
using App.DTO;
using App.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto CreateCommentDto)
        {
            var userId = GetUserId();
            if (userId is null) return Unauthorized();
            await _mediator.Send(
            new CreateCommentCommand()
            {
                CreateCommentDto = CreateCommentDto,
                UserId = (int)userId
            });
            return Ok(new ResponseDto<bool>(true));
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var comment = await _mediator.Send(new GetCommentQuery() { Id = id });
            if (comment is null) return NotFound(new ResponseDto<bool>(false, false, "Not found post"));
            return Ok(new ResponseDto<CommentDto>(comment));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var comment = await _mediator.Send(new GetCommentQuery() { Id = id });
            if (comment is null) return NotFound(new ResponseDto<bool>(false, false, "Not found post"));
            await _mediator.Send(new DeleteCommentCommand() { Id = id });
            return Ok(new ResponseDto<bool>(true));
        }
    }
}
