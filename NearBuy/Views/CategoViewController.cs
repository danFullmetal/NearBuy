
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Security.Cryptography;
using System.Security.Policy;

namespace NearBuy
{
	public partial class CategoViewController : UIViewController
	{

		public CategoViewController () : base ("CategoViewController", null)
		{
			Title = "iBeacon";
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			lblBeacon.Text = "First Beacon";

			bntCloseVC.Clicked += (object sender, EventArgs e) => {
				DismissViewController(true,null);
			};
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

