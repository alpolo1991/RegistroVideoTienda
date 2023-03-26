namespace VideoTienda;

using System;

public class Tienda
{
    private int idTienda;
    private String nombreTienda;
    private String pais;
    private String ciudad;
    private String barrio;
    private String direccion;
    private int telefono;

    private Usuario objUsuario = new Usuario();
    private Factura objFactura = new Factura();
    private Pelicula objPelicula = new Pelicula();

    private List<Tienda> tiendas;

    public Tienda()
    {
        tiendas = new List<Tienda>();

        int idTi = 1;
        tiendas.Add((new Tienda(idTi++, "Tu amigo el Tendero", "Colombia", "Bogota DC", "San Pablo", "Cra 78 N 98-23",
            98745632)));
    }

    public Tienda(int idTienda, string nombreTienda, string pais, string ciudad, string barrio, string direccion,
        int telefono)
    {
        this.idTienda = idTienda;
        this.nombreTienda = nombreTienda;
        this.pais = pais;
        this.ciudad = ciudad;
        this.barrio = barrio;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public int IdTienda
    {
        get => idTienda;
        set => idTienda = value;
    }

    public string NombreTienda
    {
        get => nombreTienda;
        set => nombreTienda = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Pais
    {
        get => pais;
        set => pais = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Ciudad
    {
        get => ciudad;
        set => ciudad = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Barrio
    {
        get => barrio;
        set => barrio = value ?? throw new ArgumentNullException(nameof(value));
    }

    public String Direccion
    {
        get => direccion;
        set => direccion = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Telefono
    {
        get => telefono;
        set => telefono = value;
    }

    override
        public String ToString()
    {
        return "Tienda: [" +
               " ID: " + IdTienda +
               " Nombre: " + NombreTienda +
               " Pais: " + Pais +
               " Ciudad: " + Ciudad +
               " Barrio: " + Barrio +
               " Dirección: " + Direccion +
               " Telefono: " + Telefono +
               "]\n";
    }

    public void IniciarSesion(String nombreB, int identificacion)
    {
        Usuario buscado = objUsuario.IniciarSesion(nombreB.ToUpper(), identificacion);
        if (buscado != null)
        {
            OperacionesTienda();
        }
    }

    public Boolean CerrarSesion()
    {
        return false;
    }

    public void ModificarDatosTienda(int idTienda, string nombreTienda, string pais, string ciudad, string barrio,
        string direccion, int telefono)
    {
        foreach (var tienda in tiendas)
        {
            if (tienda.IdTienda == idTienda)
            {
                tienda.NombreTienda = nombreTienda;
                tienda.Pais = pais;
                tienda.Ciudad = ciudad;
                tienda.Barrio = barrio;
                tienda.Direccion = direccion;
                tienda.Telefono = telefono;

                Console.Write("\nSe modifica el IdTienda: " + tienda.IdTienda + " Correctamente.\n");
            }
        }
    }

    public void ListarTiendas()
    {
        for (int i = 0; i < tiendas.Count; i++)
        {
            Console.Write("\n" + tiendas[i]);
        }
    }

    public Tienda buscarTienda(int id)
    {
        Tienda buscada = null;
        bool encontrado = false;
        for (int i = 0; i < tiendas.Count && encontrado == false; i++)
        {
            if (tiendas[i].IdTienda == id)
            {
                buscada = tiendas[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    public void AgregarTienda(int idTienda, string nombreTienda, string pais, string ciudad, string barrio,
        string direccion, int telefono)
    {
        Tienda buscada = buscarTienda(idTienda);
        if (buscada == null)
        {
            Tienda nuevo = new Tienda(idTienda, nombreTienda, pais, ciudad, barrio, direccion, telefono);
            tiendas.Add(nuevo);
            Console.Write("\nSe agrego correctamente la nueva tienda.\n");
        }
        else
        {
            Console.WriteLine("El ID ingresado ya existe.\n");
        }
    }

    public void OperacionesTienda()
    {
        Boolean isSalirT = true;

        while (isSalirT)
        {
            Console.Write("#####---######--> Menu Principal Tienda <-- #####---######");
            Console.Write("\n1.Modificar Datos Tienda.");
            Console.Write("\n2.Agregar Nueva Tienda.");
            Console.Write("\n3.Listar Tiendas.");
            Console.Write("\n4.Ir a Menu Factura.");
            Console.Write("\n5.Ir a Menu Usuario.");
            Console.Write("\n6.Ir a Menu Pelicula.");
            Console.Write("\n7.Ir a Facturar Pelicula.");
            Console.Write("\n8.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionT = Int32.Parse(Console.ReadLine());

            switch (opcionT)
            {
                case 1:
                {
                    Console.Write("\n.#####---######--> Modificar Datos Tienda <--#####---######.\n");

                    Console.Write("\nIngrese el ID de la Tienda a Modificar: ");
                    int id = int.Parse(Console.ReadLine());

                    Tienda buscada = buscarTienda(id);
                    if (buscada != null)
                    {
                        Console.Write("\nIngrese el Nuevo Nombre de la Tienda: ");
                        String nombreTienda = Console.ReadLine();
                        Console.Write("\nIngrese el Nuevo Pais: ");
                        String pais = Console.ReadLine();
                        Console.Write("\nIngrese la Nueva Ciudad: ");
                        String ciudad = Console.ReadLine();
                        Console.Write("\nIngrese el Nuevo Barrio: ");
                        String barrio = Console.ReadLine();
                        Console.Write("\nIngrese la Nueva Dirección: ");
                        String direccion = Console.ReadLine();
                        Console.Write("\nIngrese el Nuevo Numero de Telefono: ");
                        Int32 telefono = Int32.Parse(Console.ReadLine());

                        ModificarDatosTienda(id, nombreTienda, pais, ciudad, barrio, direccion, telefono);
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("El ID ingreseda no exite.");
                        Console.ReadKey();
                        break;
                    }

                    break;
                }
                case 2:
                {
                    Console.Write("\n.#####---######--> Agregar Nueva Tienda <--#####---######.\n");

                    Console.Write("\nIngrese el ID de la Nueva Tienda: ");
                    int id = Int32.Parse(Console.ReadLine());

                    foreach (var tienda in tiendas)
                    {
                        if (tienda.IdTienda != id)
                        {
                            Console.Write("\nIngrese el Nombre de la Tienda: ");
                            String nombreTienda = Console.ReadLine();
                            Console.Write("\nIngrese el Pais: ");
                            String pais = Console.ReadLine();
                            Console.Write("\nIngrese la Ciudad: ");
                            String ciudad = Console.ReadLine();
                            Console.Write("\nIngrese el Barrio: ");
                            String barrio = Console.ReadLine();
                            Console.Write("\nIngrese la Dirección: ");
                            String direccion = Console.ReadLine();
                            Console.Write("\nIngrese el Numero de Telefono: ");
                            int telefonoT = Int32.Parse(Console.ReadLine());

                            AgregarTienda(id, nombreTienda, pais, ciudad, barrio, direccion, telefonoT);
                            Console.WriteLine("\n");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("El ID ingresado ya existe en la lista.");
                            Console.ReadKey();
                            break;
                        }
                    }

                    break;
                }
                case 3:
                {
                    ListarTiendas();
                    Console.WriteLine("\n");
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    //Factura objFactura = new Factura();
                    objFactura.OperacionesFactura();
                    break;
                }
                case 5:
                {
                    //Usuario objUsuario = new Usuario();
                    objUsuario.OperacionesUsuario();
                    break;
                }
                case 6:
                {
                    //Pelicula objPelicula = new Pelicula();
                    objPelicula.OperacionesPelicula();
                    break;
                }
                case 7:
                {
                    objPelicula.FacturarPelicula();
                    Console.ReadKey();
                    break;
                }
                case 8:
                {
                    Console.Write("Cerraste Sesión Correctamente.");
                    isSalirT = CerrarSesion();
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