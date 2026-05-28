using BOL.Entities;

namespace DAL.DataRepository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        string SaveStudent(Student student);
        string UpdateStudent(Student student);
        string DeleteStudent(int id);

    }
}
