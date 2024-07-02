using api.DTO;
using api.Filters;
using api.Models;

namespace api.Interfaces
{
    public interface IStaffRepository // This is an abstration method which is a blueprint for repo to implement
    {
        Task<List<Employee>> GetAllAsync(); // This provides filtering
        Task<List<Employee>> GetQueryAsync(EmployeeSearchQuery query); // This provides filtering
        Task<Employee?> GetIdAsync(int id);
        Task<Employee> AddAsync(Employee createEmployee);
        Task<Employee?> UpdateAsync(int id, UpdateStaffDto editDto);
        Task<Employee?> DeleteAsync(int id);
    }
}

// This is implemented in Repository & returned back by repository & directly into the controller(EmployeesController)
