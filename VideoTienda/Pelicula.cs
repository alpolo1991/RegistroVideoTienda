namespace VideoTienda;

public class Pelicula
{
    private int _idPelicula;
    private String _nombrePelicula;
    private bool _estadoPelicula;
    private String _duracionPelicula;
    private String _sinopsisPelicula;
    private String _directorPelicula;
    private String _resenaPelicula;

    public Pelicula(int idPelicula, string nombrePelicula, bool estadoPelicula, string duracionPelicula,
        string sinopsisPelicula, string directorPelicula, string resenaPelicula)
    {
        _idPelicula = idPelicula;
        _nombrePelicula = nombrePelicula;
        _estadoPelicula = estadoPelicula;
        _duracionPelicula = duracionPelicula;
        _sinopsisPelicula = sinopsisPelicula;
        _directorPelicula = directorPelicula;
        _resenaPelicula = resenaPelicula;
    }

    private List<Pelicula> peliculas;
    
    private Alquiler objAlquiler = new Alquiler();

    public Pelicula()
    {
        peliculas = new List<Pelicula>();

        peliculas.Add(new Pelicula(1, "Brokeback Mountain", true, "120 Min", "Amor, Terror, Poesia", "Ang Lee",
            "Muy buen pelicula, enfocada a el amor en medio de la crisis y senofobia"));
        peliculas.Add(new Pelicula(2, "Origen (2010)", true, "160 Min", "Terror, Poesia, Fantasia", "Christopher Nolan",
            "Muy entretenida"));
        peliculas.Add(new Pelicula(3, "Masacre: Ven y mira (1985)", true, "150 Min", "Guerra", "Elem Klimov",
            "Muestra una época donde los niños son masacrados, buena historia"));
        peliculas.Add(new Pelicula(4, "¡Olvídate de mí! (2004)", false, "130 Min", "Amor", "Michel Gondry",
            "Porque, aunque su éxito la ha convertido en casi un cliché hipster, lo cierto es que es una excelente película sobre el amor."));
    }

    public int IdPelicula
    {
        get => _idPelicula;
        set => _idPelicula = value;
    }

