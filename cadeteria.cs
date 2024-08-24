

namespace Cadeteria
{

    enum Estado{
        aprobado,
        rechazado,
        pendiente
    };


    public class Pedido{

        private int nro;
        private string obs;

        private Cliente cliente;
        private Estado estadoPedido;

        public Pedido(string nombre, string direccion , int telefono, string datosReferenciaDireccion)
        {
            this.cliente = new Cliente(){
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                DatosReferenciaDireccion = datosReferenciaDireccion
                };
        }

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        internal Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
    }


    public class Cliente{
        
        private string nombre;
        private string direccion;
        private int telefono;
        private string datosReferenciaDireccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
    }

    public class Cadete{

        private int id;
        private string nombre;
        private string direccion;

        private List <Pedido> ListadoPedidos;

        public Cadete(){
            this.ListadoPedidos = new List<Pedido>();
        }

        public void AgregarPedidos(Pedido pedido)
        {
            this.ListadoPedidos.Add(pedido);
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public List<Pedido> ListadoPedidos1 { get => ListadoPedidos; set => ListadoPedidos = value; }
    }

    public class Cadeteria{
        
        private string nombre;
        private int telefono;
        private List<Cadete> listadoCadetes;

        public Cadeteria(){
            this.listadoCadetes = new List<Cadete>();
        }

        public void agregarCadetes(Cadete cadete){

            this.listadoCadetes.Add(cadete);
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    }



}