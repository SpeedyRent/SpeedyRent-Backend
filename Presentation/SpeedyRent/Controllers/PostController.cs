using Domain.SpeedyRent.Model.Commands;
using Domain.SpeedyRent.Model.Queries;
using Domain.SpeedyRent.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.SpeedyRent.Resources;

namespace Presentation.SpeedyRent.Controllers
{
    /// <summary>
    /// Controller for managing posts.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostQueryService _postQueryService;
        private readonly IPostCommandService _postCommandService;

        public PostController(IPostQueryService postQueryService, IPostCommandService postCommandService)
        {
            _postQueryService = postQueryService;
            _postCommandService = postCommandService;
        }

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>Returns a list of all posts.</returns>
        /// <response code="200">Returns all posts successfully.</response>
        /// <response code="404">No posts found.</response>
        /// <response code="500">An error occurred on the server.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostResource>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllPostsQuery();
                var posts = await _postQueryService.Handle(query);

                if (posts == null || !posts.Any())
                    return NotFound();

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Gets a post by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the post.</param>
        /// <returns>Returns the post if found.</returns>
        /// <response code="200">Returns the post with the specified ID.</response>
        /// <response code="404">Post not found.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PostResource), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPostByIdQuery(id);
            var post = await _postQueryService.Handle(query);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="createPostResource">The details of the post to create.</param>
        /// <returns>Returns the newly created post.</returns>
        /// <response code="201">Post created successfully.</response>
        /// <response code="400">Invalid post data.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreatePostResource createPostResource)
        {
            if (!ModelState.IsValid) 
                return BadRequest("Invalid resource data.");

            var command = new CreatePostCommand(createPostResource.Title, createPostResource.Content, createPostResource.AuthorId);
            var postId = await _postCommandService.Handle(command);

            return CreatedAtAction(nameof(GetById), new { id = postId }, new { id = postId });
        }

        /// <summary>
        /// Updates an existing post by ID.
        /// </summary>
        /// <param name="id">The ID of the post to update.</param>
        /// <param name="updatePostResource">The updated post details.</param>
        /// <response code="204">Post updated successfully.</response>
        /// <response code="400">Invalid post data.</response>
        /// <response code="404">Post not found.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostResource updatePostResource)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid resource data.");

            var command = new UpdatePostCommand(id, updatePostResource.Title, updatePostResource.Content);
            var result = await _postCommandService.Handle(command);

            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// Deletes a post by ID.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <response code="204">Post deleted successfully.</response>
        /// <response code="404">Post not found.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePostCommand(id);
            var result = await _postCommandService.Handle(command);

            return result ? NoContent() : NotFound();
        }
    }
}
