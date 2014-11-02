using System;

namespace NearBuy
{
	public class PromoJsO
	{
		public int idPublicidad { get; set; }
		public string nombre { get; set; }
		public string descripcion { get; set; }
		public float precioSnDescuento { get; set; }
		public float descuento { get; set; }
		public DateTime fechaLanzamiento { get; set; }
		public DateTime fechaVencimiento { get; set; }
		public string titulo { get; set; }

		public PromoJsO ()
		{
		}
	}
}

