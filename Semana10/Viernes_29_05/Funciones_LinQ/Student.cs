namespace Funciones_LinQ
{
    public class Student
    {
        private string name;
        private string id;
        private string course;
        public double average;

        public string Name { get { return name; } set { name = value; } }
        public string Id { get { return id; } set { id = value; } }
        public string Course { get { return course; } set { course = value; } }
        public double Average { get { return average; } set { average = value; } }

        public Student(string Name, string Id, string Course, double Average)
        {
            name = Name;
            id = Id;
            course = Course;
            average = Average;
        }

        public override string ToString()
        {
            return string.Format("Nombre {0}, {1}, curso: {2}, promedio: {3}", name, id, course, average);
        }
    }
}
