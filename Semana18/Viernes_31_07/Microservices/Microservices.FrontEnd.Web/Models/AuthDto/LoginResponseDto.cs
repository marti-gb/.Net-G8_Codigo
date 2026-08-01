namespace Microservices.FrontEnd.Web.Models.AuthDto
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
