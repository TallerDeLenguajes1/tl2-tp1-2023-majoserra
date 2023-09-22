using System.Data.Common;

namespace EspacioPedido;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> ListaCadete = new List<Cadete>();

    /*Agregar ListadoPedidos en la clase Cadeteria que contenga todo los pedidos que
    se vayan generando.*/
    private List<Pedido> listaPedido = new List<Pedido>();
    public List<Pedido> ListaPedido { get => listaPedido; }

    //Constructor de Cadeteria
    public Cadeteria(string nombre, string telefono, List<Cadete> ListaCadete)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.ListaCadete = ListaCadete;
    }
    // Aceptar un pedido y ponerlo en "Espera"
    public void AceptarPedido(int num, string obs, string nomb, string dir, string telef, string datos)
    {
        Pedido pedido = new Pedido(num, obs, nomb, dir, telef, datos); //Creamos el pedido
        listaPedido.Add(pedido); // Agregar los pedido a la Lista de Pedidos
    }

    // Asignar un Pedido a un Cadete 
    /* Agregar el método AsignarCadeteAPedido en la clase Cadeteria que recibe como
    parámetro el id del cadete y el id del Pedido*/
    public void AsignarCadeteAPedido(int idcad, int id_pedido)
    {
        Cadete? cadBuscado = ListaCadete.FirstOrDefault(cad => cad.Id == idcad);
        if (cadBuscado != null)
        {
            Pedido? pedBuscado = listaPedido.FirstOrDefault(p => p.Numero == id_pedido);
            if (pedBuscado != null)
            {
                pedBuscado.Cadete = cadBuscado;
            }
        }
    }
    public void CrearCadete(int id, string nomb, string dir, string telef)
    {
        Cadete cad = new Cadete(id, nomb, dir, telef);
        ListaCadete.Add(cad);
    }

    public void ReasignarPedido(int id_Pedido, int id_CadeteNuevo)
    {
        Pedido? pedBuscado = listaPedido.FirstOrDefault(p => p.Cadete.Id == id_Pedido);
        if (pedBuscado != null) // Si el pedido existe y es distinto de null 
        {
            Cadete? cadBuscado = ListaCadete.FirstOrDefault(cad => cad.Id == id_CadeteNuevo);
            if (cadBuscado != null)
            {
                pedBuscado.Cadete = cadBuscado;
            }
            else
            {
                System.Console.WriteLine("El cadete No existe");
            }
        }
        else
        {
            System.Console.WriteLine("El pedido que se quiere reasignar no existe");
        }
    }

    public void CambiarEstadoPedido(int id_pedido, int estado)
    {
        Pedido? pedEncontrado = ListaPedido.FirstOrDefault(p => p.Numero == id_pedido);
        if (pedEncontrado != null)
        {
            pedEncontrado.Estado = estado;
        }
    }
    public int EnviosEntregados(int id_cad)
    {
        int cantEnvios = 0;

        foreach (var ped in listaPedido)
        {
            if (ped.Cadete.Id == id_cad && ped.Estado == 2)//controlamos que los cadetes de esos pedidos sean los mismos y el estado sea 2 (Entregado)
            {
                cantEnvios++;
            }
        }
        return cantEnvios;
    }
    // Agregar el método JornalACobrar en la clase Cadeteria que recibe como parámetro el id del cadete y devuelve el monto a cobrar para dicho cadete

    public float JornalACobrar(int id_cad)
    {
        return EnviosEntregados(id_cad) * 500;
    }
}