
using System;

namespace MesaDePartes
{
    internal class Program
    {

        static bool ValidarRUC(string ruc)
        {
            if (ruc.Length != 11)
            {
                Console.WriteLine("Error: El RUC debe tener 11 digitos.");
                return false;
            }
            for (int i = 0; i < ruc.Length; i++)
            {
                if (ruc[i] < '0' || ruc[i] > '9')
                {
                    Console.WriteLine("Error: El RUC solo debe contener numeros.");
                    return false;
                }
            }
            if (!ruc.StartsWith("10") && !ruc.StartsWith("20"))
            {
                Console.WriteLine("Error: El RUC debe comenzar con 10 o 20.");
                return false;
            }
            // Calculamos el digito verificador
            int[] pesos = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;
            for (int i = 0; i < 10; i++)
            {
                int numero = ruc[i] - '0';
                suma = suma + numero * pesos[i];
            }
            int resto = suma % 11;
            int digito = 11 - resto;
            if (digito == 10)
            {
                digito = 0;
            }
            else if (digito == 11)
            {
                digito = 1;
            }
            int ultimoDigito = ruc[10] - '0';
            if (digito != ultimoDigito)
            {
                Console.WriteLine("Error: El RUC tiene un digito verificador incorrecto.");
                return false;
            }
            return true;
        }
        static void RegistrarExpediente()
        {
            Console.WriteLine("================================");
            Console.WriteLine("     REGISTRO DE EXPEDIENTE");
            Console.WriteLine("================================");


            string ruc = "";
            bool rucValido = false;

            do
            {
                Console.Write("Ingrese RUC: ");
                ruc = Console.ReadLine() ?? "";

                rucValido = ValidarRUC(ruc);

                if (rucValido == false)
                {
                    Console.WriteLine("Intente nuevamente.");
                }

            } while (rucValido == false);

            Console.WriteLine("RUC validado correctamente.");


            Console.Write("Ingrese razon social: ");
            string razonSocial = Console.ReadLine() ?? "";

            Console.Write("Ingrese tipo de documento: ");
            string tipoDocumento = Console.ReadLine() ?? "";

            Console.Write("Ingrese asunto: ");
            string asunto = Console.ReadLine() ?? "";

            Console.Write("Ingrese area de destino: ");
            string areaDestino = Console.ReadLine() ?? "";

            Console.Write("Ingrese numero de folios: ");
            string folios = Console.ReadLine() ?? "";

            Console.Write("Ingrese contacto: ");
            string contacto = Console.ReadLine() ?? "";

            Console.Write("Ingrese prioridad: ");
            string prioridad = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine("Datos ingresados correctamente.");
            Console.WriteLine("Pendiente: validar y guardar expediente.");
        }

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
                            RegistrarExpediente();
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
