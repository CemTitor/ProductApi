using Microsoft.AspNetCore.Mvc;
using ProductApi.Data.Model;
using ProductApi.Data.Uow;
using Serilog;

namespace ProductApi.Controllers
{
    [Route("param/api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ShoppingListController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shoppingLists = await unitOfWork.ShoppingListRepository.GetAllAsync();
            return Ok(shoppingLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Debug("ShoppingListController.GetById");
            var shoppingList = await unitOfWork.ShoppingListRepository.GetByIdAsync(id);
            if (shoppingList is null)
            {
                return NotFound();
            }
            return Ok(shoppingList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingList shoppingList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            shoppingList.CreatedAt = DateTime.Now;
            shoppingList.CreatedBy = "SystemUser";
            await unitOfWork.ShoppingListRepository.InsertAsync(shoppingList);
            await unitOfWork.CompleteAsync();

            return CreatedAtAction("GetById", new { shoppingList.Id }, shoppingList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ShoppingList shoppingList)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var item = await unitOfWork.ShoppingListRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            item.Name = shoppingList.Name;

            unitOfWork.ShoppingListRepository.Update(item);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await unitOfWork.ShoppingListRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            unitOfWork.ShoppingListRepository.RemoveAsync(item);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}