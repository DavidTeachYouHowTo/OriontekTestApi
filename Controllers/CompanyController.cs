using Microsoft.AspNetCore.Mvc;
using OriontekTest.Services.Dtos;
using OriontekTest.Services.Service.Contract;

namespace OriontekTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var company = _companyServices.GetAll();

            return Ok(company);
        }

        [HttpGet("GetAllActive")]
        public IActionResult GetAllActive()
        {
            var company = _companyServices.GetAllActive();

            return Ok(company);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var company = _companyServices.GetById(id);

            return Ok(company);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CompanyDto company)
        {
            _companyServices.Create(company);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CompanyDto company)
        {
            _companyServices.Update(company);

            return Ok();
        }
    }
}
