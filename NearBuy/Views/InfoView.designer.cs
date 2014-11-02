// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace NearBuy
{
	[Register ("InfoView")]
	partial class InfoView
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView imgViewPromo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbDescripcion { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbJSFechaFin { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbJSFechaIn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbPrecioA { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbPrecioB { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgViewPromo != null) {
				imgViewPromo.Dispose ();
				imgViewPromo = null;
			}

			if (lbDescripcion != null) {
				lbDescripcion.Dispose ();
				lbDescripcion = null;
			}

			if (lbJSFechaFin != null) {
				lbJSFechaFin.Dispose ();
				lbJSFechaFin = null;
			}

			if (lbJSFechaIn != null) {
				lbJSFechaIn.Dispose ();
				lbJSFechaIn = null;
			}

			if (lbPrecioA != null) {
				lbPrecioA.Dispose ();
				lbPrecioA = null;
			}

			if (lbPrecioB != null) {
				lbPrecioB.Dispose ();
				lbPrecioB = null;
			}
		}
	}
}
