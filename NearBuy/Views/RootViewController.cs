
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
		public List<JsonTienda> jsonObj = new List<JsonTienda>();

		public RootViewController () : base ("RootViewController", null)
		{
			Title = "NearBuy";
			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem ("Actualizar",UIBarButtonItemStyle.Plain, (sender, args) => {
				//Boton de actualización
				GetData ();
				DataSource data = new DataSource (jsonObj, this);
				tvDatos.Source = data;
				tvDatos.ReloadData ();
				tvDatos.ReloadInputViews ();
			}), true);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{

			base.ViewDidLoad ();
			//Estilos para la barra de navegacion
			this.NavigationController.NavigationBar.TintColor = UIColor.Gray;
			//this.NavigationController.NavigationBar.BarTintColor =  UIColor.Blue;
			this.NavigationController.NavigationBar.Translucent = true;
			//Fin estilos barra navegacion
			GetData ();
			DataSource data = new DataSource (jsonObj, this);
			tvDatos.Source = data;
			tvDatos.ReloadData ();
			tvDatos.ReloadInputViews ();
		}

		public void GetData ()
		{
			if (!Reachability.IsHostReachable ("www.bordadossantiago.com")) {
				var alert = new UIAlertView {
					Title = "Unable to connect to server", 
					Message = "Verify network connections"
				};
				alert.AddButton ("OK");
				alert.Show ();
			} else {
				var client = new RestClient ("http://bordadossantiago.com/jsonTienda.php");
				var request = new RestRequest ("resource/{Name}", Method.GET);
				request.RequestFormat = DataFormat.Json;
				var response = client.Execute (request);
				RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer ();
				jsonObj = deserial.Deserialize<List<JsonTienda>> (response);
			}
		}
	}
}

