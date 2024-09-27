using pedido;
namespace cadete
{
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

}