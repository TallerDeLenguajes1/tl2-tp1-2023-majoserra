namespace EspacioPedido;

public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private int estado;

    private int idCad;

    public int IDcad { get => idCad; }
    public int Estado { get => estado; }

    public void MostrarPedido()
    {
        Console.WriteLine(numero);
        Console.WriteLine(observacion);
        Console.WriteLine(estado);
        Console.WriteLine(idCad);

    }
    public Pedido(int num, string obs, string nomb, string dir, string telef, string datos)
    {
        cliente = new Cliente(nomb, dir, telef, datos);
        numero = num;
        observacion = obs;
        estado = 0; //Pendiente
    }
    public void CambiarEstado()
    {
        if (estado == 0)
        {
            estado = 1;
        }
        else
        {
            estado = 2;
        }
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