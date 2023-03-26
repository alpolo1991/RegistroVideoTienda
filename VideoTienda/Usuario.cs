namespace VideoTienda;

public class Usuario
{
    private int _idUsuario;
    private String _nombres;
    private String _apellidos;
    private String _tipoIdentificacion;
    private int _numeroIdentificacion;
    private DateTime _fechaRegistro;
    private String _pais;
    private String _ciudad;
    private String _barrio;
    private String _direccion;
    private int _telefono;
    private int _codigoPostal;


    private List<Usuario> usuarios;

    public Usuario()
    {
        usuarios = new List<Usuario>();
        int nId = 1;
        usuarios.Add(new Usuario(nId++, "ALFONSO", "Gonzalez P", "CC", 12345678, DateTime.Now, "Colombia", "Soacha",
            "Ciudad Verde", "Cra 1 N 12-78", 3458596, 1101));
        usuarios.Add(new Usuario(nId++, "TATIANA", "Lopez P", "CC", 15236478, DateTime.Now, "Colombia", "Bogota",
            "San Martin", "Cra 5 N 57-82", 3478521, 1001));
    }

    public Usuario(int idUsuario, string nombres, string apellidos, string tipoIdentificacion, int numeroIdentificacion,
        DateTime fechaRegistro, string pais, string ciudad, string barrio, string direccion, int telefono,
        int codigoPostal)
    {
        _idUsuario = idUsuario;
        _nombres = nombres;
        _apellidos = apellidos;
        _tipoIdentificacion = tipoIdentificacion;
        _numeroIdentificacion = numeroIdentificacion;
        _fechaRegistro = fechaRegistro;
        _pais = pais;
        _ciudad = ciudad;
        _barrio = barrio;
        _direccion = direccion;
        _telefono = telefono;
        _codigoPostal = codigoPostal;
    }

    public int IdUsuario
    {
        get => _idUsuario;
        set => _idUsuario = value;
    }

