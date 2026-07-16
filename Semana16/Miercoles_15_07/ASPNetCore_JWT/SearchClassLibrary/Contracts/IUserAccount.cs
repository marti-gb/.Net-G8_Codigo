using SearchClassLibrary.Dto;
using static SearchClassLibrary.Dto.ServiceReponse;

namespace SearchClassLibrary.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(UserDto userDto);
        Task<LoginResponse> LoginAccount(LoginDto loginDto);
    }
}
