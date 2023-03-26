namespace VideoTienda;

public class Alquiler
{
    private int _idAlquiler;
    private DateTime _fechaAlquiler;
    private DateTime _fechaEntrga;
    private String _direccionAlquiler;

    private List<Alquiler> alquilers;

    public Alquiler()
    {
        alquilers = new List<Alquiler>();

        alquilers.Add(new Alquiler(1, DateTime.Now, DateTime.UtcNow, "Cra 12 N 21-22 Sur"));
        alquilers.Add(new Alquiler(2, DateTime.Now, DateTime.UtcNow, "Cra 55 N 45-54 Sur"));
        alquilers.Add(new Alquiler(3, DateTime.Now, DateTime.UtcNow, "Calle 8 N 10-75 Sur"));
    }

    public Alquiler(int idAlquiler, DateTime fechaAlquiler, DateTime fechaEntrga, string direccionAlquiler)
    {
        _idAlquiler = idAlquiler;
        _fechaAlquiler = fechaAlquiler;
        _fechaEntrga = fechaEntrga;
        _direccionAlquiler = direccionAlquiler;
    }

    public int IdAlquiler
    {
        get => _idAlquiler;
        set => _idAlquiler = value;
    }

    public DateTime FechaAlquiler
    {
        get => _fechaAlquiler;
        set => _fechaAlquiler = value;
    }

    public DateTime FechaEntrega
    {
        get => _fechaEntrga;
        set => _fechaEntrga = value;
    }

    public string DireccionAlquiler
    {
        get => _direccionAlquiler;
        set => _direccionAlquiler = value ?? throw new ArgumentNullException(nameof(value));
    }

    override
        public String ToString()
    {
        return "Alquiler: [" +
               " ID: " + IdAlquiler +
               " Fecha Alquiler: " + FechaAlquiler +
               " Fecha Entrega: " + FechaEntrega +
               " DireccionAlquiler: " + DireccionAlquiler +
               "]\n";
    }

    public Alquiler BuscarAlquiler(int id)
    {
        Alquiler buscada = null;
        bool encontrado = false;
        for (int i = 0; i < alquilers.Count && encontrado == false; i++)
        {
            if (alquilers[i].IdAlquiler == id)
            {
                buscada = alquilers[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    public void ConsultarDisponibilidad()
    {
        Console.WriteLine("\n.#####---######--> Consular Estado de la Pelicula <--#####---######.");
        Console.Write("\nIngrese el ID de la Pelicula a Consultar el Estado->: ");
        int idPeli = Int32.Parse(Console.ReadLine());
        
        Pelicula objPelicula = new Pelicula();
        objPelicula.ConsultarEstado(idPeli);
    }

    public void ConsultarAlquiler()
    {
        Console.WriteLine("\n.#####---######--> Consular Alquiler de la Pelicula <--#####---######.");
        Console.Write("\nIngrese el ID de la Pelicula a Consultar el Estado->: ");
        int idPeli = Int32.Parse(Console.ReadLine());
        
        Pelicula objPelicula = new Pelicula();
        objPelicula.ConsultarEstado(idPeli);
    }

    public void EliminarAlquiler(int id)
    {
        Alquiler buscada = BuscarAlquiler(id);
        if (buscada != null)
        {
            alquilers.Remove(buscada);
        }
        else
        {
            Console.WriteLine("No esta alquilada no existe.\n");
        }
    }

    public void OperacionesAlquiler()
    {
        Boolean isSalirAlq = true;

        while (isSalirAlq)
        {
            Console.Write("#####---######--> Menu Principal Alquiler <-- #####---######");
            Console.Write("\n1.Consultar Alquiler.");
            Console.Write("\n2.Consultar Alquiler Disponible.");
            Console.Write("\n3.Eliminar Alquiler.");
            Console.Write("\n4.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionAlq = Int32.Parse(Console.ReadLine());

            switch (opcionAlq)
            {
                case 1:
                {
                    ConsultarAlquiler();
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    ConsultarDisponibilidad();
                    break;
                }
                case 3:
                {
                    Console.Write("Ingrese el ID de Alquiler a Eliminar->: ");
                    int idAlq = Int32.Parse(Console.ReadLine());
                    if (BuscarAlquiler(idAlq) == null)
                    {
                        Console.WriteLine("El " + idAlq + " ingresado no se encuetra ");
                        Console.ReadKey();
                        break;
                    }
                    EliminarAlquiler(idAlq);
                    Console.WriteLine("Se Elimino el Alquiler correctamente.");
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.Write("Saliste del Menu Peliculas Correctamente.\n");
                    isSalirAlq = false;
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