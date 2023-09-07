//Escribe un método llamado SumarVectores que tome dos vectores de enteros como parámetros
//y devuelva un nuevo vector que sea la suma de los dos vectores.
//Si los vectores tienen longitudes diferentes, lanza una excepción ArgumentException
//para indicar que los vectores deben ser del mismo tamaño.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 1: Suma de vectores");
        //Console.WriteLine("Ingresa el vector con los componentes separados por comas");
        int[] v1 = LlenarVector();
        int[] v2 = LlenarVector();
        int[] suma = SumarVectores(v1, v2);
        Console.WriteLine("Vector suma: ");
        foreach(int i in suma) Console.WriteLine(i);
    }

    public static int[] LlenarVector()
    {
        bool entradaValida = false;
        int[] vector = null;

        while (!entradaValida)
        {
            Console.WriteLine("Ingrese los elementos del vector separados por coma:");
            string input = Console.ReadLine();
            string[] elementos = input.Split(',');

            if (elementos.Any(x => string.IsNullOrWhiteSpace(x))) // Verificar que no haya elementos vacíos
            {
                Console.WriteLine("Error: el vector no puede contener elementos vacíos");
                continue;
            }

            vector = new int[elementos.Length];

            for (int i = 0; i < elementos.Length; i++)
            {
                bool esNumero = int.TryParse(elementos[i], out int numero);

                if (!esNumero)
                {
                    Console.WriteLine("Error: el elemento {0} no es un número válido", elementos[i]);
                    break;
                }

                vector[i] = numero;
            }

            entradaValida = true;
        }

        return vector;
    }
    public static int[] SumarVectores(int[] vector1, int[] vector2)
    {
        try
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Los vectores deben ser del mismo tamaño");
            }

            int[] resultado = new int[vector1.Length];

            for (int i = 0; i < vector1.Length; i++)
            {
                resultado[i] = vector1[i] + vector2[i];
            }

            return resultado;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
