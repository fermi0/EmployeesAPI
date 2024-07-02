using api.DTO;
using api.Filters;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController] // Defines this is an api controller
    [Route("/api/[Controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IStaffRepository _StaffRepo; // The DI is stored in _StaffRepo & holds reference to repository
        // The StaffRepositoy implements IStaffResposity, & is returned back in IStaffRespository, then it is called here
        public EmployeesController(IStaffRepository StaffRepo) // This is a dependency injection(DI) 
        {
            _StaffRepo = StaffRepo;
        }

        [HttpGet] // Indicates the following action method
        public async Task<IActionResult> GetEmployeeQ([FromQuery] EmployeeSearchQuery query) // Retrieve filtered list of employees based on query params
        {
            var employee = await _StaffRepo.GetQueryAsync(query);
            var employeeQDto = employee.Select(i => i.ToEmployeesDto()); // Each(i) employee in _StaffRepo is converted using DTO

            return Ok(employeeQDto); // Returns Converted employees list
        }

        [HttpGet("all")] // Indicates the following action method
        public async Task<IActionResult> GetAll() // Retrieve filtered list of employees based on query params
        {
            var getAll = await _StaffRepo.GetAllAsync();
            var employeeDto = getAll.Select(i => i.ToEmployeesDto()); // Each(i) employee in _StaffRepo is converted using DTO

            return Ok(employeeDto);
        }

        [HttpGet]
        [Route("{id:int}")] // Validate id as numbers
        public async Task<IActionResult> GetId([FromRoute] int id) // id is extracted from route(url)
        {
            var employeeId = await _StaffRepo.GetIdAsync(id);
            if (employeeId == null)
            {
                return NotFound();
            }
            return Ok(employeeId.ToEmployeesDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStaffDto staffDto) // FromBody usually means Json or XML
        {
            var createStaff = staffDto.ToCreateStaffDto();
            await _StaffRepo.AddAsync(createStaff);
            // Returns the newly created data through GetID() action method where id arugument in GetID() is newly created Id
            return CreatedAtAction(nameof(GetId), new { id = createStaff.Id }, createStaff.ToEmployeesDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        // id of a data to be updated & FromBody is what is updated 
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStaffDto editDto)
        {
            var editStaff = await _StaffRepo.UpdateAsync(id, editDto);
            if (editStaff == null)
            {
                return NotFound();
            }

            return Ok(editStaff.ToEmployeesDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var delEmployee = await _StaffRepo.DeleteAsync(id);
            if (delEmployee == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
