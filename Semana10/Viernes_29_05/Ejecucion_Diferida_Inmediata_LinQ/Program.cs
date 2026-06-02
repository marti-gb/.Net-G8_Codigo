class Program
{
    public static void Main(string[] args)
    {
        ////Ejercicio 3: Filtrar y Seleccionar Números
        ////Dado un arreglo de números enteros, filtra los números que están entre 6 y 16
        ////(sin incluir ambos extremos) y almacénalos en una secuencia de enteros
        ////(IEnumerable<int>). Luego, recorre la secuencia resultante y muestra cada
        ////número en la consola.

        //int[] numbers = { 1, 5, 7, 11, 15, 2, 13, 21, 9 };

        //IEnumerable<int> valuesInt = from x in numbers
        //                             where x > 6 && x < 16
        //                             select x;

        ////Ejecucion diferida
        //foreach(int x in valuesInt)
        //{
        //    Console.WriteLine(x);
        //}

        ////------------------------------------------------------------------------------------------------

        ////Ejercicio 4: Filtrar y Ordenar Cadenas
        ////Dado un arreglo de cadenas que representan postres, filtra aquellos que
        ////contienen la palabra "manzana" y ordénalos alfabéticamente.
        ////Muestra los resultados en la consola

        //string[] desserts = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema" };

        //IEnumerable<string> valueString = from p in desserts
        //                                  where p.Contains("manzana")
        //                                  orderby p
        //                                  select p;

        //foreach(string value in valueString)
        //{
        //    Console.WriteLine(value);
        //}

        ////Ejercicio 6: Filtrar Números Pares y Ejecución Diferida
        ////Filtra los números pares de un arreglo y muestra los resultados.
        ////Cambia un valor en el arreglo original después de la primera iteración y
        ////observa cómo la ejecución diferida afecta los resultados.

        //int[] numbersArray = { 1, 5, 7, 11, 15, 2, 13, 21, 9 };

        //IEnumerable<int> valuesIntArray = from x in numbersArray
        //                                  where x % 2 == 0
        //                                  select x;

        //Console.WriteLine("---------------------");
        //Console.WriteLine("---------------------");
        //Console.WriteLine("Ejecucion diferida");
        //foreach(int x in valuesIntArray)
        //{
        //    Console.WriteLine(x);
        //}
        //Console.WriteLine("---------------------");
        //Console.WriteLine("---------------------");
        //Console.WriteLine("Ejecucion diferida despues de la modificacion");
        //numbersArray[0] = 4;
        //foreach (int x in valuesIntArray)
        //{
        //    Console.WriteLine(x);
        //}


        //-----------------------------------------------------------------------------------------

        //Ejercicio 7: Filtrar Números Pares y Ejecución Inmediata
        //Filtra los números pares de un arreglo y almacénalos en un arreglo y una lista.
        //Demuestra la ejecución inmediata cambiando un valor en el arreglo original
        //después de la ejecución, y muestra los resultados.
        Console.WriteLine("Ejecucion inmediata: ");
        Console.WriteLine("----------------");

        int[] numbersTest = { 1, 5, 7, 11, 15, 2, 13, 21, 9 };

        int[] resultInmediata = (from n in numbersTest
                                 where n % 2 == 0
                                 select n).ToArray();

        foreach(int x in resultInmediata)
        {
            Console.WriteLine(x);
        }

        numbersTest[0] = 4;
        Console.WriteLine("----------------");
        Console.WriteLine("Ejecucion inmediata despues de la modificacion");
        foreach (int x in resultInmediata)
        {
            Console.WriteLine(x);
        }
    }
}