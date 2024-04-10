namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
             return Ok(await _service.GetAll());
        }

        [HttpGet("Get")]        
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            return Ok(await _service.GetProductById(id));
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteProduct(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            return Ok(await _service.CreateProduct(dto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            return Ok(await _service.UpdateProduct(dto));
        }
    }
}
