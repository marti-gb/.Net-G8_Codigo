using Funciones_LinQ;

class Program
{
    //Ejercicio 11: En este ejercicio, deberás trabajar con la lista de estudiantes
    //y realizar operaciones de conteo, reversión, ordenamiento y cálculos de
    //agregación.

    public static void Main(string[] args)
    {
        List<Student> listStudents = new List<Student>
        {
            new Student("Gabriel", "A100", "Mercadotecnia", 10.0),
            new Student("Luis", "S250", "Orientado a objetos", 9.0),
            new Student("Juan", "S875", "Programacion Basica", 5.0),
            new Student("Susana", "A432", "Mercadotecnia", 8.7),
            new Student("Pablo", "A156", "Mercadotecnia", 4.3),
            new Student("Alberto", "S456", "Orientado a objetos", 8.3),
        };

        Console.WriteLine("*----------------------------------*");
        Console.WriteLine("Conteo");
        int queryConteo = (from n in listStudents
                           where n.average > 5
                           select n).Count();

        Console.WriteLine("La cantidad de mayores a un promeido de 5 son: " + queryConteo);


        //Reversion
        Console.WriteLine("*----------------------------------*");
        Console.WriteLine("Reversion");
        var queryReversion = (from n in listStudents
                              where n.average > 5
                              select n).Reverse();
        foreach (Student student in queryReversion)
        {
            Console.WriteLine(student.Name);
        }

        //Ordenamiento
        Console.WriteLine("*----------------------------------*");
        Console.WriteLine("Ordenamiento");
        var queryOrdenamiento = from x in listStudents
                                orderby x.Average descending
                                select x;
        foreach (Student student in queryOrdenamiento)
        {
            Console.WriteLine(student.Name);
        }

        //Other operations

        int[] numbers = { 2, 8, 25, 16, 31, 5, 34, 24, 11 };

        int min = (from n in numbers select n).Min();
        Console.WriteLine("La cantidad minima es: " + min);

    }
}