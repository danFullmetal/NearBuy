using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.SlideoutNavigation;
using MonoTouch.Dialog;
using System.Drawing;
using System;
using System.Collections.Generic;
using RestSharp;
using System.Linq;
using RestSharp.Deserializers;


namespace NearBuy
{

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		public SlideoutNavigationController Menu { get; private set; }
		// This is the main entry point of the application.
		static void Main (string[] args)
		{

			UIApplication.Main (args, null, "AppDelegate");
		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			Menu = new SlideoutNavigationController();
			Menu.MainViewController = new MainNavigationController(new RootViewController(), Menu);
			Menu.MenuViewController = new MenuNavigationController(new DummyControllerLeft(), Menu) { NavigationBarHidden = true };
			//Menu.MenuViewController = new MenuNavigationController(new MenuView(), Menu) { NavigationBarHidden = true };
			window.RootViewController = Menu;
			window.MakeKeyAndVisible ();

			return true;
		}
	}

	public class DummyControllerLeft : DialogViewController
	{
		UISearchBar searchBar;

		public DummyControllerLeft () : base(UITableViewStyle.Plain,new RootElement(""))
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			searchBar = new UISearchBar (new RectangleF (0, 0, 290, 44)) {
				ShowsScopeBar = true,
			};

			searchBar.Placeholder ="Busqueda de promociones";

			//View.Add(searchBar);
			Root.Add (new Section () {
				new StyledStringElement("Inicio", () => NavigationController.PushViewController(new RootViewController(), true)) { TextColor = UIColor.Black, BackgroundColor = UIColor.Clear },
				new StyledStringElement("iBeacon", () => NavigationController.PushViewController(new CategoViewController(), true)) { TextColor = UIColor.Black, BackgroundColor = UIColor.Clear },
				new StyledStringElement("Favoritos", () => NavigationController.PushViewController(new FavorViewController(), true)) { TextColor = UIColor.Black, BackgroundColor = UIColor.Clear },
				new StyledStringElement("Ayuda", () => NavigationController.PushViewController(new AyudaViewController(), true)) { TextColor = UIColor.Black, BackgroundColor = UIColor.Clear },
			});
	
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

		}
				

	}
}
