


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

        private Cadete cadete;

        public Pedido(int nro, string obs, Cliente cliente, Estado estadoPedido, Cadete cadete)
        {
            Nro = nro;
            Obs = obs;
            Cliente = cliente;
            EstadoPedido = estadoPedido;
            Cadete = cadete;
            
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
        public Cadete Cadete { get => cadete; set => cadete = value; }
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
        
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        
        public Cadete(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
           
        }

    /*   
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
*/

        

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

        private List<Pedido> listadoPedidos;
        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Cadeteria(string nombre, int telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
            this.listadoCadetes = new List<Cadete>();
            this.listadoPedidos = new List<Pedido>();
        }

        public void agregarCadetes(Cadete cadete)
        {

            this.listadoCadetes.Add(cadete);
        }

        public void ReasignarPedido(Pedido pedido)
        {
        
            var otroCadete = devolverCadeteAleatorio();
            pedido.Cadete = otroCadete;
            Console.WriteLine($"El pedido fue asignado al nuevo cadete: {otroCadete.Nombre}");
            
            
        }


        public void AgregarPedidos(Pedido pedido)
        {
            listadoPedidos.Add(pedido);
        }

        public void EliminarPedidos(Pedido pedido)
        {
            listadoPedidos.Remove(pedido);
        }


        public Cadete devolverCadeteAleatorio(){

            Random random = new Random();
            int index = random.Next(listadoCadetes.Count);

            return listadoCadetes[index];
        }

        

      /*  public void Informe()
        {

            System.Console.WriteLine("Informe de pedidos");

            foreach (var pedido in ListadoPedidos)
            {

                Console.WriteLine($"Cadete: {pedido.Cadete.Nombre}, Envíos: {.ListadoPedidos.Count}, Ganancias: ${cadete.JornalACobrar()}");

            }


        }
*/
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
            return new Pedido(nro, obs, cliente, Estado.Pendiente, null);
        }

        public Pedido buscarPedidoACambiar(int n)
        {

            return listadoPedidos.FirstOrDefault(p => p.Nro == n);
              
        }

        public void CambiarEstadoPedido(Pedido pedido, Estado estado)
        {

            pedido.EstadoPedido = estado;
            Console.WriteLine("\n Se cambio el estado del pedido a ENTREGADO");
        }

        public float 
        
        
        JornalACobrar(int id)
        {
            int contarPedidos = listadoPedidos.Count(p => p.Cadete.Id == id);
            return contarPedidos*500;
        }


        public void AsignarCadetePedido(int idPedido, int idCadete){


            var pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

            var cadete = listadoCadetes.FirstOrDefault(p => p.Id == idCadete);

            

            if (pedido != null && cadete != null)
            {
                pedido.Cadete = cadete;
                Console.WriteLine($"El pedido {pedido.Nro} fue asignado al cadete {cadete.Nombre}");
            }else
            {
                Console.WriteLine("vacio");
            }

        }
    }



}