using api.DTO;
using api.Models;
namespace api.Mappers
{
    // Mappers is a conversion method to convert from entity data(object) to DTO
    public static class EmployeesMappers
    {
        public static EmployeesDto ToEmployeesDto(this Employee staffDto)
        {
            return new EmployeesDto
            {
                Id = staffDto.Id,
                Fname = staffDto.Fname,
                Lname = staffDto.Lname,
                Address = staffDto.Address,
                Contact = staffDto.Contact,
                Company = staffDto.Company,
                Summary = staffDto.Summary
            };
        }

        public static Employee ToCreateStaffDto(this CreateStaffDto createStaffDto)
        {
            return new Employee
            {
                Fname = createStaffDto.Fname,
                Lname = createStaffDto.Lname,
                Address = createStaffDto.Address,
                Contact = createStaffDto.Contact,
                Pay = createStaffDto.Pay,
                Company = createStaffDto.Company,
                Summary = createStaffDto.Summary
            };
        }

        /* public static Employees ToEditStaffDto(this UpdateStaffDto editStaffDto)
        {
            return new Employees
            {
                Fname = editStaffDto.Fname,
                Lname = editStaffDto.Lname,
                Address = editStaffDto.Address,
                Contact = editStaffDto.Contact,
                Pay = editStaffDto.Pay,
                Company = editStaffDto.Company,
                Summary = editStaffDto.Summary
            };
        } */
    }
}
