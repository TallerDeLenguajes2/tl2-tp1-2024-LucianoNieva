using Cadeteria;

namespace CargarYLeerDatos
{
public static class CargarYLeer
    {
        // Cargar Cadetes desde el archivo CSV
        public static List<Cadete> CargarCadetes(string filePath)
        {
            var cadetes = new List<Cadete>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                int id = int.Parse(values[0]);
                string nombre = values[1];
                string direccion = values[2];
                cadetes.Add(new Cadete(id, nombre, direccion));
            }

            return cadetes;
        }

        // Cargar Cadeteria desde el archivo CSV
        public static Cadeteria.Cadeteria CargarCadeteria(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var valores = lines[0].Split(','); // Asume que la primera línea contiene los datos de la Cadeteria

            string nombre = valores[0];
            int telefono = int.Parse(valores[1]);

            var cadeteria = new Cadeteria.Cadeteria(nombre, telefono);

            return cadeteria;
        }
    }
}
