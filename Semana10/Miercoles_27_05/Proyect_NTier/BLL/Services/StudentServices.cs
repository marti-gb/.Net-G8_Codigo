using BLL.Dtos;
using BOL.Entities;
using DAL.DataRepository;

namespace BLL.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentDto> GetAllStudents()
        {
            StudentDto studentDto = new StudentDto();
            List<StudentDto> studentsDto = new List<StudentDto>();

            List<Student> students = new List<Student>();
            students = _studentRepository.GetAllStudents();
            foreach (Student student in students)
            {
                studentDto.Id = student.Id;
                studentDto.FirstName = student.FirstName;
                studentDto.LastName = student.LastName;
                studentDto.Email = student.Email;

                studentsDto.Add(studentDto);
            }
            return studentsDto;
        }

        public string SaveStudent(StudentDto studentDto)
        {
            string result = string.Empty;
            if(String.IsNullOrEmpty(studentDto.FirstName) 
                || String.IsNullOrEmpty(studentDto.LastName) 
                || String.IsNullOrEmpty(studentDto.Email))
            {
                return result = "Es obligatorio llenar todos los campos";
            }

            Student newStudent = new Student();

            newStudent.FirstName = studentDto.FirstName;
            newStudent.LastName = studentDto.LastName;
            newStudent.Email = studentDto.Email;

            try
            {
                result = _studentRepository.SaveStudent(newStudent);

                if (result == "Estudiante registrado con exito")
                {
                    return result;
                }
                else
                {
                    return result = "Error al registrar el estudiante";
                }
            }
            catch (Exception ex)
            {
                return result = ex.Message;
            }
        }

        public string UpdateStudent(StudentDto studentDto)
        {
            string result = string.Empty;
            if ( studentDto.Id <= 0
                || String.IsNullOrEmpty(studentDto.FirstName)
                || String.IsNullOrEmpty(studentDto.LastName)
                || String.IsNullOrEmpty(studentDto.Email))
            {
                return result = "Es obligatorio llenar todos los campos";
            }

            Student newStudent = new Student();

            newStudent.Id = studentDto.Id;
            newStudent.FirstName = studentDto.FirstName;
            newStudent.LastName = studentDto.LastName;
            newStudent.Email = studentDto.Email;

            try
            {
                result = _studentRepository.UpdateStudent(newStudent);

                if (result == "Estudiante actualizado con exito")
                {
                    return result;
                }
                else
                {
                    return result = "Error al actualizar el estudiante";
                }
            }
            catch (Exception ex)
            {
                return result = ex.Message;
            }
        }
        public string DeleteStudent(int id)
        {
            string result = string.Empty;
            if (id <= 0)
            {
                return result = "Id del estudiante no valido";
            }

            try
            {
                result = _studentRepository.DeleteStudent(id);

                if (result == "Estudiante eliminado exitosamente")
                {
                    return result;
                }
                else
                {
                    return result = "Error al eliminar el estudiante";
                }
            }
            catch (Exception ex)
            {
                return result = ex.Message;
            }
        }

        

        

       
    }
}
