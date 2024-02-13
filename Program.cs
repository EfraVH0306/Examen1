using System;

class Program
{
    static int[] numeroFactura = new int[15];
    static string[] numeroPlaca = new string[15];
    static DateTime[] fecha = new DateTime[15];
    static TimeSpan[] hora = new TimeSpan[15];
    static int[] tipoVehiculo = new int[15];
    static int[] numeroCaseta = new int[15];
    static int[] montoPagar = new int[15];
    static int[] pagaCon = new int[15];
    static int[] vuelto = new int[15];
    static int posicionActual = 0; 

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("Menú Principal del Sistema:");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehicular");
            Console.WriteLine("3. Consulta de vehículos por número de placa");
            Console.WriteLine("4. Modificar Datos Vehículos por número de placa");
            Console.WriteLine("5. Reporte Todos los Datos de los vectores");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    IngresarPasoVehicular();
                    break;
                case 3:
                    ConsultaPorNumeroPlaca();
                    break;
                case 4:
                    ModificarDatosPorNumeroPlaca();
                    break;
                case 5:
                    ReporteTodosLosDatos();
                    break;
                case 6:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                    break;
            }
        } while (opcion != 6);
    }

    static void InicializarVectores()
    {
        for (int i = 0; i < 15; i++)
        {
            numeroFactura[i] = 0;
            numeroPlaca[i] = "";
            fecha[i] = DateTime.MinValue;
            hora[i] = TimeSpan.MinValue;
            tipoVehiculo[i] = 0;
            numeroCaseta[i] = 0;
            montoPagar[i] = 0;
            pagaCon[i] = 0;
            vuelto[i] = 0;
        }
        posicionActual = 0;
        Console.WriteLine("Vectores inicializados correctamente.");
    }

    static void IngresarPasoVehicular()
    {
        if (posicionActual >= 15) 
        {
            Console.WriteLine("Error: No se pueden registrar más vehículos.");
            return;
        }

        Console.WriteLine("Ingresar Paso Vehicular");
        Console.Write("Número de factura: ");
        numeroFactura[posicionActual] = int.Parse(Console.ReadLine());
        Console.Write("Número de placa: ");
        numeroPlaca[posicionActual] = Console.ReadLine();
        Console.Write("Fecha (dd/mm/yyyy): ");
        fecha[posicionActual] = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Hora (horas): ");
        int horas = int.Parse(Console.ReadLine());
        Console.Write("Hora (minutos): ");
        int minutos = int.Parse(Console.ReadLine());
        hora[posicionActual] = new TimeSpan(horas, minutos, 0);

        Console.WriteLine("Tipo de vehículo:");
        Console.WriteLine("1. Moto");
        Console.WriteLine("2. Vehículo Liviano");
        Console.WriteLine("3. Camión o Pesado");
        Console.WriteLine("4. Autobús");
        Console.Write("Seleccione el tipo de vehículo (1-4): ");
        tipoVehiculo[posicionActual] = int.Parse(Console.ReadLine());
        Console.Write("Número de caseta (1-3): ");
        numeroCaseta[posicionActual] = int.Parse(Console.ReadLine());

        // Calcular monto a pagar según el tipo de vehículo
        switch (tipoVehiculo[posicionActual])
        {
            case 1:
                montoPagar[posicionActual] = 500; // Moto
                break;
            case 2:
                montoPagar[posicionActual] = 700; // Vehículo Liviano
                break;
            case 3:
                montoPagar[posicionActual] = 2700; // Camión
                break;
            case 4:
                montoPagar[posicionActual] = 3700; // Autobús
                break;
            default:
                Console.WriteLine("Tipo de vehículo inválido.");
                return;
        }

        Console.Write("Monto a pagar: " + montoPagar[posicionActual] + " colones\n");
        Console.Write("Paga con: ");
        pagaCon[posicionActual] = int.Parse(Console.ReadLine());
        vuelto[posicionActual] = pagaCon[posicionActual] - montoPagar[posicionActual];

        Console.WriteLine("Paso vehicular registrado correctamente.");
        posicionActual++; 
    }

    static void ConsultaPorNumeroPlaca()
    {
        Console.WriteLine(" ---------------------- Consulta de vehículos por número de placa ----------------------");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("| Nº Factura | Nº Placa  |    Fecha    |  Hora  | Tipo Vehículo | Nº Caseta | Monto a Pagar | Paga Con | Vuelto |");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        Console.Write("Ingrese el número de placa a consultar: ");
        string placaConsulta = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < posicionActual; i++)
        {
            if (numeroPlaca[i] == placaConsulta)
            {
                Console.WriteLine($"| {numeroFactura[i],10} | {numeroPlaca[i],10} | {fecha[i].ToString("dd/MM/yyyy"),12} | {hora[i].ToString(@"hh\:mm"),6} | {tipoVehiculo[i],13} | {numeroCaseta[i],10} | {montoPagar[i],14} | {pagaCon[i],9} | {vuelto[i],6} |");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Vehículo no encontrado.");
        }

        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
    }

    static void ModificarDatosPorNumeroPlaca()
    {
        Console.Write("Ingrese el número de placa del vehículo a modificar: ");
        string placaModificar = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < posicionActual; i++)
        {
            if (numeroPlaca[i] == placaModificar)
            {
                Console.WriteLine("Número de factura: " + numeroFactura[i]);
                Console.WriteLine("Número de placa: " + numeroPlaca[i]);
                Console.WriteLine("Fecha: " + fecha[i].ToString("dd/MM/yyyy"));
                Console.WriteLine("Hora: " + hora[i].ToString(@"hh\:mm"));
                Console.WriteLine("Tipo de vehículo: " + tipoVehiculo[i]);
                Console.WriteLine("Número de caseta: " + numeroCaseta[i]);
                Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                Console.WriteLine("Paga con: " + pagaCon[i]);
                Console.WriteLine("Vuelto: " + vuelto[i]);

                Console.WriteLine("\n¿Qué desea modificar?");
                Console.WriteLine("1. Número de factura");
                Console.WriteLine("2. Fecha");
                Console.WriteLine("3. Hora");
                Console.WriteLine("4. Tipo de vehículo");
                Console.WriteLine("5. Número de caseta");
                Console.WriteLine("6. Paga con");
                Console.WriteLine("7. Vuelto");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nuevo número de factura: ");
                        numeroFactura[i] = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Nueva fecha (dd/mm/yyyy): ");
                        fecha[i] = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        break;
                    case 3:
                        Console.Write("Nueva hora (horas): ");
                        int horas = int.Parse(Console.ReadLine());
                        Console.Write("Nueva hora (minutos): ");
                        int minutos = int.Parse(Console.ReadLine());
                        hora[i] = new TimeSpan(horas, minutos, 0);
                        break;
                    case 4:
                        Console.WriteLine("Nuevo tipo de vehículo:");
                        Console.WriteLine("1. Moto");
                        Console.WriteLine("2. Vehículo Liviano");
                        Console.WriteLine("3. Camión o Pesado");
                        Console.WriteLine("4. Autobús");
                        Console.Write("Seleccione el nuevo tipo de vehículo (1-4): ");
                        tipoVehiculo[i] = int.Parse(Console.ReadLine());
                        break;
                    case 5:
                        Console.Write("Nuevo número de caseta (1-3): ");
                        numeroCaseta[i] = int.Parse(Console.ReadLine());
                        break;
                    case 6:
                        Console.Write("Nuevo monto con que paga: ");
                        pagaCon[i] = int.Parse(Console.ReadLine());
                        vuelto[i] = pagaCon[i] - montoPagar[i];
                        break;
                    case 7:
                        Console.Write("Nuevo vuelto: ");
                        vuelto[i] = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Datos del vehículo modificados correctamente.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Vehículo no encontrado.");
        }
    }

    static void ReporteTodosLosDatos()
    {
        Console.WriteLine(" ---------------------- Reporte ----------------------");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("| Nº Factura | Nº Placa  |    Fecha    |  Hora  | Tipo Vehículo | Nº Caseta | Monto a Pagar | Paga Con | Vuelto |");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        for (int i = 0; i < posicionActual; i++)
        {
            Console.WriteLine($"| {numeroFactura[i],10} | {numeroPlaca[i],10} | {fecha[i].ToString("dd/MM/yyyy"),12} | {hora[i].ToString(@"hh\:mm"),6} | {tipoVehiculo[i],13} | {numeroCaseta[i],10} | {montoPagar[i],14} | {pagaCon[i],9} | {vuelto[i],6} |");
        }

        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
    }
}



