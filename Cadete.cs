namespace EspacioPedido;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    private List<Pedido> listaPedido = new List<Pedido>();


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

    public void AgregarPedido(Pedido pedido)
    {
        listaPedido.Add(pedido);
    }

    public int buscarPedido(Pedido pedido)
    {
        foreach (Pedido ped in listaPedido)
        {
            if (ped == pedido)
            {
                return 1; //el pedido pertenece al cadete
            }
        }
        return 0;
    }
    public void EntregarPedido(Pedido pedido)
    {
        foreach (var ped in listaPedido)
        {
            if (ped == pedido)
            {
                listaPedido.Remove(pedido);
            }
        }
    }
    public float JornalACobrar()
    {
        int cobrar = 0;
        foreach (var pedido in listaPedido)
        {
            if (pedido.IDcad == id)
            {
                if (pedido.Estado == 2)
                {
                    cobrar++;
                }
            }

        }
        return cobrar * 500;
    }

}
