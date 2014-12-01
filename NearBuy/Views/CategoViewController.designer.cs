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
	[Register ("CategoViewController")]
	partial class CategoViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem bntCloseVC { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnClose { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblBeacon { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnClose != null) {
				btnClose.Dispose ();
				btnClose = null;
			}

			if (lblBeacon != null) {
				lblBeacon.Dispose ();
				lblBeacon = null;
			}

			if (bntCloseVC != null) {
				bntCloseVC.Dispose ();
				bntCloseVC = null;
			}
		}
	}
}
