namespace cliente
{
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
}