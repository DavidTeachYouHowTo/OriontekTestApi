using Microsoft.AspNetCore.Mvc;
using OriontekTest.Services.Dtos;
using OriontekTest.Services.Service.Contract;

namespace OriontekTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var customer = _customerServices.GetAll();

            return Ok(customer);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerServices.GetById(id);

            return Ok(customer);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CustomerDto customer)
        {
            _customerServices.Create(customer);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomerDto customer)
        {
            _customerServices.Update(customer);

            return Ok();
        }
    }
}
