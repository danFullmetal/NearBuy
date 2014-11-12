
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using BigTed;
using System.Net.Http;
using System.Threading.Tasks;

namespace NearBuy
{
	public partial class DetailPromo : UIViewController
	{
		JsonPromos jsonPromos;

		public DetailPromo(JsonPromos jsonPromos){
			this.jsonPromos = jsonPromos;
		}

		public DetailPromo () : base ("DetailPromo", null)
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
			InsertUIImage();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public async void InsertUIImage ()
		{
			string imagenURL = "http://www.bordadossantiago.com/img/wolv.jpg";
			DetailImage.Image = await this.LoadImage (imagenURL);
			BTProgressHUD.Dismiss();
		}

		public async Task<UIImage> LoadImage (string imageUrl)
		{
			BTProgressHUD.Show("Descargando imagen");

			var httpClient = new HttpClient();

			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync (imageUrl);

			// await! control returns to the caller and the task continues to run on another thread
			var contents = await contentsTask;

			// load from bytes
			return UIImage.LoadFromData (NSData.FromArray (contents));
		}

	}
}

