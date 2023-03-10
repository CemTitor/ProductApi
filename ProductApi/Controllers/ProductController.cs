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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Get()
        {
            var products = await unitOfWork.ProductRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Debug("ProductContoller.GetById");
            var product = await unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
       
            product.CreatedAt = DateTime.Now;
            product.CreatedBy = "SystemUser";
            await unitOfWork.ProductRepository.InsertAsync(product);
            await unitOfWork.CompleteAsync();

            return CreatedAtAction("GetById", new { product.Id }, product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var item = await unitOfWork.ProductRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            item.Name = product.Name;

            unitOfWork.ProductRepository.Update(item);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.NormalUser)]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await unitOfWork.ProductRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            unitOfWork.ProductRepository.RemoveAsync(item);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}