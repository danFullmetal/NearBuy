using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using RestSharp.Deserializers;
using RestSharp;
using MonoTouch.CoreBluetooth;
using MonoTouch.CoreLocation;
using MonoTouch.CoreFoundation;
using MonoTouch.ObjCRuntime;
using BigTed;
using MonoTouch.Dialog;



namespace NearBuy
{
	public partial class RootViewController : UIViewController
	{
		public List<JsonTienda> jsonObj = new List<JsonTienda>();

		//ResultsTableController resultsTableController;
		//UISearchController searchController;

		protected LoadingOverlay _loadPop = null;

		static readonly string uuid = "E4C8A4FC-F68B-470D-959F-29382AF72CE7";
		static readonly string firstShopId = "shop1";

		static readonly string uuid2 = "E4C8A4FC-F68B-470D-959F-18272AF72CE6";
		static readonly string secondShopId = "shop2";

		//CBPeripheralManager peripheralMgr;
		//BTPeripheralDelegate peripheralDelegate;
		CLLocationManager locationMgr;
		//CLProximity previousProximity;
		//CLProximity previousProximity;

		UIBarButtonItem reloadButton;
		UIBarButtonItem searchButton;

		public int keepVar = 0;

		public RootViewController () : base ("RootViewController", null)
		{
			Title = "NearBuy";

			reloadButton = new UIBarButtonItem (
				UIImage.FromFile ("reload.png"),
				UIBarButtonItemStyle.Plain,
				(s, e) => {
					System.Diagnostics.Debug.WriteLine ("button tapped");
					GetData ();
					DataSource data = new DataSource (jsonObj, this);
					tvDatos.Source = data;
					tvDatos.ReloadData ();
					tvDatos.ReloadInputViews ();
				}
			);

			searchButton = new UIBarButtonItem (
				UIImage.FromFile ("magnifyingglass.png"),
				UIBarButtonItemStyle.Plain,
				(s, e) => {
					//System.Diagnostics.Debug.WriteLine ("button tapped");
					var SearchVC = new MainTableViewController();
					this.NavigationController.PushViewController(SearchVC, true);
				}
			);

			UIBarButtonItem[] buttonList = new UIBarButtonItem[]
			{
				reloadButton,
				searchButton
			};
				
			NavigationItem.RightBarButtonItems = buttonList;
			//NavigationItem.RightBarButtonItem = searchButton;

			/*
			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem ("Actualizar",UIBarButtonItemStyle.Plain, (sender, args) => {
				//Boton de actualización
				GetData ();
				DataSource data = new DataSource (jsonObj, this);
				tvDatos.Source = data;
				tvDatos.ReloadData ();
				tvDatos.ReloadInputViews ();

			}), true);
			*/	
				
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{

			base.ViewDidLoad ();

			this.NavigationController.NavigationBar.Translucent = true;	
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

			//Nuevos beacons

			var settings = UIUserNotificationSettings.GetSettingsForTypes(
				UIUserNotificationType.Alert
				| UIUserNotificationType.Badge
				| UIUserNotificationType.Sound,
				new NSSet());
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

			locationMgr = new CLLocationManager ();

			if(locationMgr.RespondsToSelector(new Selector("requestWhenInUseAuthorization")))
			{
				locationMgr.RequestAlwaysAuthorization();
			}

			//primer beacon
			var shopUUID = new NSUuid (uuid);
			var beaconRegion = new CLBeaconRegion (shopUUID, firstShopId);

			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;

			locationMgr.StartMonitoring (beaconRegion);
			locationMgr.StartRangingBeacons (beaconRegion);

			//segundo beacon
			var shop2UUID = new NSUuid (uuid2);
			var beaconRegion2 = new CLBeaconRegion(shop2UUID, secondShopId);

			beaconRegion2.NotifyEntryStateOnDisplay = true;
			beaconRegion2.NotifyOnEntry = true;
			beaconRegion2.NotifyOnExit = true;

			locationMgr.StartMonitoring (beaconRegion2);
			locationMgr.StartRangingBeacons (beaconRegion2);



			locationMgr.RegionEntered += (object sender, CLRegionEventArgs e) => {
				Console.WriteLine ("RegionEntered");

				switch(e.Region.Identifier){
					case "shop2":
						UILocalNotification notification = new UILocalNotification () { AlertBody = "Existe una promoción A!!!" };
						UIApplication.SharedApplication.PresentLocationNotificationNow (notification);
						break;
					case "shop1":
						UILocalNotification notification2 = new UILocalNotification () { AlertBody = "Existe una promoción B!!!" };
						UIApplication.SharedApplication.PresentLocationNotificationNow (notification2);
						break;
				}
				/*
				if (e.Region.Identifier == secondShopId) {
					UILocalNotification notification = new UILocalNotification () { AlertBody = "Existe una promoción A!!!" };
					UIApplication.SharedApplication.PresentLocationNotificationNow (notification);
				}
				if (e.Region.Identifier == firstShopId) {
					UILocalNotification notification = new UILocalNotification () { AlertBody = "Existe una promoción B!!!" };
					UIApplication.SharedApplication.PresentLocationNotificationNow (notification);
				}
				*/
			};

			locationMgr.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) => {
				System.Diagnostics.Debug.WriteLine("Entramos");
				if(e.Beacons.Length > 0){
					if(e.Region.Identifier == firstShopId){
						CLBeacon beacon = e.Beacons [0];
						switch(beacon.Proximity){
						case CLProximity.Immediate:
							Console.WriteLine ("Beacon 1");
							var CategoryVC = new iBeaconVC();
							this.NavigationController.PresentViewController(CategoryVC, true, null);
							break;
						}

					}
					if(e.Region.Identifier == secondShopId){
						CLBeacon beacon = e.Beacons [0];
						switch(beacon.Proximity){
							case CLProximity.Immediate:
							Console.WriteLine ("Beacon 2");
							var Category2VC = new Catego2ViewController();
							this.NavigationController.PresentViewController(Category2VC, true, null);
							break;
						}
					}
				}
			};



			//locationMgr.StartMonitoring (beaconRegion2);
			//locationMgr.StartRangingBeacons (beaconRegion2);


			//this.NavigationController.PushViewController(CategoryVC, true);

		}
			
		public void GetData ()
		{
			if(Reachability.IsHostReachable("www.codecags.com")) {
				var client = new RestClient ("http://www.codecags.com");
				var request = new RestRequest ("jsonTienda.php", Method.GET);
				request.RequestFormat = DataFormat.Json;
				var response = client.Execute (request);
				RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer ();
				jsonObj = deserial.Deserialize<List<JsonTienda>> (response);
			}
			else
			{
				var alert = new UIAlertView ("Connection Error", "Unable to connect to server", null, "OK", new string[] {"Cancel"});
				alert.Clicked += (s, b) => {
					Console.WriteLine ("Button " + b.ButtonIndex.ToString () + " clicked");
				};
				alert.Show();
			}
				

		}
	}
}

