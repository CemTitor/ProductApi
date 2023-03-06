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
    public class ListItemController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ListItemController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Get()
        {
            var listItems = await unitOfWork.ListItemRepository.GetAllAsync();
            return Ok(listItems);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Debug("ListItemController.GetById");
            var listItem = await unitOfWork.ListItemRepository.GetByIdAsync(id);
            if (listItem is null)
            {
                return NotFound();
            }
            return Ok(listItem);
        }

        [HttpPost]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Post([FromBody] ListItem listItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            listItem.CreatedAt = DateTime.Now;
            listItem.CreatedBy = "SystemUser";
            await unitOfWork.ListItemRepository.InsertAsync(listItem);
            await unitOfWork.CompleteAsync();

            return CreatedAtAction("GetById", new { listItem.Id }, listItem);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Put(int id, [FromBody] ListItem listItem)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var item = await unitOfWork.ListItemRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            item.Product.Name = listItem.Product.Name;

            unitOfWork.ListItemRepository.Update(item);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await unitOfWork.ListItemRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            unitOfWork.ListItemRepository.RemoveAsync(item);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}