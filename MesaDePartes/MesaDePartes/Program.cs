using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaDePartes2
{
    internal class Program
    {
        //RUC VALIDO: 20100017491
        static List<string> rucs = new List<string>(), razones = new List<string>(), documentos = new List<string>(), asuntos = new List<string>(), areas = new List<string>(), contactos = new List<string>(), pendiente = new List<string>();
        static List<int> prioridades = new List<int>(), Cfolios = new List<int>();
        static List<DateTime> fechasRegistro = new List<DateTime>();

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
            for (int i = 0; i < rucs.Count; i++)
            {
                if (ruc == rucs[i])
                {
                    Console.WriteLine("Error: El RUC digitado ya existe en el registro.");
                    return false;
                }
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
                Console.Write("Ingrese RUC, si desea volver digite 0: ");
                ruc = Console.ReadLine() ?? "";
                if (ruc == "0")
                {
                    return;
                }

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

            Console.Write("Ingrese asunto [motivo del tramite]: ");
            string asunto = Console.ReadLine() ?? "";

            Console.Write("Ingrese area de destino: ");
            string areaDestino = Console.ReadLine() ?? "";

            Console.Write("Ingrese numero de folios [cantidad de hojas]: ");
            int folios;
            while (!int.TryParse(Console.ReadLine(), out folios) || folios <= 0)
                Console.Write("Error: Ingrese un numero de folios mayor que 0: ");

            Console.Write("Ingrese contacto [correo electronico o telefono]: ");
            string contacto = Console.ReadLine() ?? "";

            Console.Write("Ingrese prioridad [1 = Alta, 2 = Media, 3 = Baja]: ");
            int prioridad;
            while (!int.TryParse(Console.ReadLine(), out prioridad) || prioridad < 1 || prioridad > 3)
                Console.Write("Error: Seleccione 1 (Alta), 2 (Media) o 3 (Baja): ");

            Console.WriteLine("\nDatos ingresados correctamente.");
            rucs.Add(ruc);
            razones.Add(razonSocial);
            documentos.Add(tipoDocumento);
            asuntos.Add(asunto);
            areas.Add(areaDestino);
            Cfolios.Add(folios);
            contactos.Add(contacto);
            prioridades.Add(prioridad);
            pendiente.Add("PENDIENTE");
            fechasRegistro.Add(DateTime.Now);

            Console.WriteLine("Fecha y hora de registro: " +
                fechasRegistro[fechasRegistro.Count - 1].ToString("dd/MM/yyyy HH:mm:ss"));
        }
        static void BuscarExpedientes()
        {
            Console.WriteLine("================================");
            Console.WriteLine("        BUSCAR EXPEDIENTE");
            Console.WriteLine("================================");
            Console.WriteLine("Ingresa el número RUC: ");
            string ruc = Console.ReadLine() ?? "";
            bool hallado = false;
            int i = 0;
            for (i = 0; i < rucs.Count; i++)
            {
                if (ruc == rucs[i])
                {
                    hallado = true;
                    break;
                }
            }
            if (hallado == true)
            {
                Console.WriteLine("RUC encontrado.");
                Console.WriteLine("Fecha de registro: " + fechasRegistro[i].ToString("dd/MM/yyyy"));
                Console.WriteLine("Hora de registro: " +
                    fechasRegistro[i].ToString("HH:mm:ss"));
                Console.WriteLine($"\nRUC:\t[{rucs[i]}]\nRazón Social:\n{razones[i]}\n\nTipo de Documento: {documentos[i]}\nAsunto: {asuntos[i]}\nÁrea: {areas[i]}\nN. de Folios: {Cfolios[i]}\nContacto: {contactos[i]}\nPrioridad: {prioridades[i]}\nESTADO: {pendiente[i]}");

            }
            else Console.WriteLine("El RUC no existe en el registro.");
        }
        static void Mostrar()
        {
            Console.WriteLine("================================");
            Console.WriteLine("       MOSTRAR EXPEDIENTES");
            Console.WriteLine("================================");
            for (int i = 0; i < rucs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rucs[i]}");
            }
            return;
        }

        static void Editar()
        {
            Console.WriteLine("================================");
            Console.WriteLine("       EDITAR EXPEDIENTES");
            Console.WriteLine("================================");
            Console.WriteLine("Ingresa el número RUC: ");
            string ruc = Console.ReadLine() ?? "";
            bool hallado = false;
            int i = 0;
            for (i = 0; i < rucs.Count; i++)
            {
                if (ruc == rucs[i])
                {
                    hallado = true;
                    break;
                }
            }
            if (hallado == true)
            {
                bool bucle = true;
                do
                {
                    Console.WriteLine("RUC encontrado. ¿Qué desea modificar?");
                    Console.WriteLine($"\n[1]RUC:\t[{rucs[i]}]\n[2]Razón Social:\n{razones[i]}\n\n[3]Tipo de Documento:\t{documentos[i]}\n[4]Asunto:{asuntos[i]}\n[5]Área:{areas[i]}\n[6]N. de Folios:{Cfolios[i]}\n[7]Contacto:{contactos[i]}\n[8]Prioridad:{prioridades[i]}\n[9]Salir.\n");
                    int editor;
                    if (int.TryParse(Console.ReadLine(), out editor))
                    {
                        if ((editor > 0) && (editor < 9)) Console.WriteLine("Ingresa la nueva información:");
                        switch (editor)
                        {
                            case 1:
                                string nuevoRuc;
                                bool valido;
                                do
                                {
                                    Console.Write("Ingrese nuevo RUC [11 digitos]: ");
                                    nuevoRuc = Console.ReadLine() ?? "";
                                    valido = ValidarRUC(nuevoRuc);
                                    if (!valido)
                                        Console.WriteLine("ERROR: Ingrese un RUC valido.");
                                } while (!valido);
                                rucs[i] = nuevoRuc;
                                Console.WriteLine("RUC actualizado correctamente.");
                                break;
                            case 2:
                                string razonSocial;
                                do
                                {
                                    Console.Write("Ingrese nueva razon social [Nombre de la empresa]: ");
                                    razonSocial = Console.ReadLine() ?? "";

                                    if (string.IsNullOrWhiteSpace(razonSocial))
                                        Console.WriteLine("ERROR: La razon social no puede estar vacia.");
                                } while (string.IsNullOrWhiteSpace(razonSocial));
                                razones[i] = razonSocial.Trim();
                                Console.WriteLine("Razon social actualizada correctamente.");
                                break;
                            case 3:
                                string documento;
                                do
                                {
                                    Console.Write("Ingrese nuevo tipo de documento [Solicitud, Oficio, Carta, Memorando, Informe]: ");
                                    documento = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(documento))
                                        Console.WriteLine("ERROR: El tipo de documento no puede estar vacio.");
                                } while (string.IsNullOrWhiteSpace(documento));
                                documentos[i] = documento.Trim();
                                Console.WriteLine("Tipo de documento actualizado correctamente.");
                                break;
                            case 4:
                                string asunto;
                                do
                                {
                                    Console.Write("Ingrese nuevo asunto [Motivo del tramite]: ");
                                    asunto = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(asunto))
                                        Console.WriteLine("ERROR: El asunto no puede estar vacio.");
                                    else if (asunto.Trim().Length < 10)
                                        Console.WriteLine("ERROR: El asunto debe tener al menos 10 caracteres.");
                                } while (string.IsNullOrWhiteSpace(asunto) || asunto.Trim().Length < 10);
                                asuntos[i] = asunto.Trim();
                                Console.WriteLine("Asunto actualizado correctamente.");
                                break;
                            case 5:
                                string area;
                                do
                                {
                                    Console.Write("Ingrese nueva area de destino: ");
                                    area = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(area))
                                        Console.WriteLine("ERROR: El area no puede estar vacia.");
                                } while (string.IsNullOrWhiteSpace(area));
                                areas[i] = area.Trim();
                                Console.WriteLine("Area actualizada correctamente.");
                                break;
                            case 6:
                                int folio;
                                do
                                {
                                    Console.Write("Ingrese nuevo numero de folios: ");
                                    if (int.TryParse(Console.ReadLine(), out folio) && folio > 0)
                                        break;
                                    else
                                        Console.WriteLine("ERROR: Ingrese un numero entero mayor que 0.");
                                } while (true);
                                Cfolios[i] = folio;
                                Console.WriteLine("Numero de folios actualizado correctamente.");
                                break;
                            case 7:
                                string contacto;
                                do
                                {
                                    Console.Write("Ingrese nuevo contacto [Correo electronico o telefono]: ");
                                    contacto = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(contacto))
                                        Console.WriteLine("ERROR: El contacto no puede estar vacio.");
                                } while (string.IsNullOrWhiteSpace(contacto));
                                contactos[i] = contacto.Trim();
                                Console.WriteLine("Contacto actualizado correctamente.");
                                break;
                            case 8:
                                int prioridad;
                                do
                                {
                                    Console.Write("Ingrese nueva prioridad [1 = Alta, 2 = Media, 3 = Baja]: ");
                                    if (int.TryParse(Console.ReadLine(), out prioridad)
                                        && prioridad >= 1 && prioridad <= 3)
                                        break;
                                    else
                                        Console.WriteLine("ERROR: Ingrese una prioridad del 1 al 3.");
                                } while (true);
                                prioridades[i] = prioridad;
                                Console.WriteLine("Prioridad actualizada correctamente.");
                                break;
                            case 9:
                                Console.WriteLine("Presiona cualquier tecla para salir");
                                bucle = false;
                                break;
                            default:
                                Console.WriteLine("Opcion no valida.");
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido");
                        Console.Clear();
                    }
                } while (bucle == true);
            }
            else Console.WriteLine("RUC inválido");
        }

        static void Estado()
        {
            Console.WriteLine("================================");
            Console.WriteLine("      ESTADO DE EXPEDIENTES");
            Console.WriteLine("================================");
            Console.WriteLine("Ingresa el número RUC: ");
            string ruc = Console.ReadLine() ?? "";
            bool hallado = false;
            int i = 0;
            for (i = 0; i < rucs.Count; i++)
            {
                if (ruc == rucs[i])
                {
                    hallado = true;
                    break;
                }
            }
            if (hallado == true)
            {
                string eleccion;
                if (pendiente[i] == "PENDIENTE")
                {
                    Console.WriteLine("El caso se encuentra PENDIENTE.\n¿Desea derivarlo al área respectiva y colocarlo en proceso?\n[1] Si.\t[2] No.");
                    eleccion = Console.ReadLine() ?? "";
                    if (eleccion == "1")
                    {
                        pendiente[i] = "EN PROCESO";
                    }
                }
                else if (pendiente[i] == "EN PROCESO")
                {
                    Console.WriteLine("El caso se encuentra EN PROCESO.\n¿Desea actualizarlo como completado?\n[1] Si.\t[2] No.");
                    eleccion = Console.ReadLine() ?? "";
                    if (eleccion == "1")
                    {
                        pendiente[i] = "COMPLETADO";
                    }
                }
                else
                {
                    Console.WriteLine("Este RUC ya está completado... ¿Desea revertirlo?\n[1] Si.\t[2] No.");
                    eleccion = Console.ReadLine() ?? "";
                    if (eleccion == "1")
                    {
                        pendiente[i] = "PENDIENTE";
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("       SISTEMA DE MESA DE PARTES");
                Console.WriteLine("                 NOVINSA");
                Console.WriteLine("=========================================");

                Console.WriteLine("1. Registrar expediente");
                Console.WriteLine("2. Buscar expediente");
                Console.WriteLine("3. Editar expediente");
                Console.WriteLine("4. Derivar y actualizar estado");
                Console.WriteLine("5. Mostrar expendientes");
                Console.WriteLine("6. Salir");

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
                            BuscarExpedientes();
                            break;
                        case 3:
                            Editar();
                            break;
                        case 4:
                            Estado();
                            break;
                        case 5:
                            Mostrar();
                            break;
                        case 6:
                            Console.WriteLine("Presione cualquier tecla para continuar");
                            break;
                        default:
                            Console.WriteLine("Opcion no valida.");
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    opcion = 0;
                    Console.WriteLine("Ingrese un numero valido.");
                }
                Console.Clear();
                Console.WriteLine();
            } while (opcion != 6);

        }
    }
}

