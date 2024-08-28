


namespace Cadeteria
{

    public enum Estado
    {
        Entregado,
        Pendiente
    };


    public class Pedido
    {

        private int nro;
        private string obs;

        private Cliente cliente;
        private Estado estadoPedido;

        public Pedido(int nro, string obs, Cliente cliente, Estado estadoPedido)
        {
            Nro = nro;
            Obs = obs;
            Cliente = cliente;
            EstadoPedido = estadoPedido;
        }

        public void verDireccionCliente()
        {
            Console.WriteLine($"Direccion: {cliente.Direccion}");
        }

        public void verDatosCliente()
        {
            Console.WriteLine($"El nombre del cliente es: {cliente.Nombre}");
            Console.WriteLine($"El telefono es: {cliente.Telefono}");
        }

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        internal Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
    }


    public class Cliente
    {

        private string nombre;
        private string direccion;
        private int telefono;
        private string datosReferenciaDireccion;
        private string nombreCliente;
        private string direccionCliente;
        private int telefonoCliente;

        public Cliente(string nombreCliente, string direccionCliente, int telefonoCliente)
        {
            this.nombreCliente = nombreCliente;
            this.direccionCliente = direccionCliente;
            this.telefonoCliente = telefonoCliente;
        }

        public Cliente(string nombre, string direccion, int telefono, string datosReferenciaDireccion)
        {

            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            DatosReferenciaDireccion = datosReferenciaDireccion;

        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
    }

    public class Cadete
    {

        private int id;
        private string nombre;
        private string direccion;
        private List<Pedido> listadoPedidos;
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Cadete(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            listadoPedidos = new List<Pedido>();
        }

        public void AgregarPedidos(Pedido pedido)
        {
            listadoPedidos.Add(pedido);
        }

        public void EliminarPedidos(Pedido pedido)
        {
            listadoPedidos.Remove(pedido);
        }

        public void CantidadPedidos()
        {
            Console.WriteLine($"La cantidad de pedidos a entregar es: {listadoPedidos.Count}");
        }

        public void mostrarPedidos()
        {

            foreach (var item in ListadoPedidos)
            {
                Console.WriteLine($"\nEl numero de pedido es: {item.Nro}");
                Console.WriteLine($"\nEl estado del pedido es: {item.EstadoPedido}");
            }

        }

        public List<Pedido> devolverPedidos()
        {
            return listadoPedidos;
        }


        public float JornalACobrar()
        {
            float jornal = ListadoPedidos.Count * 500;
            Console.WriteLine($"La cantidad a cobrar es: {jornal}");
            return jornal; // Si necesitas usar el valor en otros lugares
        }

        internal void EliminarPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }

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