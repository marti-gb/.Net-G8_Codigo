using DomainLayer.Dtos;
using DomainLayer.Interface;
using DomainLayer.Models;
using InfraestructureLayer.DataAccessLayer;

namespace ServiceLayer.Implementations
{
    public class UserService : IUser
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string AddUser(UserDto userDto)
        {
            var newUser = new User();
            try
            {
                newUser.Name = userDto.Name;
                newUser.Phone = userDto.Phone;
                newUser.Email = userDto.Email;
                newUser.Address = userDto.Address;
                newUser.CreatedDate = DateTime.UtcNow;

                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                return "Usuario " + newUser.Name + " registrado con exito" ;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateUser(UserDto userDto)
        {
            try
            {
                var userToUpdate = _dbContext.Users.Find(userDto.Id);
                if (userToUpdate != null)
                {
                    userToUpdate.Name = userDto.Name;
                    userToUpdate.Phone = userDto.Phone;
                    userToUpdate.Email = userDto.Email;
                    userToUpdate.Address = userDto.Address;
                    userToUpdate.UpdatedDate = DateTime.UtcNow;

                    _dbContext.SaveChanges();

                    return "Usuario " + userToUpdate.Name + " actualizado con exito";
                }

                return "Usuario no encontrado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeleteUser(int id)
        {
            try
            {
                var userToDelete = _dbContext.Users.Find(id);
                if (userToDelete != null)
                {
                    userToDelete.IsDeleted = true;

                    _dbContext.SaveChanges();
                    return "Usuario " + userToDelete.Name + " eliminado con exito";
                }
                return "Usuario no encontrado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<UserDto> GetListUsers()
        {
            try
            {
                var usersDtos = new List<UserDto>();
                var users = _dbContext.Users.Where(x=>!x.IsDeleted).ToList();
                foreach (var user in users)
                {
                    var userDto = new UserDto();
                    userDto.Id = user.Id;
                    userDto.Name = user.Name;
                    userDto.Phone = user.Phone;
                    userDto.Email = user.Email;
                    userDto.Address = user.Email;

                    usersDtos.Add(userDto);
                    userDto = new UserDto();
                }

                return usersDtos;
            }
            catch (Exception ex)
            {
                return new List<UserDto>();
            }
        }

        public UserDto GetUserById(int id)
        {
            try
            {
                var userDto = new UserDto();
                var user = _dbContext.Users.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault() ?? null;

                if (user != null)
                {
                    userDto.Id = user.Id;
                    userDto.Name = user.Name;
                    userDto.Phone = user.Phone;
                    userDto.Email = user.Email;
                    userDto.Address = user.Email;
                }
                return userDto;
            }
            catch (Exception ex)
            {
                return new UserDto();
            }
        }

        
    }
}
