namespace EspacioPedido;

public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private int estado;

    private int idCad;

    public int IDcad { get => idCad; }
    public int Numero { get => numero; set => numero = value; }
    public int Estado { get => estado; set => estado = value; }

    public void MostrarPedido()
    {
        Console.WriteLine(Numero);
        Console.WriteLine(observacion);
        Console.WriteLine(Estado);
        Console.WriteLine(idCad);

    }
    public Pedido(int num, string obs, string nomb, string dir, string telef, string datos)
    {
        cliente = new Cliente(nomb, dir, telef, datos);
        Numero = num;
        observacion = obs;
        Estado = 0; //Pendiente
    }
    public void CambiarEstado()
    {
        if (Estado == 0)
        {
            Estado = 1;
        }
        else
        {
            Estado = 2;
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