using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace NearBuy
{
	public partial class PromosViewController : UIViewController
	{
		public int idTienda;
		public List<JsonPromos> jsonPromos = new List<JsonPromos>();
		public PromosViewController () : base ("PromosViewController", null)
		{


		}

		public PromosViewController(int numeroTienda){
			idTienda = numeroTienda;

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
			this.Title = "Promociones";
			GetPromoData (idTienda);

			DataSourceTienda data = new DataSourceTienda (jsonPromos, this);
			tvPromos.Source = data;
			tvPromos.ReloadData ();
			tvPromos.ReloadInputViews();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		public void GetPromoData(int idTienda){

			if (!Reachability.IsHostReachable ("www.bordadossantiago.com")) {
				var alert = new UIAlertView {
					Title = "Unable to connect to server", 
					Message = "Verify network connections"
				};
				alert.AddButton ("OK");
				alert.Show ();
			} else {
				var client = new RestClient ("http://bordadossantiago.com/jsonPromos.php");
				var request = new RestRequest ("resource/{Name}", Method.POST);

				request.RequestFormat = DataFormat.Json;
				request.AddParameter ("idTienda",idTienda);
				var response = client.Execute (request);
				RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer ();
				jsonPromos = deserial.Deserialize<List<JsonPromos>> (response);
			}


		}
	}
}

