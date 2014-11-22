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
		MonoTouch.UIKit.UIButton _btnFav { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem btnCountdown { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnFav { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbCountdown { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbJSFechaFin { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbPrecioA { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbPrecioB { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbPrecioTotal { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbTiempo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbTimer { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbTituloPromo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch swiFav { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView txtDescr { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView uiImagePromo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnFav != null) {
				btnFav.Dispose ();
				btnFav = null;
			}

			if (_btnFav != null) {
				_btnFav.Dispose ();
				_btnFav = null;
			}

			if (btnCountdown != null) {
				btnCountdown.Dispose ();
				btnCountdown = null;
			}

			if (lbCountdown != null) {
				lbCountdown.Dispose ();
				lbCountdown = null;
			}

			if (lbJSFechaFin != null) {
				lbJSFechaFin.Dispose ();
				lbJSFechaFin = null;
			}

			if (lbPrecioA != null) {
				lbPrecioA.Dispose ();
				lbPrecioA = null;
			}

			if (lbPrecioB != null) {
				lbPrecioB.Dispose ();
				lbPrecioB = null;
			}

			if (lbPrecioTotal != null) {
				lbPrecioTotal.Dispose ();
				lbPrecioTotal = null;
			}

			if (lbTiempo != null) {
				lbTiempo.Dispose ();
				lbTiempo = null;
			}

			if (lbTimer != null) {
				lbTimer.Dispose ();
				lbTimer = null;
			}

			if (lbTituloPromo != null) {
				lbTituloPromo.Dispose ();
				lbTituloPromo = null;
			}

			if (swiFav != null) {
				swiFav.Dispose ();
				swiFav = null;
			}

			if (txtDescr != null) {
				txtDescr.Dispose ();
				txtDescr = null;
			}

			if (uiImagePromo != null) {
				uiImagePromo.Dispose ();
				uiImagePromo = null;
			}
		}
	}
}
