using System.Data.Common;
using EspacioPedido;
namespace EspacioInforme
{
    public class Informe
    {
        public void CobroDeCadete(Cadeteria cade, int id_cad)
        {
            Console.WriteLine("Monto Ganado: " + cade.JornalACobrar(id_cad));
        }
        public void CantidadEnviosCadete(Cadeteria cad, int id_cad)
        {
            Console.WriteLine("Cantidad de Envios de cadete " + id_cad+ " : " + cad.EnviosEntregados(id_cad));
        }
    }

}