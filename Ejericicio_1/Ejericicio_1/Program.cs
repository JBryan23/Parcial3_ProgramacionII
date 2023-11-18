//Ejercicio1
//Realice un programa en C# que simule una calculadora esta calculadora tenga las opciones de sumar,  restar, multiplicacion y division, cada una de estas opciones
// deberan estar almacenada en un arreglo del tamaño indicado segun las operaciones , si el valor encontrado dentro del arreglo es correcto , realizar la
//operacion correspondiente , si no utilizar el manejo de excepciones necesarias para evitar que su programa de error repentinamente y introducir deben ser enteros
// y utilizar el manejo de las excepciones para evitar el error indefenido de la division entre cero, donde nmuestre el mensaje:
// 
// Ejemplo de mensaje: int[] opciones = {1,2,3,4};

class Ejercicio_Uno
{
    static void Main()
    {
        int[] opciones = { 1, 2, 3, 4, 5};

        do
        {
            Console.WriteLine("------------------Menu-----------------------");
            Console.WriteLine("|Usuario porfavor elija la opcion a realizar |");
            Console.WriteLine("|1- Suma                                     |");
            Console.WriteLine("|2- Resta                                    |");
            Console.WriteLine("|3- Multiplicación                           |");
            Console.WriteLine("|4- División                                 |");
            Console.WriteLine("|0- Salir                                    |");
            Console.WriteLine("---------------------------------------------");

            int Opcion_Selecionada;
            if (int.TryParse(Console.ReadLine(), out Opcion_Selecionada))
            {
                try
                {
                    if (Opcion_Selecionada == 0)
                    {
                        Console.WriteLine("Programa Finalizado");
                        break;
                    }
                    else if (Array.IndexOf(opciones, Opcion_Selecionada) != -1)
                    {
                        Console.WriteLine("Nota: Usar solo numeros enteros");
                        Console.Write("Porfavor ingrese el primer número:");
                        int nummero1 = int.Parse(Console.ReadLine());

                        Console.Write("Porfavor ingrese el segundo número:");
                        int numero2 = int.Parse(Console.ReadLine());

                        RealizarOperacion(Opcion_Selecionada, nummero1, numero2);
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error, recuerde que no puede divir entre 0 ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error");
            }

            Console.WriteLine();
        } while (true);
    }

    static void RealizarOperacion(int opcion, int numero_1, int numero_2)
    {
        switch (opcion)
        {
            case 1:
                Console.WriteLine("Resultado de la suma: " + (numero_1 + numero_2) );
                break;
            case 2:
                Console.WriteLine("Resultado de la resta: " + (numero_1 - numero_2) );
                break;
            case 3:
                Console.WriteLine("Resultado de la multiplicacion: " + (numero_1 * numero_2) );
                break;
            case 4:
                if (numero_2 == 0)
                {
                    throw new DivideByZeroException();
                }
                else
                {
                    Console.WriteLine("Resultado de la division:" + (numero_1 / numero_2) );
                }
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
    }
}

//Josue Bryan Hernandez Zelaya