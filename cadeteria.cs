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