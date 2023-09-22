using EspacioPedido;
using EspacioInforme;
using LectorCSV;

internal class Program
{
    private static void Main(string[] args)
    {
        string archivoCadetes = "Cadetes.csv";
        string archivoCadeteria = "Cadeteria.csv";
        string rutaDeArchivo = "/Users/user/Downloads/tl2-tp1-2023-majoserra/";

        HelperCsv help = new(); //Instanciamos el Helper

        List<string[]> LecturaDeCadetes = help.LeerCsv(rutaDeArchivo, archivoCadetes, ',');
        List<Cadete> MisCadetes = help.ConversorDeCadete(LecturaDeCadetes);


        List<string[]> LecturaDeCadeteria = help.LeerCsv(rutaDeArchivo, archivoCadeteria, ',');
        Cadeteria cadeteria = help.ConversorDeCadeteria(LecturaDeCadeteria, MisCadetes);

        cadeteria.AltaPedido(0, 1, "Sin queso", "Majo", "Jose Colombres 564", "3495021", "Puerta Blanca");
        cadeteria.AltaPedido(0, 2, "con lechuga", "gordo", "larreta 6436", "3458929", "Rejas Negras");
        cadeteria.AltaPedido(2, 3, "completo", "negro", "blas parera 5643", "38456416", "esquina");
        cadeteria.AltaPedido(1, 4, "sin observaciones", "Jacob cliente", "san martin 425", "38435664", "piso 2 A");

        cadeteria.ReasignarPedido(2, 3);

        cadeteria.AltaPedido(1, 5, "familia juar", "nancy", "pasaje alem 5756", "381741634", "depto 4a");
        MisCadetes[0].CambiarEstadoPedido(1, 2);
        MisCadetes[0].CambiarEstadoPedido(2, 2);
        Informe info = new Informe();
        info.CobroDeCadete(MisCadetes[0]);
        info.CantidadEnviosCadete(MisCadetes[0]);

        // Cadeteria negocio = new Cadeteria();

        // negocio.CrearCadete(1, "Majo", "san juan", "1234");
        // negocio.AltaPedido(1, 1, "hola", "Vani", "tafi", "12345", "hola2");
        // negocio.AltaPedido(1, 2, "como", "cele", "tafi", "12345", "porton");
        // negocio.Mostrar();


    }


}
