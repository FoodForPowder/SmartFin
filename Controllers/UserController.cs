using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartFin.Db;
using SmartFin.DTO;
using SmartFin.Entities;
using SmartFin.Service;

namespace SmartFin.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> userRepository;

        public UserController()
        {
            this.userRepository = new PostrgresRepository<User>();
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> PostAsync(CreateUserDto entity)
        {
            var user = new User
            {
                guid = Guid.NewGuid(),
                number = entity.number,
                income = entity.income
            };
            await userRepository.CreateAsync(user);
            return CreatedAtAction(nameof(GetByIdAsync), new { user.guid, entity });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var exisitingUser = await userRepository.GetAsync(id);

            if (exisitingUser == null)
            {
                return NotFound();

            }

            await userRepository.DeleteAsync(exisitingUser.guid);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAsync()
        {   using(var context = new SmartFinDbContext()){
            var users = (await context.Users.Include(x=> x.Categorys).ToListAsync())
            .Select(x => x.AsDto()).ToList();
            return Ok(users);
        }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetByIdAsync(Guid id)
        {
            var user = await userRepository.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateUserDto user)
        {
            var existingUser = await userRepository.GetAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.number = user.number;
            existingUser.income = user.income;
            await userRepository.UpdateAsync(existingUser);
            return NoContent();
        }
    }
}