namespace SearchClassLibrary.Dto
{
    public class ServiceReponse
    {
        public record class GeneralResponse(bool Flag, string Message);
        public record class LoginResponse(bool Flag, string Token, string Message);
    }
}
