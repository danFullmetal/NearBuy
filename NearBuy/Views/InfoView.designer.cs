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
		MonoTouch.UIKit.UILabel lbJSMessage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbJSName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbJSName != null) {
				lbJSName.Dispose ();
				lbJSName = null;
			}

			if (lbJSMessage != null) {
				lbJSMessage.Dispose ();
				lbJSMessage = null;
			}
		}
	}
}
