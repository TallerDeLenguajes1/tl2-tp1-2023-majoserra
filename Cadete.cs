namespace EspacioPedido;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    // Quitar el ListadoPedidos de la clase Cadete



    public void MostrarCadete()
    {
        Console.WriteLine(id);
        Console.WriteLine(nombre);
        Console.WriteLine(direccion);
        Console.WriteLine(telefono);
        // foreach (var ped in listaPedido)
        // {
        //     ped.MostrarPedido();
        // }
    }

    public Cadete(int id, string nom, string dir, string telef)
    {
        this.id = id;
        nombre = nom;
        direccion = dir;
        telefono = telef;
    }

    public int Id { get => id; }
    // public void AgregarPedido(Pedido pedido)
    // {
    //     ListaPedido.Add(pedido);
    // }

    // public bool buscarPedido(int id)
    // {
    //     foreach (Pedido ped in ListaPedido)
    //     {
    //         if (id == ped.Numero)
    //         {
    //             return true; //el pedido pertenece al cadete
    //         }
    //     }
    //     return false;
    // }


}
