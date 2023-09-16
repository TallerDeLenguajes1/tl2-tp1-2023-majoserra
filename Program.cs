using EspacioPedido;
using LectorCSV;

internal class Program
{
    private static void Main(string[] args)
    {
        string archivoCadetes = "Cadetes.csv";
        string rutaDeArchivo = @"./";

        HelperCsv help = new(); //Instanciamos el Helper

        List<string[]> LecturaDeCadetes = help.LeerCsv(rutaDeArchivo,archivoCadetes, ',');
        List<Cadete> MisCadetes = help.ConversorDeCadete(LecturaDeCadetes);

        foreach (var item in MisCadetes)
        {
            Console.WriteLine(item.MostrarCadete);
        }
        
        // Cadeteria negocio = new Cadeteria();

        // negocio.CrearCadete(1, "Majo", "san juan", "1234");
        // negocio.AltaPedido(1, 1, "hola", "Vani", "tafi", "12345", "hola2");
        // negocio.AltaPedido(1, 2, "como", "cele", "tafi", "12345", "porton");
        // negocio.Mostrar();

        
    }
    

}
