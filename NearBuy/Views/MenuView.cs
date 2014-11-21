
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AudioToolbox;

namespace NearBuy
{
	public partial class MenuView : UIViewController
	{
		public MenuView () : base ("MenuView", null)
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

			var frame = new RectangleF(10, 30, 240, 40);
			var textfield1 = new UITextField(frame);
			textfield1.BorderStyle = UITextBorderStyle.RoundedRect;
			View.Add(textfield1);


			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

