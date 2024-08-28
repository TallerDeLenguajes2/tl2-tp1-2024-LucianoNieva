using System;
using Cadeteria;
using CargarYLeerDatos;

class Program{

    static void Main(string[] args){
        
        var direccionCadeteria = @"cadeteria.csv";
        var direccionCadete = @"cadete.csv";

        var cadeteria = CargarYLeerDatos.CargarYLeer.CargarCadeteria(direccionCadeteria);
        var cadetes = CargarYLeerDatos.CargarYLeer.CargarCadetes(direccionCadete);

        foreach( var cadete in cadetes){
            cadeteria.agregarCadetes(cadete);
        }

        Console.WriteLine($"Cadetería: {cadeteria.Nombre}, Teléfono: {cadeteria.Telefono}");
            Console.WriteLine("Cadetes:");

            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                Console.WriteLine($"- ID: {cadete.Id}, Nombre: {cadete.Nombre}, Dirección: {cadete.Direccion}");
            }

         // Menú de consola
            int opcion;
            do
            {
                Console.WriteLine("Sistema de Gestión de Pedidos");
                Console.WriteLine("1. Dar de alta pedido");
                Console.WriteLine("2. Cambiar estado de pedido");
                Console.WriteLine("3. Reasignar pedido a otro cadete");
                Console.WriteLine("4. Ver informe de pedidos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        
                        var pedidoCargado = cadeteria.CargarPedido();
                        cadeteria.AsignarPedido(pedidoCargado);
                        Console.WriteLine("Pedido dado de alta y asignado.");
                        break;

                    case 2:
                        Console.Write("Número de pedido a cambiar estado: ");
                        int.TryParse(Console.ReadLine(), out int nro);

                        var pedidoACambiar = cadeteria.buscarPedidoACambiar(nro); // Aquí deberías buscar el pedido real según el número
                        cadeteria.CambiarEstadoPedido(pedidoACambiar, Estado.Entregado);
                        break;

                    case 3:
                        Console.Write("Número de pedido a cambiar de cadete ");
                        int.TryParse(Console.ReadLine(), out int numero);

                        var pedido = cadeteria.buscarPedidoACambiar(numero);

                        cadeteria.ReasignarPedido(pedido);
                        break;

                    case 4:
                        // Ver informe de pedidos
                        cadeteria.Informe();
                        break;

                    case 5:
                        // Salir
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 6);
        }
    }





