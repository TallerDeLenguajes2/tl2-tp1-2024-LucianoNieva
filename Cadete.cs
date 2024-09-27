using pedido;
namespace cadete{
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
}
