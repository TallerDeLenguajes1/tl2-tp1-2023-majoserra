using System.Data.Common;

namespace EspacioPedido;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> ListaCadete = new List<Cadete>();

    public Cadeteria(string nombre, string telefono, List<Cadete> ListaCadete)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.ListaCadete = ListaCadete;
    }
    public void AltaPedido(int idcad, int num, string obs, string nomb, string dir, string telef, string datos)
    {
        foreach (var cadete in ListaCadete)
        {
            if (cadete.Id == idcad)
            {//reemplazar con metodos linq
                Pedido pedido = new Pedido(num, obs, nomb, dir, telef, datos);
                cadete.AgregarPedido(pedido);
                cadete.CambiarEstadoPedido(pedido.Numero, 1); //pedido aceptado
            }
        }
    }
    public void Mostrar()
    {
        foreach (var cad in ListaCadete)
        {
            cad.MostrarCadete();
        }
    }
    public void CrearCadete(int id, string nomb, string dir, string telef)
    {
        Cadete cad = new Cadete(id, nomb, dir, telef);
        ListaCadete.Add(cad);
    }

    public void ReasignarPedido(int id_Pedido, int id_CadeteNuevo)
    {
        foreach (Cadete cad in ListaCadete)
        {
            if (cad.buscarPedido(id_Pedido)) //el cadete tiene el pedido
            {
                Pedido? pedido = cad.ListaPedido.FirstOrDefault(p => p.Numero == id_Pedido);
                if (pedido != null)
                {
                    cad.ListaPedido.Remove(pedido);
                    Cadete? cadNuevo = ListaCadete.FirstOrDefault(c => c.Id == id_CadeteNuevo);

                    if (cadNuevo != null)
                    {
                        cadNuevo.ListaPedido.Add(pedido);
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
        }
    }
}