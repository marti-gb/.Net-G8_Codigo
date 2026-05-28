using BOL.Entities;
using DAL.DataContext;
using Dapper;
using System.Data;

namespace DAL.DataRepository
{
    public  class StudentRepository : IStudentRepository
    {
        private readonly IDapperConnectionHelper _dapperConnectionHelper;
        public StudentRepository(IDapperConnectionHelper dapperConnectionHelper)
        {
            _dapperConnectionHelper = dapperConnectionHelper;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (IDbConnection dbConnection = _dapperConnectionHelper.GetDapperContextHelper())
                {
                    string query = "select * from Student where is_active = 1";

                    students = dbConnection.Query<Student>(query, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return students;
        }

        public string SaveStudent(Student student)
        {
            string result = string.Empty;
            try
            {
                using(IDbConnection dbConnection = _dapperConnectionHelper.GetDapperContextHelper())
                {
                    string query = "insert into Student (first_name, last_name, email, is_active)" +
                        "values (@FistName, @LastName, @Email, @IsActive)";

                    dbConnection.Execute(query, new
                    {
                        FistName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.Email,
                        IsActive = true
                    }, commandType: CommandType.Text);

                    result = "Estudiante registrado con exito";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string UpdateStudent(Student student)
        {
            string result = "";
            try
            {
                using(IDbConnection dbConnection = _dapperConnectionHelper.GetDapperContextHelper())
                {
                    string query = "Update Student set first_name = @FirstName, last_name = @LastName, email = @Email " +
                        "where id = @Id";

                    dbConnection.Execute(query, new
                    {
                        Id = student.Id,
                        FistName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.Email
                    }, commandType: CommandType.Text);

                    result = "Estudiante actualizado con exito";
                }
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string DeleteStudent(int id)
        {
            string result = string.Empty;
            try
            {
                using(IDbConnection dbConnection = _dapperConnectionHelper.GetDapperContextHelper())
                {
                    string query = "Update Student set is_active = false where id = @Id";

                    dbConnection.Execute(query, new
                    {
                        Id = id,
                    }, commandType: CommandType.Text);

                    result = "Estudiante eliminado exitosamente";
                }
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

    }
}
