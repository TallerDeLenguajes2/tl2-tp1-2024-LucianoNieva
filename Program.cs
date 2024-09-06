using System;
using Cadeteria;
using CargarYLeerDatos;

class Program
{

    static void Main(string[] args)
    {
        string direccionCadeteria;
        string direccionCadete;
        Cadeteria.Cadeteria cadeteria = null;
        List<Cadete> cadetes = null;


        // Seleccionar el tipo de acceso (CSV o JSON)
        Console.WriteLine("Seleccione el tipo de acceso a datos:");
        Console.WriteLine("1. CSV");
        Console.WriteLine("2. JSON");
        Console.Write("Seleccione una opción: ");
        int.TryParse(Console.ReadLine(), out int op1);

        switch (op1)
        {
            case 1:
                AccesoADatos accesoADatosCSV = new AccesoCSV();
                direccionCadeteria = @"cadeteria.csv";
                direccionCadete = @"cadete.csv";
                cadeteria = accesoADatosCSV.CargarCadeteria(direccionCadeteria);
                cadetes = accesoADatosCSV.CargarCadetes(direccionCadete);
                break;
            case 2:
                AccesoADatos accesoADatosJson = new AccesoJSON();
                direccionCadeteria = @"cadeteria.json";
                direccionCadete = @"cadete.json";
                cadeteria = accesoADatosJson.CargarCadeteria(direccionCadeteria);
                cadetes = accesoADatosJson.CargarCadetes(direccionCadete);
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }

    
        foreach (var cadete in cadetes)
        {
            cadeteria.agregarCadetes(cadete);
        }
    
        

        // Mostrar la información cargada
        Console.WriteLine($"Cadetería: {cadeteria.Nombre}, Teléfono: {cadeteria.Telefono}");
        Console.WriteLine("Cadetes:");
        foreach (var cadete in cadeteria.ListadoCadetes)
        {
            Console.WriteLine($"- ID: {cadete.Id}, Nombre: {cadete.Nombre}, Dirección: {cadete.Direccion}");
        }
        int opcion;
        do
        {
            Console.WriteLine("Sistema de Gestión de Pedidos");
            Console.WriteLine("1. Dar de alta pedido");
            Console.WriteLine("2. Asignar pedido");
            Console.WriteLine("3. Cambiar estado de pedido");
            Console.WriteLine("4. Reasignar pedido a otro cadete");
            Console.WriteLine("5. Ver informe de pedidos");
            Console.WriteLine("6 jornal cobrar");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:

                    var pedidoCargado = cadeteria.CargarPedido();
                    cadeteria.ListadoPedidos.Add(pedidoCargado);
                    Console.WriteLine("Pedido dado de alta");
                    break;

                case 2:
                    Console.Write("\nNúmero de pedido: ");
                    int.TryParse(Console.ReadLine(), out int nroPedido);

                    Console.Write("\nNúmero de cadete: ");
                    int.TryParse(Console.ReadLine(), out int idCadete);

                    cadeteria.AsignarCadetePedido(nroPedido, idCadete);
                    break;

                case 3:
                    Console.Write("Número de pedido a cambiar estado: ");
                    int.TryParse(Console.ReadLine(), out int nro);

                    var pedidoACambiar = cadeteria.buscarPedidoACambiar(nro); // Aquí deberías buscar el pedido real según el número
                    cadeteria.CambiarEstadoPedido(pedidoACambiar, Estado.Entregado);
                    break;

                case 4:
                    Console.Write("Número de pedido a cambiar de cadete ");
                    int.TryParse(Console.ReadLine(), out int numero);

                    var pedido = cadeteria.buscarPedidoACambiar(numero);

                    cadeteria.ReasignarPedido(pedido);
                    break;

                case 5:
                    // Ver informe de pedidos
                    break;

                case 6:
                    Console.Write("Número de cadete ");
                    int.TryParse(Console.ReadLine(), out int idCadete1);
                    Console.WriteLine($"eL MONTON A COBRAR ES: {cadeteria.JornalACobrar(idCadete1)}");
                    break;

                case 7:
                    // Salir
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 7);
    }
}





