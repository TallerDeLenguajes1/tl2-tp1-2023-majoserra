﻿using EspacioPedido;
using EspacioInforme;
using LectorCSV;
using EspacioMensajes;
internal class Program
{
    private static void Main(string[] args)
    {
        string archivoCadetes = "Cadetes.csv";
        string archivoCadeteria = "Cadeteria.csv";
        string rutaDeArchivo = "/Users/maria/OneDrive/Escritorio/TercerAño-SegundoCuatrimestre/Taller de Lenguajes II/tl2-tp1-2023-majoserra/";

        HelperCsv help = new(); //Instanciamos el Helper

        List<string[]> LecturaDeCadetes = help.LeerCsv(rutaDeArchivo, archivoCadetes, ',');
        List<Cadete> MisCadetes = help.ConversorDeCadete(LecturaDeCadetes);


        List<string[]> LecturaDeCadeteria = help.LeerCsv(rutaDeArchivo, archivoCadeteria, ',');
        Cadeteria cadeteria = help.ConversorDeCadeteria(LecturaDeCadeteria, MisCadetes);

        Informe info = new Informe(); //Instanciamos informe

        cadeteria.AceptarPedido(2, "con lechuga", "gordo", "larreta 6436", "3458929", "Rejas Negras");
        cadeteria.AsignarCadeteAPedido(0,2);
        cadeteria.CambiarEstadoPedido(2, 2);
        int iteracion = 1;
        Mensaje msj = new Mensaje();
        while (iteracion != 0)
        {
            msj.Menu();
            int opcion;
            int.TryParse(Console.ReadLine(), out opcion);
            switch (opcion)
            {
                case 1:
                    int id;
                    string? obs, nomb, dir, telef, datos;
                    Console.WriteLine("Ingrese el ID del pedido: ");
                    int.TryParse(Console.ReadLine(), out id); // guardamos en id
                    Console.WriteLine("Ingrese las obs del pedido: ");
                    obs = Console.ReadLine();
                    Console.WriteLine("Ingrese el Nombre Cliente: ");
                    nomb = Console.ReadLine();
                    Console.WriteLine("Ingrese la Direccion del Cliente: ");
                    dir = Console.ReadLine();
                    Console.WriteLine("Ingrese el Tel del cliente: ");
                    telef = Console.ReadLine();
                    Console.WriteLine("Ingrese Datos de Referencia: ");
                    datos = Console.ReadLine();
                    cadeteria.AceptarPedido(id, obs, nomb, dir, telef, datos);
                break;
                case 2:
                    int id_ped, id_cad;
                    Console.WriteLine("Ingrese el Id del pedido: ");
                    int.TryParse(Console.ReadLine(), out id_ped);
                    Console.WriteLine("Ingrese el Id del Cadete: ");
                    int.TryParse(Console.ReadLine(), out id_cad);
                    cadeteria.AsignarCadeteAPedido(id_cad, id_ped);
                break;
                case 3: // Envios por Cadete
                    Console.WriteLine("----Envios por Cadete---- \n\rIngrese el id del cadete: ");
                    int.TryParse(Console.ReadLine(), out id_cad);
                    info.CantidadEnviosCadete(cadeteria, id_cad);
                break;
                case 4: // Reasignar pedido 
                    Console.WriteLine("Ingrese el Id del Cadete: ");
                    int.TryParse(Console.ReadLine(), out id_cad);
                    Console.WriteLine("Ingrese el Id del pedido: ");
                    int.TryParse(Console.ReadLine(), out id_ped);
                    cadeteria.ReasignarPedido(id_ped, id_cad);
                break;
                case 5: // jornal a cobrar x cadete
                    Console.WriteLine("----JORNAL A COBRAR---- \n\rIngrese el id del cadete: ");
                    int.TryParse(Console.ReadLine(), out id_cad);
                    info.CobroDeCadete(cadeteria, id_cad);
                break;
                case 6:
                    Console.WriteLine("           LISTA PEDIDOS          ");
                    foreach (var ped in cadeteria.ListaPedido)
                    {
                        ped.MostrarPedido(); //Mostramos todos los pedidos 
                    }
                break;
                case 7: // Cambiar estado pedido
                    Console.WriteLine("Ingrese el Id del pedido: ");
                    int.TryParse(Console.ReadLine(), out id_ped);
                    Console.WriteLine("Ingrese el Nuevo Estado (2=Entregado): ");
                    int estad;
                    int.TryParse(Console.ReadLine(), out estad);
                    cadeteria.CambiarEstadoPedido(id_ped, estad);
                break;
            }
            Console.WriteLine("Quiere Seguir Operando? (1=SI) (0=NO)");
            int.TryParse(Console.ReadLine(), out iteracion);
            
        }

        cadeteria.AceptarPedido(1, "Sin queso", "Majo", "Jose Colombres 564", "3495021", "Puerta Blanca");
        cadeteria.AceptarPedido(2, "con lechuga", "gordo", "larreta 6436", "3458929", "Rejas Negras");
        cadeteria.AceptarPedido(3, "completo", "negro", "blas parera 5643", "38456416", "esquina");
        cadeteria.AceptarPedido(4, "sin observaciones", "Jacob cliente", "san martin 425", "38435664", "piso 2 A");
        cadeteria.AceptarPedido(2, "con lechuga", "gordo", "larreta 6436", "3458929", "Rejas Negras");
        cadeteria.AsignarCadeteAPedido(0,2);

        cadeteria.AsignarCadeteAPedido(1,2);
        cadeteria.AsignarCadeteAPedido(3,4);
        cadeteria.AsignarCadeteAPedido(0,6);
        cadeteria.ReasignarPedido(2, 3);

        cadeteria.AceptarPedido(5, "familia juar", "nancy", "pasaje alem 5756", "381741634", "depto 4a");
        cadeteria.CambiarEstadoPedido(6, 2);
        cadeteria.CambiarEstadoPedido(2, 2);
        cadeteria.CambiarEstadoPedido(4, 2);
       // cadeteria.CambiarEstadoPedido(2, 2);
        
        info.CobroDeCadete(cadeteria, 0);
        info.CantidadEnviosCadete(cadeteria, 0);
        info.CobroDeCadete(cadeteria, 3);
        info.CantidadEnviosCadete(cadeteria, 3);
        // Cadeteria negocio = new Cadeteria();

        // negocio.CrearCadete(1, "Majo", "san juan", "1234");
        // negocio.AltaPedido(1, 1, "hola", "Vani", "tafi", "12345", "hola2");
        // negocio.AltaPedido(1, 2, "como", "cele", "tafi", "12345", "porton");
        // negocio.Mostrar();


    }


}
