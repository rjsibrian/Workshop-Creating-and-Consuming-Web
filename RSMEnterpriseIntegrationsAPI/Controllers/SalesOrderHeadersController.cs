namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderHeadersController : ControllerBase
    {
        private readonly ISalesOrderHeaderService _service;

        public SalesOrderHeadersController(ISalesOrderHeaderService service)
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
            return Ok(await _service.GetSalesOrderHeaderById(id));
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteSalesOrderHeader(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateSalesOrderHeaderDto dto)
        {
            return Ok(await _service.CreateSalesOrderHeader(dto));
        }
    }
}
