namespace Bases_LinQ
{
    public class Syntax_LinQ
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            //*---------------Syntax Query---------------------*
            Console.WriteLine("Syntax Query");

            var querySyntax = from n in numbers
                              where n > 2
                              select n;

            foreach(var n in querySyntax)
            {
                Console.WriteLine(n);
            }

            //*-------------Method Query------------------------*
            Console.WriteLine("Method Query");
            var methodSyntax = numbers.Where(p =>  p > 2);

            foreach(var n in methodSyntax)
            {
                Console.WriteLine(n);
            }

            //*-------------Mixed Query-------------------------*
            Console.WriteLine("Mixed Query");
            var mixedQuery = (from n in numbers
                              where n > 2
                              select n).Sum();

            Console.WriteLine("La suma de toso los numeros mayores que dos es: "+mixedQuery);

        }
    }
}
