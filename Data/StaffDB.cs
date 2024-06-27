using api.Models;
using Microsoft.EntityFrameworkCore;
namespace api.Data;

/* This is where database table is created after migration update with default options using blueprint
   provided by Employee class & stored in Employees for later manipulation using EF*/
public class StaffDB(DbContextOptions<StaffDB> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
}

