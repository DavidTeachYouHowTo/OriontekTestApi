using Microsoft.AspNetCore.Mvc;
using OriontekTest.Services.Dtos;
using OriontekTest.Services.Service.Contract;

namespace OriontekTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly ICustomerAddressServices _customerAddressServices;

        public CustomerAddressController(ICustomerAddressServices customerAddressServices)
        {
            _customerAddressServices = customerAddressServices;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var CustomerAddress = _customerAddressServices.GetAll();

            return Ok(CustomerAddress);
        }

        [HttpGet("GetAllByCustomerId")]
        public IActionResult GetAllByCustomerId(int customerId)
        {
            var CustomerAddress = _customerAddressServices.GetAllByCustomerId(customerId);

            return Ok(CustomerAddress);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var customerAddress = _customerAddressServices.GetById(id);

            return Ok(customerAddress);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CustomerAddressDto customerAddress)
        {
            _customerAddressServices.Create(customerAddress);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomerAddressDto customerAddress)
        {
            _customerAddressServices.Update(customerAddress);

            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _customerAddressServices.Delete(id);

            return Ok();
        }
    }
}
