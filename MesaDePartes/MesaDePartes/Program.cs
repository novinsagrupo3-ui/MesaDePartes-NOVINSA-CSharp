
using System;

namespace MesaDePartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = -1;

            do
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("       SISTEMA DE MESA DE PARTES");
                Console.WriteLine("                 NOVINSA");
                Console.WriteLine("=========================================");

                Console.WriteLine("1. Registrar expediente");
                Console.WriteLine("2. Buscar expediente");
                Console.WriteLine("3. Ordenar expedientes");
                Console.WriteLine("4. Derivar y actualizar estado");
                Console.WriteLine("5. Mostrar reporte");
                Console.WriteLine("0. Salir");

                Console.WriteLine("=========================================");
                Console.Write("Seleccione una opcion: ");

                string entrada = Console.ReadLine() ?? "";

                if (int.TryParse(entrada, out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Registro de expediente");
                            break;

                        case 2:
                            Console.WriteLine("Busqueda de expediente");
                            break;

                        case 3:
                            Console.WriteLine("Ordenamiento de expedientes");
                            break;

                        case 4:
                            Console.WriteLine("Derivacion y actualizacion");
                            break;

                        case 5:
                            Console.WriteLine("Reporte de expedientes");
                            break;

                        case 0:
                            Console.WriteLine("Saliendo del sistema...");
                            break;

                        default:
                            Console.WriteLine("Opcion no valida.");
                            break;
                    }
                }
                else
                {
                    opcion = -1;
                    Console.WriteLine("Ingrese un numero valido.");
                }

                Console.WriteLine();

            } while (opcion != 0);
        }
    }
}
