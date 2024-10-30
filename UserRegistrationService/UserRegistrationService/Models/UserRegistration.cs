namespace UserRegistrationService.Models
{
    public class UserRegistration
    {
        public int id { get; set; }
        public string? userName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public string? password { get; set; }
        public string? confirmPassword { get; set; }
    }

    public class UserRoleDto
    {
        public int id { get; set; }
        public string? name { get; set; }
    }

}
