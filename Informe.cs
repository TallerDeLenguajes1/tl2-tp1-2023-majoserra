using EspacioPedido;
namespace EspacioInforme
{
    public class Informe
    {
        public void CobroDeCadete(Cadete cad)
        {
            Console.WriteLine("Monto Ganado: " + cad.JornalACobrar());
        }
        public void CantidadEnviosCadete(Cadete cad)
        {
            Console.WriteLine("Cantidad de Envios de cadete " + cad.Id + " : " + cad.EnviosEntregados());
        }
    }

}