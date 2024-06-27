namespace api.Filters
{
    public class EmployeeSearchQuery
    {
        public string? Name { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

// Creates the searchable value to pass in params and apply pagination