    public string Nombres
    {
        get => _nombres;
        set => _nombres = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Apellidos
    {
        get => _apellidos;
        set => _apellidos = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string TipoIdentificacion
    {
        get => _tipoIdentificacion;
        set => _tipoIdentificacion = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int NumeroIdentificacion
    {
        get => _numeroIdentificacion;
        set => _numeroIdentificacion = value;
    }

    public DateTime FechaRegistro
    {
        get => _fechaRegistro;
        set => _fechaRegistro = value;
    }

    public string Pais
    {
        get => _pais;
        set => _pais = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Ciudad
    {
        get => _ciudad;
        set => _ciudad = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Barrio
    {
        get => _barrio;
        set => _barrio = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Direccion
    {
        get => _direccion;
        set => _direccion = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Telefono
    {
        get => _telefono;
        set => _telefono = value;
    }

    public int CodigoPostal
    {
        get => _codigoPostal;
        set => _codigoPostal = value;
    }

    override
        public String ToString()
    {
        return "Usuario: " + IdUsuario + " [" +
               " ID: " + IdUsuario +
               " Nombre: " + Nombres +
               " Apellidos: " + Apellidos +
               " Tipo Identificacion: " + TipoIdentificacion +
               " Número Identificación: " + NumeroIdentificacion +
               " Fecha Registro: " + FechaRegistro +
               " Pais: " + Pais +
               " Ciudad: " + Ciudad +
               " Barrio: " + Barrio +
               " Dirección: " + Direccion +
               " Telefono: " + Telefono +
               " Codigo Postal: " + CodigoPostal +
               "]\n";
    }

    public Usuario buscarUsuario(int id)
    {
        Usuario buscada = null;
        bool encontrado = false;
        for (int i = 0; i < usuarios.Count && encontrado == false; i++)
        {
            if (usuarios[i].IdUsuario == id)
            {
                buscada = usuarios[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    public Usuario IniciarSesion(String nombre, int identificacion)
    {
        bool encontrado = false;
        Usuario buscado = null;

        for (int i = 0; i < usuarios.Count && encontrado == false; i++)
        {
            if (usuarios[i].Nombres == nombre.ToUpper())
            {
                if (usuarios[i].NumeroIdentificacion == identificacion)
                {
                    Console.WriteLine("Inciaste Sesión Correctamente\n");
                    Console.WriteLine("Tus Datos Son:: \n\nNombre: " + nombre.ToUpper() + "\nIdentificacion: " +
                                      identificacion);
                    Console.WriteLine("\n");
                    //Console.WriteLine(usuarios[i]);
                    buscado = usuarios[i];
                    encontrado = true;
                    //break;
                }
                else
                {
                    Console.WriteLine("El número de indetificacion no se encuentrao o no existe");
                }
            }
            else
            {
                Console.WriteLine("El nombre ingresado no existe o no se encuentra registrado");
            }
        }

        return buscado;
    }


    public void RegistrarUsuario(int idUsuario, string nombres, string apellidos, string tipoIdentificacion,
        int numeroIdentificacion, DateTime fechaRegistro, string pais, string ciudad, string barrio, string direccion,
        int telefono, int codigoPostal)
    {
        Usuario buscada = buscarUsuario(idUsuario);
        if (buscada != null)
        {
            Usuario nuevo = new Usuario(idUsuario, nombres.ToUpper(), apellidos.ToUpper(), tipoIdentificacion,
                numeroIdentificacion, fechaRegistro, pais.ToUpper(), ciudad.ToUpper(), barrio.ToUpper(), direccion,
                telefono, codigoPostal);
            usuarios.Add(nuevo);
            Console.Write("\nSe agrego correctamente el nuevo usuario a la lista.");
            Console.ReadKey();
        }
        else
        {
            Console.Write("\nEl Usuario ya exite en la lista. \nNo se puede duplicar.");
            Console.ReadKey();
        }
    }

    public void ListarUsuarios()
    {
        for (int i = 0; i < usuarios.Count; i++)
        {
            Console.Write("\n" + usuarios[i]);
        }
    }


    public void ModificarUsuario(int idUsuario, string nombres, string apellidos, string tipoIdentificacion,
        int numeroIdentificacion, string pais, string ciudad, string barrio, string direccion, int telefono,
        int codigoPostal)
    {
        foreach (var usuario in usuarios)
        {
            Usuario buscado = buscarUsuario(idUsuario);
            if (buscado != null)
            {
                usuario.Nombres = nombres.ToUpper();
                usuario.Apellidos = apellidos.ToUpper();
                usuario.TipoIdentificacion = tipoIdentificacion;
                usuario.NumeroIdentificacion = numeroIdentificacion;
                usuario.Pais = pais.ToUpper();
                usuario.Ciudad = ciudad.ToUpper();
                usuario.Barrio = barrio.ToUpper();
                usuario.Direccion = direccion;
                usuario.Telefono = telefono;
                usuario.CodigoPostal = codigoPostal;

                Console.Write("\nSe modifica el "+ idUsuario +" del Usuario Correctamente.");
            }
        }
    }

    public void EliminarUsuario(int id)
    {
        Usuario buscada = buscarUsuario(id);
        if (buscada != null)
        {
            usuarios.Remove(buscada);
        }
        else
        {
            Console.Write("El Usuario no se encuentra en la lista para ser eliminada.");
        }
    }

    public void ConsultarUnUsuario(int id)
    {
        bool encontrado = false;
        for (int i = 0; i < usuarios.Count && encontrado == false; i++)
        {
            if (usuarios[i].IdUsuario == id)
            {
                Console.WriteLine("##------## ID Usuario: "+usuarios[i].IdUsuario);
                Console.WriteLine("##------## Username: "+usuarios[i].Nombres);
                Console.WriteLine("##------## Password: "+usuarios[i].NumeroIdentificacion);
                encontrado = true;
            }
        }
    }
    
    public void OperacionesUsuario()
    {
        Boolean isSalirU = true;

        while (isSalirU)
        {
            Console.Write("#####---######--> Menu Principal Usuario <-- #####---######");
            Console.Write("\n1.Listar Usuarios Registrados.");
            Console.Write("\n2.Buscar Usuario.");
            Console.Write("\n3.Agregar Usuario.");
            Console.Write("\n4.Eliminar Usuario.");
            Console.Write("\n5.Modificar Usuario.");
            Console.Write("\n6.Ir a Tienda");
            Console.Write("\n7.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionT = Int32.Parse(Console.ReadLine());

            switch (opcionT)
            {
                case 1:
                {
                    Console.Write("\n#####---######--> Lista Usuarios Registrados <--#####---######.");
                    ListarUsuarios();
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    Console.Write("\n#####---######--> Buscar Usuario <--#####---######.");
                    Console.Write("\nIngrese el ID del Usuario a Buscar: ");
                    int id = Int32.Parse(Console.ReadLine());
                    if (buscarUsuario(id) == null)
                    {
                        Console.WriteLine("El " + id + " ingresado no se encuetra ");
                        break;
                    }

                    Console.WriteLine(buscarUsuario(id));
                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                    Console.Write("\n.#####---######--> Crear Usuario <--#####---######.");
                    Console.Write("\nIngrese el ID del Usuario a Buscar: ");
                    int id = Int32.Parse(Console.ReadLine());

                    Usuario bascado = buscarUsuario(id);

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

                    RegistrarUsuario(id, nombres, apellidos, tipoIdentificacion, numeroIdentificacion,
                        DateTime.Now, pais, ciudad, barrio, direccion, telefono, codigoPostal);
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.Write("\n.#####---######--> Eliminar Usuario <--#####---######.");
                    Console.Write("\nIngrese el ID del Usuario a Eliminar: ");
                    int id = Int32.Parse(Console.ReadLine());

                    Usuario bascado = buscarUsuario(id);

                    if (bascado == null)
                    {
                        Console.WriteLine("El Usuario a Eliminar no fue econtrado.!");
                        Console.ReadKey();
                    }

                    EliminarUsuario(id);
                    Console.WriteLine("El Usuario se elimino correctamente");
                    Console.ReadKey();
                    break;
                }
                case 5:
                {
                    Console.Write("\n.#####---######--> Modificar Usuario <--#####---######.\n");
                    Console.Write("\nIngrese el ID del Usuario a Modificar: ");
                    int id = Int32.Parse(Console.ReadLine());

                    Usuario bascado = buscarUsuario(id);

                    if (bascado != null)
                    {
                        Console.Write("\nEl Usuario esta en la lista \nPor favor ingrese los datos a modificar.\n");
                    }
                    else
                    {
                        Console.WriteLine(
                            "El Usuario no esta en  la lista.\n No podemos modificar su valor ya que no existe");
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


                    ModificarUsuario(id, nombres, apellidos, tipoIdentificacion, numeroIdentificacion, pais,
                        ciudad, barrio, direccion, telefono, codigoPostal);

                    Console.ReadKey();
                    break;
                }
                case 6:
                {
                    Console.Write("\n.#####---######--> Menu Tienda <--#####---######.\n");

                    Tienda objTienda = new Tienda();
                    objTienda.OperacionesTienda();
                    Console.ReadKey();
                    break;
                }
                case 7:
                {
                    Console.Write("Cerraste Sesión Correctamente.");
                    isSalirU = false;
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