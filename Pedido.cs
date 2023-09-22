namespace EspacioPedido;

public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private int estado;
    private Cadete cadete; //Agregar una referencia a Cadete dentro de la clase Pedido
    public int Numero { get => numero; set => numero = value; }
    public int Estado { get => estado; set => estado = value; }

    // public void MostrarPedido()
    // {
    //     Console.WriteLine(Numero);
    //     Console.WriteLine(observacion);
    //     Console.WriteLine(Estado);
    //     Console.WriteLine(idCad);

    // }
    public Pedido(int num, string obs, string nomb, string dir, string telef, string datos)
    {
        cliente = new Cliente(nomb, dir, telef, datos);
        Numero = num;
        observacion = obs;
        Estado = 0; //Pendiente
    }
    public void verDireccionCliente()
    {
        Console.WriteLine(cliente.Direccion);
    }
    public void verDatosCliente()
    {
        Console.WriteLine(cliente.Nombre);
        Console.WriteLine(cliente.Direccion);
        Console.WriteLine(cliente.Telefono);
        Console.WriteLine(cliente.DatosReferencia);
    }
}