namespace api.DTO
{
    public class CreateStaffDto
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public int Pay { get; set; }
        public string? Company { get; set; }
        public string? Summary { get; set; }
    }
}
