using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Base;
using ProductApi.Data.Model;
using ProductApi.Data.Uow;
using Serilog;

namespace ProductApi.Controllers
{
    [Route("param/api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Get()
        {
            var categorys = await unitOfWork.CategoryRepository.GetAllAsync();
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Debug("CategoryContoller.GetById");
            var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            category.CreatedAt = DateTime.Now;
            category.CreatedBy = "SystemUser";
            await unitOfWork.CategoryRepository.InsertAsync(category);
            await unitOfWork.CompleteAsync();

            return CreatedAtAction("GetById", new { category.Id }, category);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var item = await unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            item.Name = category.Name;

            unitOfWork.CategoryRepository.Update(item);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            unitOfWork.CategoryRepository.RemoveAsync(item);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}