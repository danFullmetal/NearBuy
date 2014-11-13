using System;

namespace NearBuy
{
	public class JsonTienda
	{
		public JsonTienda ()
		{
		}
		public int idTienda { get; set; }
		public int idCentro_Comercial { get; set; }
		public string nombre { get; set; }
		public string logo { get; set; }
		public string mensaje { get; set; }
		public int promociones { get; set; }
		public int version { get; set; }
	}
}

