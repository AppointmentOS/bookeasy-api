using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookeasy.Api.DTOs;
using Bookeasy.Application.Common.Enums;
using Bookeasy.Application.Common.Models;
using Bookeasy.Application.Posts.Commands.CreatePostCommand;
using Bookeasy.Application.Posts.Commands.CreateVoteCommand;
using Bookeasy.Application.Posts.Commands.DeletePostCommand;
using Bookeasy.Application.Posts.Commands.DeleteVoteCommand;
using Bookeasy.Application.Posts.Commands.UpdatePostCommand;
using Bookeasy.Application.Posts.Queries.GetAllPostQuery;
using Bookeasy.Application.Posts.Queries.GetPostByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bookeasy.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PostsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all post
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var posts = await _mediator.Send(new GetAllPostQuery());
            posts = posts.Select(GetResourceWithUri).ToList();
            return Ok(posts);
        }

        /// <summary>
        /// Get a single post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [Route("{postId}")]
        [HttpGet]
        [ProducesResponseType(typeof(PostDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPost(string postId)
        {
            var query = new GetPostByIdQuery
            {
                Id = postId
            };
            var post = await _mediator.Send(query);
            return Ok(GetResourceWithUri(post));
        }

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="newPost"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost(NewPostDto newPost)
        {
            var userId = User.GetUserId();
            var post = await _mediator.Send(new CreatePostCommand()
            {
                Body = newPost.Body,
                Title = newPost.Title,
                PostType = newPost.PostType,
                OwnerUserId = userId
            });
            return Created(nameof(GetPost), GetResourceWithUri(post.Payload));
        }

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [Route("{postId}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePost(string postId)
        {
            await _mediator.Send(new DeletePostCommand { PostId = postId });
            return NoContent();
        }

        /// <summary>
        /// Update a post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("{postId}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePost([FromRoute] string postId, UpdatePostCommand command)
        {
            command.PostId = postId;
            var post = await _mediator.Send(command);
            return Ok(GetResourceWithUri(post));
        }

        /// <summary>
        /// Vote a post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="vote"></param>
        /// <returns></returns>
        [Route("{postId}/vote")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateVote([FromRoute] string postId, [FromBody] CreateVoteDto vote)
        {
            await _mediator.Send(new CreateVoteCommand()
            {
                UserId = User.GetUserId(),
                PostId = postId,
                VoteType = Enum.Parse<VoteType>(vote.VoteType, true)
            });
            return Created("", null);
        }

        /// <summary>
        /// Remove vote
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [Route("{postId}/vote")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteVote([FromRoute] string postId)
        {
            await _mediator.Send(new DeleteVoteCommand
            {
                UserId = User.GetUserId(),
                PostId = postId
            });
            return Ok();
        }

        private PostDto GetResourceWithUri(PostDto dto)
        {
            var result = JsonConvert.DeserializeObject<PostDto>(JsonConvert.SerializeObject(dto));
            result.Id = UrlHelperExtensions.Action(Url, nameof(GetPost), new { postId = result.Id });
            return result;
        }
    }
}