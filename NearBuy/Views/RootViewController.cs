
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using RestSharp.Deserializers;
using RestSharp;



namespace NearBuy
{
	public partial class RootViewController : UIViewController
	{
		List<string> ListaDatos = new List<string> ();
		public List<Respuesta> jsonObj;


		public class Respuesta
		{
			public string Name { get; set; }
		}

		public RootViewController () : base ("RootViewController", null)
		{
			Title = "NearBuy";
			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem ("Actualizar",UIBarButtonItemStyle.Plain, (sender, args) => {
				//Boton de actualización
				ListaDatos.Clear ();
				GetData ();
				DataSource data = new DataSource (ListaDatos);
				tvDatos.Source = data;
				tvDatos.ReloadData ();
				tvDatos.ReloadInputViews ();
			}), true);


		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			GetData ();
			base.ViewDidLoad ();
			DataSource data = new DataSource (ListaDatos);
			//ListaDatos.InsertRange (0, tableItems);

			tvDatos.Source = data;
			tvDatos.ReloadData ();
			tvDatos.ReloadInputViews ();

			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void GetData ()
		{
			if (!Reachability.IsHostReachable ("www.bordadossantiago.com")) {
				var alert = new UIAlertView {
					Title = "Unable to connect to server", 
					Message = "Verify network connections"
				};
				alert.AddButton ("OK");
				// last button added is the 'cancel' button (index of '2')
				alert.Clicked += delegate(object a, UIButtonEventArgs b) {
					Console.WriteLine ("Button " + b.ButtonIndex.ToString () + " clicked");
				};
				alert.Show ();
			} else {
				// Create a new RestClient and RestRequest
				var client = new RestClient ("http://bordadossantiago.com/getjson.php");
				var request = new RestRequest ("resource/{Name}", Method.GET);

				// ask for the response to be in JSON syntax
				request.RequestFormat = DataFormat.Json;

				//send the request to the web service and store the response when it comes back
				var response = client.Execute (request);
				// The next line of code will only run after the response has been received

				// Create a new Deserializer to be able to parse the JSON object
				RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer ();

				//Single variable
				jsonObj = deserial.Deserialize<List<Respuesta>> (response);

				/*
			for (int i = 0; i < jsonObj.Count; i++) {
				Console.WriteLine ("Name: {0}", jsonObj[i].Name);
			}*/

				//foreach para sacar los valores y aniadirlos a la lista
				foreach (Respuesta x in jsonObj) {
					Respuesta datos = new Respuesta ();
					datos.Name = x.Name;
					ListaDatos.Add (datos.Name);
				}
			}
		}

		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();

			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;

			ReleaseDesignerOutlets ();
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

