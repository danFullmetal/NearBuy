
using System;
using System.Drawing;

using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NearBuy
{
	public partial class InfoView : UIViewController
	{
		JsonPromos jsonPromos;
		public string promoImage;

		public InfoView(JsonPromos jsonPromos){
			this.jsonPromos = jsonPromos;
		}

		public InfoView () : base ("InfoView", null)
		{
		
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = jsonPromos.titulo;

			promoImage = jsonPromos.imagen;
			byte[] bytes = Convert.FromBase64String (promoImage);
			NSData data = NSData.FromArray (bytes);
			var uiImage = UIImage.LoadFromData (data);

			imgViewPromo.Image = uiImage;

			lbDescripcion.Text = jsonPromos.descripcion;
			lbJSFechaIn.Text = jsonPromos.fechaLanzamiento.ToString();
			lbJSFechaFin.Text = jsonPromos.fechaVencimiento.ToString();
			lbPrecioA.Text = jsonPromos.precio.ToString();
			lbPrecioB.Text = jsonPromos.descuento.ToString();



		}
	}
}

