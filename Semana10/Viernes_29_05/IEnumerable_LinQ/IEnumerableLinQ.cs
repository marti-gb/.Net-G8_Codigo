namespace IEnumerable_LinQ
{
    public class IEnumerableLinQ
    {
        public static void Main(string[] args)
        {
            //*----------------------------IEnumerable-------------------------*
            List<Employee> employees = new List<Employee>() 
            {
                new Employee { Id = 1, Name = "Jhon", Salary = 10000 },
                new Employee { Id = 2, Name = "Jane", Salary = 15000 },
                new Employee { Id = 3, Name = "Tom", Salary = 12000 }
            };

            IEnumerable<Employee> query = from n in employees
                                          where n.Salary > 10000
                                          select n;

            foreach(Employee emp in query)
            {
                Console.WriteLine(emp.Name);
            }

            //*-------------------------IQueryable----------------------------*
            IQueryable<Employee> queryable = employees.AsQueryable()
                                                      .Where( x => x.Salary > 10000);

            foreach(Employee emp in queryable)
            {
                Console.WriteLine(emp.Name);
            }

        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Salary { get; set; }

    }
}
