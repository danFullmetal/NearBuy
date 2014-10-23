
using System;
using System.Drawing;

using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NearBuy
{
	public partial class InfoView : UIViewController
	{
		JSONObjects jsonObject;

		public InfoView(JSONObjects jsonObject){
			this.jsonObject = jsonObject;
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
			lbJSName.Text = jsonObject.Name;
			lbJSMessage.Text = jsonObject.Message;
		}
	}
}

