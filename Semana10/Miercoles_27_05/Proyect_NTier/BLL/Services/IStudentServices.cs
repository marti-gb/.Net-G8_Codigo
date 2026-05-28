using BLL.Dtos;

namespace BLL.Services
{
    public interface IStudentServices
    {
        List<StudentDto> GetAllStudents();
        string SaveStudent(StudentDto student);
        string UpdateStudent(StudentDto student);
        string DeleteStudent(int id);

    }
}
