using EspacioPedido;
namespace EspacioInforme
{
    public class Informe
    {
        public void CobroDeCadete(Cadeteria cade)
        {
            Console.WriteLine("Monto Ganado: " + cade.JornalACobrar(cade.));
        }
        public void CantidadEnviosCadete(Cadete cad)
        {
            Console.WriteLine("Cantidad de Envios de cadete " + cad.Id + " : " + cad.EnviosEntregados(cad.Id));
        }
    }

}