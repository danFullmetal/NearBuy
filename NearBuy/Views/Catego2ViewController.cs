
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NearBuy
{
	public partial class Catego2ViewController : UIViewController
	{
		public Catego2ViewController () : base ("Catego2ViewController", null)
		{
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

			btnCerrar.Clicked += (object sender, EventArgs e) => {
				DismissViewController(true,null);
			};
				
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

