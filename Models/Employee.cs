namespace api.Models;

// This corresponds directly to the rows that will be created in the SQL db after migration
public class Employee
{
    public int Id { get; set; }
    public string? Fname { get; set; }
    public string? Lname { get; set; }
    public string? Address { get; set; }
    public string? Contact { get; set; }
    public int Pay { get; set; }
    public string? Company { get; set; }
    public string? Summary { get; set; }
}