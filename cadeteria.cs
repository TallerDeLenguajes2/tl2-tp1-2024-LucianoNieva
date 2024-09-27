using cadete;
using pedido;
using cliente;

namespace Cadeteria
{
    public class Cadeteria
    {

        private string nombre;
        private int telefono;
        private List<Cadete> listadoCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria(string nombre, int telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
            this.listadoCadetes = new List<Cadete>();
        }

        public void agregarCadetes(Cadete cadete)
        {

            this.listadoCadetes.Add(cadete);
        }


        public void AsignarPedido(Pedido pedido)
        {
            if (listadoCadetes.Count == 0)
            {
                Console.WriteLine("No hay cadetes disponibles para asignar el pedido.");
                return;
            }

            var cadete = devolverCadeteAleatorio();
            cadete.AgregarPedidos(pedido);
            Console.WriteLine($"El pedido ha sido asignado al cadete: {cadete.Nombre}");
        }


        public void ReasignarPedido(Pedido pedido)
        {

            var cadeteActual = ObtenerCadeteConPedido(pedido);


            if (cadeteActual != null)
            {
                cadeteActual.EliminarPedidos(pedido);
            }
            else
            {
                Console.WriteLine("El pedido no estaba asignado a ningún cadete.");
            }

            var otroCadete = devolverCadeteAleatorio();

            while (otroCadete == cadeteActual)
            {
                otroCadete = devolverCadeteAleatorio();
            }

            otroCadete.AgregarPedidos(pedido);
            Console.WriteLine($"El pedido fue asignado al nuevo cadete: {otroCadete.Nombre}");
            
            
        }

        public Cadete devolverCadeteAleatorio(){

            Random random = new Random();
            int index = random.Next(listadoCadetes.Count);

            return listadoCadetes[index];
        }

        private Cadete ObtenerCadeteConPedido(Pedido pedido)
        {

            foreach (var cadete in ListadoCadetes)
            {
                // Verificamos si el pedido está en la lista de pedidos del cadete actual
                if (cadete.ListadoPedidos.Contains(pedido))
                {

                    return cadete;
                }
            }


            return null;
        }

        public void Informe()
        {

            System.Console.WriteLine("Informe de pedidos");

            foreach (var cadete in ListadoCadetes)
            {

                Console.WriteLine($"Cadete: {cadete.Nombre}, Envíos: {cadete.ListadoPedidos.Count}, Ganancias: ${cadete.JornalACobrar()}");

            }


        }

        public Pedido CargarPedido()
        {
            Console.Write("Número de pedido: ");
            int nro = int.Parse(Console.ReadLine());

            Console.Write("Observaciones: ");
            string obs = Console.ReadLine();

            Console.Write("Nombre del cliente: ");
            string nombreCliente = Console.ReadLine();

            Console.Write("Dirección del cliente: ");
            string direccionCliente = Console.ReadLine();

            Console.Write("Teléfono del cliente: ");
            int telefonoCliente = int.Parse(Console.ReadLine());

            var cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente);
            return new Pedido(nro, obs, cliente, Estado.Pendiente);
        }

        public Pedido buscarPedidoACambiar(int n)
        {

            foreach (var cadete in ListadoCadetes)
            {
                Console.WriteLine($"Pedidos del cadete {cadete.Nombre}");
                cadete.mostrarPedidos();

                foreach (var pedido in cadete.devolverPedidos())
                {
                    if (pedido.Nro == n)
                    {
                        return pedido;
                    }
                }
            }



            return null;
        }

        public void CambiarEstadoPedido(Pedido pedido, Estado estado)
        {

            pedido.EstadoPedido = estado;
            Console.WriteLine("\n Se cambio el estado del pedido a ENTREGADO");
        }



    }



}