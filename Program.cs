using System;
using Cadeteria;
using CargarYLeerDatos;

class Program{

    static void Main(string[] args){
        
        var direccionCadeteria = @"C:\Users\lucia\OneDrive\Escritorio\tallertp\tl2-tp1-2024-LucianoNieva\cadeteria.csv";
        var direccionCadete = @"C:\Users\lucia\OneDrive\Escritorio\tallertp\tl2-tp1-2024-LucianoNieva\cadete.csv";

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
                Console.WriteLine("2. Asignar pedido a cadete");
                Console.WriteLine("3. Cambiar estado de pedido");
                Console.WriteLine("4. Reasignar pedido a otro cadete");
                Console.WriteLine("5. Ver informe de pedidos");
                Console.WriteLine("6. Salir");
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
                        // Asignar pedido a cadete (lo implementamos en el caso 1)
                        break;

                    case 3:
                        // Cambiar estado de pedido
                      /*  Console.Write("Número de pedido a cambiar estado: ");
                        nro = int.Parse(Console.ReadLine());

                        var pedidoACambiar = pedido1; // Aquí deberías buscar el pedido real según el número
                        cadeteria.CambiarEstadoPedido(pedidoACambiar, Estado.Entregado);*/
                        break;

                    case 4:
                        // Reasignar pedido a otro cadete
                        /*var nuevoCadete = new Cadete(2, "Cadete 2", "Dirección Cadete 2");
                        cadeteria.AgregarCadete(nuevoCadete);

                        cadeteria.ReasignarPedido(pedido1, nuevoCadete);*/
                        break;

                    case 5:
                        // Ver informe de pedidos
                        cadeteria.Informe();
                        break;

                    case 6:
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





