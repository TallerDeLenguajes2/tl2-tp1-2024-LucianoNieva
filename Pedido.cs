using cliente;
namespace pedido
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


}

