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
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnActualizar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tvDatos { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tvDatos != null) {
				tvDatos.Dispose ();
				tvDatos = null;
			}

			if (btnActualizar != null) {
				btnActualizar.Dispose ();
				btnActualizar = null;
			}
		}
	}
}
