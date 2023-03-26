// See https://aka.ms/new-console-template for more information

using System;

/*
 * Universidad Nacional Abierta y a Distancia (UNAD)
 * Escuela de Ciencias Básicas, Tecnología e Ingeniería – ECBTI
 * Programación (213023_137)
 * Autor: Alfonso Gonzalez Posso
 * Etapa 3 - Ejercicio 1
 *
 */

namespace VideoTienda // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tienda objTienda = new Tienda();
            Usuario objUsuario = new Usuario();

            Console.WriteLine("<---------#####################-------------->");
            Console.WriteLine("Usuarios con los que puedes iniciar sesión");
            objUsuario.ListarUsuarios();
            Console.WriteLine("Usuario->: Nombre");
            Console.WriteLine("Password->: NumeroIdentificacion");
            Console.WriteLine("<---------#####################-------------->\n");
            
            Boolean isSalirP = true;

            while (isSalirP)
            {
                Console.Write("#####---######--> Menu Principal - Global <-- #####---######");
                Console.Write("\n1.Iniciar Sesión.");
                Console.Write("\n2.Registrase.");
                Console.Write("\n3.Cerrar Sesión.");
                Console.Write("\n4.Salir de Programa: ");
                Console.Write("\n\nIngrese el numero de la opción deseada: ");
                int opcionP = Int32.Parse(Console.ReadLine());

                switch (opcionP)
                {
                    case 1:
                    {
                        Console.Write("\n#####---######--> Iniciar Sesión <--#####---######.\n");
                        Console.Write("\nIngrese el Nombre de la persona: ");
                        String nombre = Console.ReadLine();
                        Console.Write("\nIngrese el Numero Identificacion - Contraseña de la persona: ");
                        int numeroIdentificacion = Int32.Parse(Console.ReadLine());
                        objTienda.IniciarSesion(nombre.ToUpper(), numeroIdentificacion);
                        Console.ReadKey();
                        break;
                    }
                    case 2:
                    {
                        Console.Write("\n.#####---######--> Crear Usuario <--#####---######.");
                        Console.Write("\nIngrese el ID del Usuario a Buscar: ");
                        int id = Int32.Parse(Console.ReadLine());

                        Usuario bascado = objUsuario.buscarUsuario(id);

                        if (bascado != null)
                        {
                            Console.Write("\nEl Usuario ya exite en la lista. \nNo se puede duplicar.");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("\nIngrese el Nombre de la persona: ");
                        String nombres = Console.ReadLine();
                        Console.Write("\nIngrese el Apellidos de la persona: ");
                        String apellidos = Console.ReadLine();
                        Console.Write("\nIngrese el Tipo Identificacion de la persona: ");
                        String tipoIdentificacion = Console.ReadLine();
                        Console.Write("\nIngrese el Numero Identificacion de la persona: ");
                        int numeroIdentificacion = Int32.Parse(Console.ReadLine());
                        Console.Write("\nIngrese el Pais de la persona: ");
                        String pais = Console.ReadLine();
                        Console.Write("\nIngrese el Ciudad de la persona: ");
                        String ciudad = Console.ReadLine();
                        Console.Write("\nIngrese el Barrio de la persona: ");
                        String barrio = Console.ReadLine();
                        Console.Write("\nIngrese el Dirección de la persona: ");
                        String direccion = Console.ReadLine();
                        Console.Write("\nIngrese el Telefono de la persona: ");
                        int telefono = Int32.Parse(Console.ReadLine());
                        Console.Write("\nIngrese el Codigo Postal de la persona: ");
                        int codigoPostal = Int32.Parse(Console.ReadLine());

                        objUsuario.RegistrarUsuario(id, nombres, apellidos, tipoIdentificacion, numeroIdentificacion,
                            DateTime.Now, pais, ciudad, barrio, direccion, telefono, codigoPostal);
                        Console.ReadKey();
                        break;
                    }
                    case 3:
                    {
                        Console.Write("Cerraste Sesión Correctamente.");
                        Console.ReadKey();
                        break;
                    }
                    case 4:
                    {
                        Console.Write("Saliste del Programa Correctamente.");
                        isSalirP = objTienda.CerrarSesion();
                        Console.ReadKey();
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Ingresaste un valor incorrector.\nPor favor vuelve a validar.");
                        break;
                    }
                }
            }
        }
    }
}