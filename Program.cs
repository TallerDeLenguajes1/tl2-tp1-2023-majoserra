using EspacioPedido;
using EspacioInforme;
//using LectorCSV;
using EspacioAccesoADatos;
internal class Program
{
    private static void Main(string[] args)
    {
        
        string rutaDeArchivo = "/Users/maria/OneDrive/Escritorio/TercerAño-SegundoCuatrimestre/Taller de Lenguajes II/tl2-tp1-2023-majoserra/";
        // List<string[]> LecturaDeCadetes = help.LeerCsv(rutaDeArchivo, archivoCadetes, ',');
        // List<Cadete> MisCadetes = help.ConversorDeCadete(LecturaDeCadetes);


        // List<string[]> LecturaDeCadeteria = help.LeerCsv(rutaDeArchivo, archivoCadeteria, ',');
        // Cadeteria cadeteria = help.ConversorDeCadeteria(LecturaDeCadeteria, MisCadetes);
        Console.WriteLine("Elija el Archivo que Desea Leer: ");
        Console.WriteLine("1.- CSV \n\r2.- JSON");
        int seleccion;
        int.TryParse(Console.ReadLine(), out seleccion); 
        List<Cadete> MisCadetes;
        List<Cadeteria> MisCadeterias;
        if (seleccion == 1) // Leemos el Archivo csv
        {
            AccesoCSV LecturaCSV = new AccesoCSV();
            MisCadetes = LecturaCSV.LeerCadetes(rutaDeArchivo+"Cadetes.csv");
            MisCadeterias = LecturaCSV.LeerCadeteria(rutaDeArchivo+"Cadeteria.csv");
        }else // Leemos el archivo JSON
        {
            AccesoJSON LecturaJson = new AccesoJSON();
            MisCadetes = LecturaJson.LeerCadetes(rutaDeArchivo+"Cadetes.json");   

            MisCadeterias = LecturaJson.LeerCadeteria(rutaDeArchivo+"Cadeteria.json");   
        }

        Console.WriteLine("Elija una Cadeteria: ");
        int k=0;
        foreach (var cadeteria in MisCadeterias)
        {
            Console.WriteLine(MisCadeterias[k].Nombre);
            k++;
        }
        bool aux = int.TryParse(Console.ReadLine(), out k);
        if (aux)
        {
            Cadeteria cadeteria = MisCadeterias[k];
            cadeteria.AgregarCadetes(MisCadetes);
            
            Informe info = new Informe(); //Instanciamos informe
            int iteracion = 1;
            
            while (iteracion != 0)
            {
                Console.WriteLine("----------Menu-----------");
                System.Console.WriteLine("1.-Aceptar Pedido \n\r2.-Asignar pedido a Cadete \n\r3.-Envios por Cadete \n\r4.-Reasignar Pedido \n\r5.-Jornal a Cobrar \n\r6.-Listar Pedidos \n\r7.-Cambiar Estado Pedido");
                System.Console.WriteLine("Ingrese una Opcion: ");
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
                        int envios = info.CantidadEnviosCadete(cadeteria, id_cad);
                        Console.WriteLine("La cantidad de Envios por cadete es: "+envios);
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
                        float cobro = info.CobroDeCadete(cadeteria, id_cad);
                        Console.WriteLine("El jornal a cobrar del cadete es: "+cobro);
                    break;
                    case 6:
                        Console.WriteLine("           LISTA PEDIDOS         \n ");
                        foreach (var ped in cadeteria.ListaPedido)
                        {
                            Console.WriteLine("---------Pedido ["+ped.Numero+"]---------");
                            Console.WriteLine("Numero Pedido: "+ped.Numero);
                           // Console.WriteLine("Observacion: "+ped.observacion);
                           // Console.WriteLine("Estado: "+ped.Estado);
                           // Console.WriteLine("Cliente: "+ped.cliente.Nombre);
                           // Console.WriteLine("Direccion cliente: "+cliente.Direccion);
                           // Console.WriteLine("Telefono Cliente: "+cliente.Telefono);
                           // Console.WriteLine("Datos De Referencia: "+cliente.DatosReferencia);
                        }
                    break;
                    case 7: // Cambiar estado pedido
                        Console.WriteLine("Ingrese el Id del pedido: ");
                        int.TryParse(Console.ReadLine(), out id_ped);
                        Console.WriteLine("Ingrese el Nuevo Estado (2=Entregado): ");
                        int estad;
                        int.TryParse(Console.ReadLine(), out estad);
                        
                    break;
                }
                Console.WriteLine("Quiere Seguir Operando? (1=SI) (0=NO)");
                int.TryParse(Console.ReadLine(), out iteracion);
                
            }
        }else
        {
            Console.WriteLine("Se ingreso incorrectamente la Cadeteria :(");
        }

    //     cadeteria.AceptarPedido(1, "Sin queso", "Majo", "Jose Colombres 564", "3495021", "Puerta Blanca");
    //     cadeteria.AceptarPedido(2, "con lechuga", "gordo", "larreta 6436", "3458929", "Rejas Negras");
    //     cadeteria.AceptarPedido(3, "completo", "negro", "blas parera 5643", "38456416", "esquina");
    //     cadeteria.AceptarPedido(4, "sin observaciones", "Jacob cliente", "san martin 425", "38435664", "piso 2 A");
    //     cadeteria.AceptarPedido(2, "con lechuga", "gordo", "larreta 6436", "3458929", "Rejas Negras");
    //     cadeteria.AsignarCadeteAPedido(0,2);

    //     cadeteria.AsignarCadeteAPedido(1,2);
    //     cadeteria.AsignarCadeteAPedido(3,4);
    //     cadeteria.AsignarCadeteAPedido(0,6);
    //     cadeteria.ReasignarPedido(2, 3);

    //     cadeteria.AceptarPedido(5, "familia juar", "nancy", "pasaje alem 5756", "381741634", "depto 4a");
    //     cadeteria.CambiarEstadoPedido(6, 2);
    //     cadeteria.CambiarEstadoPedido(2, 2);
    //     cadeteria.CambiarEstadoPedido(4, 2);
    //    // cadeteria.CambiarEstadoPedido(2, 2);
        
    //     info.CobroDeCadete(cadeteria, 0);
    //     info.CantidadEnviosCadete(cadeteria, 0);
    //     info.CobroDeCadete(cadeteria, 3);
    //     info.CantidadEnviosCadete(cadeteria, 3);
    //     // Cadeteria negocio = new Cadeteria();

    //     // negocio.CrearCadete(1, "Majo", "san juan", "1234");
    //     // negocio.AltaPedido(1, 1, "hola", "Vani", "tafi", "12345", "hola2");
    //     // negocio.AltaPedido(1, 2, "como", "cele", "tafi", "12345", "porton");
    //     // negocio.Mostrar();


    }


}
