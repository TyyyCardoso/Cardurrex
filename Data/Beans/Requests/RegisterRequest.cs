namespace CardurrexAPI.Data.Beans.Requests
{
    public class RegisterRequest
    {

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }
        public string BirthDate { get; set; }
    }
}
