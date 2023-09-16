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
                pedido.CambiarEstado();
                cadete.AgregarPedido(pedido);
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

    public void ReasignarPedido(Pedido pedido, int id)
    {
        foreach (Cadete cad in ListaCadete)
        {
            if (cad.Id == id && cad.buscarPedido(pedido) != 1)
            {
                cad.AgregarPedido(pedido);
            }
        }
    }
}

