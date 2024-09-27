using Cadeteria;
using System.Text.Json;
using cadete;

namespace CargarYLeerDatos
{


    public abstract class AccesoADatos
    {
        public abstract List<Cadete> CargarCadetes(string filePath);
        public abstract Cadeteria.Cadeteria CargarCadeteria(string filePath);
    }
    public class AccesoCSV : AccesoADatos
    {

        // Cargar Cadetes desde el archivo CSV
        public override List<Cadete> CargarCadetes(string filePath)
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
        public override Cadeteria.Cadeteria CargarCadeteria(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var valores = lines[0].Split(','); // Asume que la primera línea contiene los datos de la Cadeteria

            string nombre = valores[0];
            int telefono = int.Parse(valores[1]);

            var cadeteria = new Cadeteria.Cadeteria(nombre, telefono);

            return cadeteria;
        }

    }

    public class AccesoJSON: AccesoADatos
    {

        public override List<Cadete> CargarCadetes(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            var cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonData);

            if (cadetes == null)
            {
                return new List<Cadete>();
            }else
            {
                return cadetes;
            }
        }

        public override Cadeteria.Cadeteria CargarCadeteria(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            var cadeteria = JsonSerializer.Deserialize<Cadeteria.Cadeteria>(jsonData);

            if (cadeteria == null)
            {
                return new Cadeteria.Cadeteria("sin nombre", 0);
            }else
            {
                return cadeteria;
            }
        }
    }
}
