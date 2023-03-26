namespace VideoTienda;

public class Factura
{
    private int _idFactura;
    private DateTime _fechaGenerada;
    private DateTime _horaGenerada;
    private double _subTotal;
    private double _ivaMonto;
    private double _total;

    private List<Factura> facturas;

    public Factura()
    {
        facturas = new List<Factura>();

        facturas.Add(new Factura(1, DateTime.Now, DateTime.Now, 12.000, 0.18, ((0.18 * 12.000) + 12.000)));
        facturas.Add(new Factura(2, DateTime.Now, DateTime.Now, 15.000, 0.18, ((0.18 * 15.000) + 15.000)));
    }

    public Factura(int idFactura, DateTime fechaGenerdada, DateTime horaGenerada, double subTotal, double ivaMonto,
        double total)
    {
        _idFactura = idFactura;
        _fechaGenerada = fechaGenerdada;
        _horaGenerada = horaGenerada;
        _subTotal = subTotal;
        _ivaMonto = ivaMonto;
        _total = total;
    }

    public int IdFactura
    {
        get => _idFactura;
        set => _idFactura = value;
    }

    public DateTime FechaGenerada
    {
        get => _fechaGenerada;
        set => _fechaGenerada = value;
    }

    public DateTime HoraGenerada
    {
        get => _horaGenerada;
        set => _horaGenerada = value;
    }

    public double SubTotal
    {
        get => _subTotal;
        set => _subTotal = value;
    }

    public double IvaMonto
    {
        get => _ivaMonto;
        set => _ivaMonto = value;
    }

    public double Total
    {
        get => _total;
        set => _total = value;
    }

    override
        public String ToString()
    {
        return "Factura: [" +
               " ID: " + IdFactura +
               " Fecha Generada: " + FechaGenerada +
               " Hora Generada: " + HoraGenerada +
               " Sub Total: " + SubTotal +
               " Iva: " + IvaMonto +
               " Total: " + Total +
               "]\n";
    }

    public Factura BuscarFactura(int id)
    {
        Factura buscada = null;
        bool encontrado = false;
        for (int i = 0; i < facturas.Count && encontrado == false; i++)
        {
            if (facturas[i].IdFactura == id)
            {
                buscada = facturas[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    public void CrearFactura(int id, DateTime fecha, DateTime hora, double subtotal, double iva, double total)
    {
        Factura buscada = BuscarFactura(id);
        if (buscada == null)
        {
            Factura nueva = new Factura(id, fecha, hora, subtotal, iva, total);
            facturas.Add(nueva);
            Console.Write("\nSe Creo una nueva Factura.\n");
        }
        else
        {
            Console.Write("\nLa factura ya existe, no se puede duplicar.\n");
        }
    }

    public void ConsultarFacturas()
    {
        for (int i = 0; i < facturas.Count; i++)
        {
            Console.Write("\n" + facturas[i]);
        }
    }

    public void ConsultarUnaFactura(int id)
    {
        bool encontrado = false;
        for (int i = 0; i < facturas.Count && encontrado == false; i++)
        {
            if (facturas[i].IdFactura == id)
            {
                Console.WriteLine(facturas[i] + " ");
                encontrado = true;
            }
        }
    }

    public void ModificarFactura(int idFact, double subtotal, double iva, double total)
    {
        foreach (var factura in facturas)
        {
            Factura buscado = BuscarFactura(idFact);
            if (buscado != null)
            {
                factura.SubTotal = subtotal;
                factura.IvaMonto = iva;
                factura.Total = total;

                Console.Write("\nSe modifica el ID: " + idFact + " de la factura correctamente.\n");
            }
        }
    }

    public void EliminarFactura(int id)
    {
        Factura buscada = BuscarFactura(id);
        if (buscada != null)
        {
            facturas.Remove(buscada);
        }
        else
        {
            Console.Write("La Factura buscada no existe.\n");
        }
    }

    public void OperacionesFactura()
    {
        Boolean isSalirF = true;

        while (isSalirF)
        {
            Console.Write("#####---######--> Menu Principal Facturas <-- #####---######");
            Console.Write("\n1.Listar Totas las Facturas.");
            Console.Write("\n2.Buscar Factura");
            Console.Write("\n3.Agregar Factura.");
            Console.Write("\n4.Eliminar Factura.");
            Console.Write("\n5.Modificar Factura.");
            Console.Write("\n6.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionF = Int32.Parse(Console.ReadLine());

            switch (opcionF)
            {
                case 1:
                {
                    Console.WriteLine("\n#####---######--> Lista Todas las Facturas <--#####---######.");
                    ConsultarFacturas();
                    Console.WriteLine("");
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("\n#####---######--> Lista Una Factura en Especifico <--#####---######.");
                    Console.Write("Ingrese el ID de Factura a Buscar: ");
                    int idFact = Int32.Parse(Console.ReadLine());
                    if (BuscarFactura(idFact) == null)
                    {
                        Console.WriteLine("El " + idFact + " ingresado no se encuentra ");
                        break;
                    }
                    ConsultarUnaFactura(idFact);
                    break;
                }
                case 3:
                {
                    Console.WriteLine("\n.#####---######--> Crear Una Nueva Factura <--#####---######.");
                    Console.Write("\nIngrese el ID a Crear: ");
                    int idFact = Int32.Parse(Console.ReadLine());

                    Factura bascado = BuscarFactura(idFact);

                    if (bascado != null)
                    {
                        Console.WriteLine("\nLa Factura ya exite en la lista. \nNo se puede Crear.");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("\nIngrese el SubTotal: ");
                    double subtotal = Double.Parse(Console.ReadLine());
                    Console.Write("\nIngrese el Iva: ");
                    double iva = Double.Parse(Console.ReadLine());
                    double total = (subtotal * iva) + subtotal;
                    
                    CrearFactura(idFact, DateTime.Now, DateTime.Now, subtotal, iva, total);
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("\n#####---######--> Eliminar Una Factura en Especifico <--#####---######.");
                    Console.Write("Ingrese el ID de Factura a Eliminar: ");
                    int idFact = Int32.Parse(Console.ReadLine());
                    if (BuscarFactura(idFact) == null)
                    {
                        Console.WriteLine("El " + idFact + " ingresado no se encuetra ");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        EliminarFactura(idFact);
                        Console.WriteLine("La Factura se elimino correctamente.");
                        Console.ReadKey();
                        break;
                    }
                    break;
                }
                case 5:
                {
                    Console.WriteLine("\n.#####---######--> Modificar Factura <--#####---######.\n");
                    Console.Write("\nIngrese el ID del Factura a Modificar: ");
                    int idFact = Int32.Parse(Console.ReadLine());

                    Factura bascado = BuscarFactura(idFact);

                    if (bascado != null)
                    {
                        Console.WriteLine("\nLa Factura esta en la lista \nPor favor ingrese los datos a modificar.\n");
                        
                        Console.Write("\nIngrese el Nuevo SubTotal: ");
                        double subtotal = Double.Parse(Console.ReadLine());
                        Console.Write("\nIngrese el Nuevo Iva: ");
                        double iva = Double.Parse(Console.ReadLine());
                        double total = (subtotal * iva) + subtotal;
                    
                        ModificarFactura(idFact, subtotal, iva, total);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine(
                            "La Factura no esta en  la lista.\n No podemos modificar su valor.\n");
                        break;
                    }
                    break;
                }
                case 6:
                {
                    Console.Write("Saliste del Menu Factura Correctamente.\n");
                    isSalirF = false;
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