    public string NombrePelicula
    {
        get => _nombrePelicula;
        set => _nombrePelicula = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Boolean EstadoPelicula
    {
        get => _estadoPelicula;
        set => _estadoPelicula = value;
    }

    public string DuracionPelicula
    {
        get => _duracionPelicula;
        set => _duracionPelicula = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string SinopsisPelicula
    {
        get => _sinopsisPelicula;
        set => _sinopsisPelicula = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DirectorPelicula
    {
        get => _directorPelicula;
        set => _directorPelicula = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ResenaPelicula
    {
        get => _resenaPelicula;
        set => _resenaPelicula = value ?? throw new ArgumentNullException(nameof(value));
    }

    override
        public String ToString()
    {
        return "Pelicula: [" +
               " ID: " + IdPelicula +
               " Nombre Pelicula: " + NombrePelicula +
               " Estado Pelicula: " + EstadoPelicula +
               " Resena Pelicula: " + ResenaPelicula +
               " Duracion Pelicula: " + DuracionPelicula +
               " Sinopsis Pelicula: " + SinopsisPelicula +
               " Director Pelicula: " + DirectorPelicula +
               "]\n";
    }

    // Metódos

    public Pelicula BuscarPelicula(int id)
    {
        Pelicula buscada = null;
        bool encontrado = false;
        for (int i = 0; i < peliculas.Count && encontrado == false; i++)
        {
            if (peliculas[i].IdPelicula == id)
            {
                buscada = peliculas[i];
                encontrado = true;
            }
        }
        return buscada;
    }

    public void ConsultarPeliculas()
    {
        for (int i = 0; i < peliculas.Count; i++)
        {
            Console.Write("\n" + peliculas[i]);
        }
    }

    public void ConsultarUnaPelicula(int id)
    {
        bool encontrado = false;
        for (int i = 0; i < peliculas.Count && encontrado == false; i++)
        {
            if (peliculas[i].IdPelicula == id)
            {
                Console.WriteLine(peliculas[i] + " ");
                encontrado = true;
            }
        }
    }

    public void EliminarPelicula(int id)
    {
        Pelicula buscada = BuscarPelicula(id);
        if (buscada != null)
        {
            peliculas.Remove(buscada);
        }
        else
        {
            Console.WriteLine("La Pelicula no existe.\n");
        }
    }

    public void EditarPelicula(int idPeli, string nombrePelicula, bool estadoPelicula, string duracionPelicula,
        string sinopsisPelicula, string directorPelicula, string resenaPelicula)
    {
        foreach (var pelicula in peliculas)
        {
            if (pelicula.IdPelicula == idPeli)
            {
                pelicula.NombrePelicula = nombrePelicula;
                pelicula.EstadoPelicula = estadoPelicula;
                pelicula.DuracionPelicula = duracionPelicula;
                pelicula.SinopsisPelicula = sinopsisPelicula;
                pelicula.DirectorPelicula = directorPelicula;
                pelicula.ResenaPelicula = resenaPelicula;

                Console.WriteLine("\nSe modifica el ID: " + idPeli + " de la pelicula correctamente.\n");
            }
        }
    }

    public bool is_estado(int estado)
    {
        bool isEstado = false;
        if (estado == 1)
        {
            isEstado = true;
        }
        else
        {
            isEstado = false;
        }

        return isEstado;
    }

    public void AgregarPelicula(int idPeli, string nombrePelicula, bool estadoPelicula, string duracionPelicula,
        string sinopsisPelicula, string directorPelicula, string resenaPelicula)
    {
        Pelicula buscada = BuscarPelicula(idPeli);
        if (buscada == null)
        {
            Pelicula nueva = new Pelicula(idPeli, nombrePelicula, estadoPelicula, duracionPelicula, sinopsisPelicula,
                directorPelicula, resenaPelicula);
            peliculas.Add(nueva);
            Console.WriteLine("\nSe Agrego la Nueva Pelicula Correctamente.\n");
        }
        else
        {
            Console.WriteLine("\nLa Pelicula con ese ID ya existe, no se puede duplicar.\n");
        }
    }

    public void AgregarResena(int idPeli, String resenaPelicula)
    {
        foreach (var pelicula in peliculas)
        {
            //Pelicula buscado = BuscarPelicula(idPeli);
            if (pelicula.IdPelicula == idPeli)
            {
                pelicula.ResenaPelicula = resenaPelicula;

                Console.WriteLine("\nSe modifica el ID: " + idPeli + " de la pelicula correctamente.\n");
                Console.WriteLine("\nSe Modifica Reseña de la pelicula correctamente.\n");
            }
        }
    }

    public void AgregarEstado(int idPeli, bool estadoPelicula)
    {
        foreach (var pelicula in peliculas)
        {
            //Pelicula buscado = BuscarPelicula(idPeli);
            if (pelicula.IdPelicula == idPeli)
            {
                pelicula.EstadoPelicula = estadoPelicula;

                Console.WriteLine("\nSe modifica el ID: " + idPeli + " de la pelicula correctamente.\n");
                Console.WriteLine("\nSe Modifica Estado de la pelicula correctamente.\n");
                break;
            }
        }
    }
    
    public void TituloDuracion(int idPeli)
    {
        foreach (var pelicula in peliculas)
        {
            //Pelicula buscado = BuscarPelicula(idPeli);
            if (pelicula.IdPelicula == idPeli)
            {
                Console.WriteLine("##------## Titulo Pelicula: "+pelicula.NombrePelicula);
                Console.WriteLine("##------## Duració Pelicula: "+pelicula.DuracionPelicula);
            }
        }
    }

    public void ConsultarEstado(int idPeli)
    {
        bool encontrado = false;
        for (int i = 0; i < peliculas.Count && encontrado == false; i++)
        {
            if (peliculas[i].IdPelicula == idPeli)
            {
                //Console.WriteLine(peliculas[i].EstadoPelicula + " ");
                if (peliculas[i].EstadoPelicula)
                {
                    Console.WriteLine("Disponible");
                }
                else
                {
                    Console.WriteLine("No Disponible");
                }
                encontrado = true;
            }
        }
    }
    
    public void FacturarPelicula()
    {
        Usuario objUsuario = new Usuario();
        
        Console.WriteLine("--###-- Peliculas Disponibles. --###--");
        ConsultarPeliculas();
        Console.WriteLine("--###-- Fin Peliculas Disponibles. --###--");
        
        int cantidadP = 0;

        Console.Write("Selecione el ID del Usuario->: ");
        int idUser = Int32.Parse(Console.ReadLine());
        
        bool IsFac = true;
        while (IsFac)
        {
            Console.Write("Selecione el ID de Pelicula a Alquilar->: ");
            int idPeliSel = Int32.Parse(Console.ReadLine());

            Console.WriteLine("--###-- Peliculas Seleccionada. --###--");
            ConsultarUnaPelicula(idPeliSel);

            Console.Write("¿Deseas agregar Alquilar otra Pelicula.? S/N -> ");
            String opcionFactPelOtra = Console.ReadLine();

            cantidadP++;

            if (opcionFactPelOtra.ToUpper() == "N")
            {
                
                Console.Write("Ingrese el Sub Total -> ");
                double stotal = Double.Parse(Console.ReadLine());
                double iva = 0.19;
                double total = ((stotal * iva) + stotal);

                Console.WriteLine("##------##---------------------------------------##-----##");
                Console.WriteLine("##------##---------------Resumen Factura---------##-----##");
                objUsuario.ConsultarUnUsuario(idUser);
                Console.WriteLine("##------##------------*******************--------##-----##");
                Console.WriteLine("##------## Cantidad Pelicula: "+ cantidadP);
                for (int i = 1; i <= cantidadP; i++)
                {
                    TituloDuracion(i);
                }
                Console.WriteLine("##------##------------*******************--------##-----##");
                Console.WriteLine("##------## Sub Total: "+ stotal);
                Console.WriteLine("##------## Iva: "+ iva +" (19%)");
                Console.WriteLine("##------## Total: "+ total);
                Console.WriteLine("##------##---------------------------------------##-----##");
                Console.WriteLine("");
                
                Console.Write("\n1.Salir-> ");
                int opcionFactPel = Int32.Parse(Console.ReadLine());
                if (opcionFactPel == 1)
                {
                    Console.WriteLine("Saliste del Modulo Factura Correctamente. ):");
                    IsFac = false;
                }
            }
        }
    }


    public void OperacionesPelicula()
    {
        Boolean isSalirPeli = true;

        while (isSalirPeli)
        {
            Console.Write("#####---######--> Menu Principal Peliculas <-- #####---######");
            Console.Write("\n1.Listar Totas las Peliculas.");
            Console.Write("\n2.Buscar Pelicula");
            Console.Write("\n3.Agregar Pelicula.");
            Console.Write("\n4.Eliminar Pelicula.");
            Console.Write("\n5.Modificar Pelicula.");
            Console.Write("\n6.Agregar Nueva Reseña Pelicula.");
            Console.Write("\n7.Agregar Nueva Estado Pelicula.");
            Console.Write("\n8.Consultar Estado Pelicula.");
            Console.Write("\n9.Ir Menu Alquiler.");
            Console.Write("\n10.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionPeli = Int32.Parse(Console.ReadLine());

            switch (opcionPeli)
            {
                case 1:
                {
                    Console.WriteLine("\n#####---######--> Lista Todas las Peliculas <--#####---######.");
                    ConsultarPeliculas();
                    Console.WriteLine("");
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("\n#####---######--> Lista Una Pelicula en Especifico <--#####---######.");
                    Console.Write("Ingrese el ID de Pelicula a Buscar: ");
                    int idPeli = Int32.Parse(Console.ReadLine());
                    if (BuscarPelicula(idPeli) == null)
                    {
                        Console.WriteLine("El " + idPeli + " ingresado no se encuentra ");
                        break;
                    }

                    ConsultarUnaPelicula(idPeli);
                    break;
                }
                case 3:
                {
                    Console.WriteLine("\n.#####---######--> Agregar Una Nueva Pelicula <--#####---######.");
                    Console.Write("\nIngrese el ID a Agregar: ");
                    int idPeli = Int32.Parse(Console.ReadLine());

                    Pelicula bascado = BuscarPelicula(idPeli);

                    if (bascado != null)
                    {
                        Console.WriteLine("\nLa Pelicula ya exite en la lista. \nNo se puede Crear.");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("\nIngrese el Nombre de la Pelicula->: ");
                    String nombrePelicula = Console.ReadLine();
                    Console.Write("\nIngrese el Estado de la Pelicula 1-> Disponible -- 2->No Disponibles->: ");
                    int estadoPelicula = Int32.Parse(Console.ReadLine());
                    bool estadoPeliculaB = is_estado(estadoPelicula);

                    Console.Write("\nIngrese la Duracción de la Pelicula: Ejm-> 120 min ->: ");
                    String duracionPelicula = Console.ReadLine();
                    Console.Write("\nIngrese la Sinopsis de la Pelicula ->: ");
                    String sinopsisPelicula = Console.ReadLine();
                    Console.Write("\nIngrese el Nombre del Director de la Pelicula ->: ");
                    String directorPelicula = Console.ReadLine();
                    Console.Write("\nIngrese el Una Reseña si lo desea de la Pelicula ->: ");
                    String resenaPelicula = Console.ReadLine();

                    AgregarPelicula(idPeli, nombrePelicula, estadoPeliculaB, duracionPelicula, sinopsisPelicula,
                        directorPelicula, resenaPelicula);
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("\n#####---######--> Eliminar Una Pelicula en Especifico <--#####---######.");
                    Console.Write("Ingrese el ID de Pelicula a Eliminar->: ");
                    int idPeli = Int32.Parse(Console.ReadLine());
                    if (BuscarPelicula(idPeli) == null)
                    {
                        Console.WriteLine("El " + idPeli + " ingresado no se encuetra ");
                        Console.ReadKey();
                        break;
                    }

                    EliminarPelicula(idPeli);
                    Console.WriteLine("Se Elimino la Pelicula correctamente.");
                    Console.ReadKey();
                    break;
                }
                case 5:
                {
                    Console.WriteLine("\n.#####---######--> Modificar Una Pelicula <--#####---######.");
                    Console.Write("\nIngrese el ID a Modificar: ");
                    int idPeli = Int32.Parse(Console.ReadLine());

                    Pelicula bascado = BuscarPelicula(idPeli);

                    if (bascado != null)
                    {
                        Console.WriteLine(
                            "\nLa Pelicula esta en la lista \nPor favor ingrese los datos a modificar.\n");
                    }
                    else
                    {
                        Console.WriteLine(
                            "La Pelicula no esta en  la lista.\n No podemos modificar su valor.\n");
                        break;
                    }
                    
                    Console.Write("\nIngrese el Nuevo Nombre de la Pelicula->: ");
                    String nombrePelicula = Console.ReadLine();
                    Console.Write(
                        "\nIngrese el Nuevo Estado de la Pelicula 1-> Disponible -- 2->No Disponibles->: ");
                    int estadoPeliculaB = Int32.Parse(Console.ReadLine());

                    bool estadoPelicula = is_estado(estadoPeliculaB);

                    Console.Write("\nIngrese la Nueva Duracción de la Pelicula: Ejm-> 120 min ->: ");
                    String duracionPelicula = Console.ReadLine();
                    Console.Write("\nIngrese el Nuevo Sinopsis de la Pelicula ->: ");
                    String sinopsisPelicula = Console.ReadLine();
                    Console.Write("\nIngrese el Nuevo Nombre del Director de la Pelicula ->: ");
                    String directorPelicula = Console.ReadLine();
                    Console.Write("\nIngrese el Una Nueva Reseña si lo desea de la Pelicula ->: ");
                    String resenaPelicula = Console.ReadLine();

                    EditarPelicula(idPeli, nombrePelicula, estadoPelicula, duracionPelicula, sinopsisPelicula,
                        directorPelicula, resenaPelicula);
                    Console.ReadKey();
                    break;
                }
                case 6:
                {
                    Console.WriteLine("\n.#####---######--> Agregar Nueva Reseña Pelicula <--#####---######.");
                    Console.Write("\nIngrese el ID de la Reseña a Modificar->: ");
                    int idPeli = Int32.Parse(Console.ReadLine());
                    Console.Write("\nIngrese la Nueva Reseña de la Pelicula->: ");
                    String resenaPelicula = Console.ReadLine();
                    AgregarResena(idPeli, resenaPelicula);
                    break;
                }
                case 7:
                {
                    Console.WriteLine("\n.#####---######--> Agregar Nuevo Estado a la Pelicula <--#####---######.");
                    Console.Write("\nIngrese el ID de la Pelicula Que Modificara el Estado->: ");
                    int idPeli = Int32.Parse(Console.ReadLine());
                    Console.Write("\nIngrese el Nuevo Estado de la Pelicula 1->Disponible -##- 2->No Disponibles->: ");
                    int estadoPeliculaB = Int32.Parse(Console.ReadLine());
                    bool estadoPelicula = is_estado(estadoPeliculaB);
                    
                    Pelicula bascado = BuscarPelicula(idPeli);

                    if (bascado != null)
                    {
                        AgregarEstado(idPeli, estadoPelicula);
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nEl ID Ingresado no Existe, no se puede modificar su estado.");
                        Console.ReadKey();
                        break;
                    }
                }
                case 8:
                {
                    Console.WriteLine("\n.#####---######--> Consular Estado de la Pelicula <--#####---######.");
                    Console.Write("\nIngrese el ID de la Pelicula a Consultar el Estado->: ");
                    int idPeli = Int32.Parse(Console.ReadLine());
                    ConsultarEstado(idPeli);
                    Console.ReadKey();
                    break;
                }
                case 9:
                {
                    objAlquiler.OperacionesAlquiler();
                    break;
                }
                case 10:
                {
                    Console.Write("Saliste del Menu Peliculas Correctamente.\n");
                    isSalirPeli = false;
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