using System.Data.Common;
using EspacioPedido;
namespace EspacioInforme
{
    public class Informe
    {
        public float CobroDeCadete(Cadeteria cade, int id_cad)
        {
            return cade.JornalACobrar(id_cad);
        }
        public int CantidadEnviosCadete(Cadeteria cad, int id_cad)
        {
            return cad.EnviosEntregados(id_cad);
            //Console.WriteLine("Cantidad de Envios de cadete " + id_cad+ " : " + cad.EnviosEntregados(id_cad));
        }
    }

}