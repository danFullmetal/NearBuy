using System;

namespace NearBuy
{
	public class JsonPromos
	{
		public JsonPromos ()
		{
		}
		public int idTienda { get; set; }
		public int idPromocion { get; set; }
		public float precio { get; set; }
		public float descuento { get; set; }
		public DateTime fechaLanzamiento { get; set; }
		public DateTime fechaVencimiento { get; set; }
		public string descripcion { get; set; }
		public string titulo { get; set; }
		public string tipo { get; set; }
		public string imagen { get; set; }

	}
}

