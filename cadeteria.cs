


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

        public string ReasignarPedido(int nroPedido, int idCadete)
        {
            var pedido = listadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (pedido == null) return "Pedido no encontrado";

            var otroCadete = listadoCadetes.FirstOrDefault(p => p.Id == idCadete);
            if (otroCadete == null) return "Cadete no encontrado";

            if (pedido.Cadete.Id != idCadete)
            {
                pedido.Cadete = otroCadete;
                return $"El pedido fue asignado al nuevo cadete: {otroCadete.Nombre}";
            }
            else
            {
                return "Se seleccionó el mismo cadete";
            }
        }




        public void EliminarPedidos(int nroPedido)
        {
            var pedido = listadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
            listadoPedidos.Remove(pedido);
        }

        public Pedido CargarPedido(int nro, string obs, string nombreCliente, string direccionCliente, int telefonoCliente)
        {
            var cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente);
            return new Pedido(nro, obs, cliente, Estado.Pendiente, null);
        }

        public Pedido buscarPedidoACambiar(int n)
        {

            return listadoPedidos.FirstOrDefault(p => p.Nro == n);

        }

        public string CambiarEstadoPedido(int idPedido)
        {

            var pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
            pedido.EstadoPedido = Estado.Entregado;

            return "\nSe cambio el pedido a entregado";
        }

        public float JornalACobrar(int id)
        {
            int contarPedidos = listadoPedidos.Count(p => p.Cadete.Id == id);
            return contarPedidos * 500;
        }


        public string AsignarCadetePedido(int idPedido, int idCadete)
        {


            var pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

            var cadete = listadoCadetes.FirstOrDefault(p => p.Id == idCadete);

            pedido.Cadete = cadete;

            return $"El cadete {cadete.Nombre} fue asignado correctamente";


        }

        public List<string> Informe()
        {
            List<string> informe = new List<string>
    {
        "=== Informe de Pedidos - Fin de Jornada ===\n"
    };
            foreach (var cadete in ListadoCadetes)
            {

                IEnumerable<Pedido> pedidosDelCadete = ListadoPedidos
                    .Where(pedido => pedido.Cadete != null &&
                                     pedido.Cadete.Id == cadete.Id &&
                                     pedido.EstadoPedido == Estado.Entregado);

                int cantidadEnvios = pedidosDelCadete.Count();
                double montoGanado = JornalACobrar(cadete.Id);

                informe.Add($"Cadete: {cadete.Nombre}");
                informe.Add($"Cantidad de Envíos: {cantidadEnvios}");
                informe.Add($"Monto Ganado: ${montoGanado}\n");
            }

            int totalEnvios = ListadoPedidos
                .Count(pedido => pedido.EstadoPedido == Estado.Entregado);

            double promedioEnvios = ListadoCadetes.Count > 0
                ? (double)totalEnvios / ListadoCadetes.Count
                : 0;

            informe.Add($"Total de Envíos: {totalEnvios}");
            informe.Add($"Promedio de Envíos por Cadete: {promedioEnvios:F2}\n");

            return informe;
        }

        public void ImprimirInforme()
        {
            var informe = Informe(); // Obtener el informe como lista de cadenas
            foreach (var linea in informe)
            {
                Console.WriteLine(linea); // Imprimir cada línea del informe
            }
        }


    }



}