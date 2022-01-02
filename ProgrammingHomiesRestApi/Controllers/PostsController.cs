using Microsoft.AspNetCore.Mvc;
using phra.Controllers;
using phra.Dtos.PostDtos;
using ProgrammingHomiesRestApi;
using ProgrammingHomiesRestApi.Dtos.UserDtos;
using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Interfaces;

namespace phra.Controllers
{
    [ApiController]
    [Route(ControllerConstants.PostsRoute)]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository repository;

        public PostsController(IPostRepository repository)
        {
            this.repository = repository;
        }


        // POST /Posts
        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePostAsync(CreatePostDto itemDto)
        {
            Post Post = new Post()
            {
                Id = Guid.NewGuid(),
                EndTime = itemDto.EndTime,
                Text = itemDto.Text,
                Title = itemDto.Title,
            };

            await repository.CreateAsync(Post);


            return CreatedAtAction(nameof(GetPostsAsync), new { id = Post.Id }, Post.AsDto());
        }

        // GET /Posts
        [HttpGet]
        public async Task<IEnumerable<PostDto>> GetPostsAsync()
        {
            var items = (await repository.GetAllAsync()).Select(item => item.AsDto());

            return items;
        }

        // DELETE /Posts/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostAsync(Guid id)
        {
            await repository.DeleteAsync(id);

            return NoContent();
        }

        // GET /Posts/{id}
        [HttpGet("{id}")]
        public async Task<PostDto> GetPostAsync(Guid id)
        {
            var item = await repository.GetAsync(id);

            return item.AsDto();
        }

        // PUT /Posts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PostDto>> UpdatePostAsync(Guid id, PostDto Post)
        {
            Post updatedPost = new Post()
            {
                Id = id,
                Title = Post.Title,
                Text = Post.Text,
                PostUser = Post.PostUser,
                EndTime = Post.EndTime,
            };

            await repository.UpdateAsync(updatedPost);

            return CreatedAtAction(nameof(GetPostsAsync), new { id = Post.Id }, updatedPost.AsDto());
        }

    }
}
