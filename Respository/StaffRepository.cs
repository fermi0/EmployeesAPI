using api.DTO;
using api.Data;
using api.Models;
using api.Filters;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Respository
{
    public class StaffRepository : IStaffRepository // Implementation of the interface
    {
        private readonly StaffDB _db; // Stores DI in _db
        public StaffRepository(StaffDB db) // DI. Handles db calls so that controller doesnt have to
        {
            _db = db;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetQueryAsync(EmployeeSearchQuery query)
        {
            var filterQ = _db.Employees.AsQueryable(); // Implements query params
            if (!String.IsNullOrWhiteSpace(query.Name)) // Params is name
            {
                filterQ = filterQ.Where(i => (i.Fname ?? "").Contains(query.Name)); // Checks if the queried name exist
            }

            var skipNum = (query.PageNumber -1) * query.PageSize; // Page 1 -1 * 10 = 0; this means skip 0 pages, and fetch first 10 items
            return await filterQ.Skip(skipNum).Take(query.PageSize).ToListAsync();
        }

        public async Task<Employee?> GetIdAsync(int id)
        {
            return await _db.Employees.FindAsync(id);
        }

        public async Task<Employee> AddAsync(Employee createEmployee)
        {
            await _db.Employees.AddAsync(createEmployee);
            await _db.SaveChangesAsync();
            return createEmployee;
        }

        public async Task<Employee?> UpdateAsync(int id, UpdateStaffDto editDto)
        {
            // Each(i) employee in Employees checks if id exist, return default value if not.
            var editStaff = await _db.Employees.FirstOrDefaultAsync(i => i.Id == id);
            if (editStaff == null)
            {
                return null;
            }
            // Converts to DTO before updating table
            editStaff.Fname = editDto.Fname;
            editStaff.Lname = editDto.Lname;
            editStaff.Address = editDto.Address;
            editStaff.Contact = editDto.Contact;
            editStaff.Pay = editDto.Pay;
            editStaff.Company = editDto.Company;
            editStaff.Summary = editDto.Summary;

            await _db.SaveChangesAsync();
            return editStaff;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var delEmployee = await _db.Employees.FirstOrDefaultAsync(i => i.Id == id);
            if (delEmployee == null)
            {
                return null;
            }
            _db.Employees.Remove(delEmployee);
            await _db.SaveChangesAsync();
            return delEmployee;
        }
    }
}
