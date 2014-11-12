using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.SlideoutNavigation;
using MonoTouch.Dialog;
using System.Drawing;


namespace NearBuy
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		public SlideoutNavigationController Menu { get; private set; }
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			Menu = new SlideoutNavigationController();
			Menu.MainViewController = new MainNavigationController(new RootViewController(), Menu);
			Menu.MenuViewController = new MenuNavigationController(new MenuView(), Menu) { NavigationBarHidden = true };
			window.RootViewController = Menu;
			window.MakeKeyAndVisible ();

			return true;
		}
	}

	public class DummyControllerLeft : DialogViewController
	{
		public DummyControllerLeft () : base(UITableViewStyle.Plain,new RootElement(""))
		{
			//UITableViewStyle.Plain,new RootElement("")
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			/*
			var frame1 = new Rectangle (10,10,240,30);
			//var txtSearch = new UITextField (frame1);
			Root.Add (new Section () {
				new UITextField(frame1){Placeholder = "Busqueda", BorderStyle = UITextBorderStyle.RoundedRect},
				new StyledStringElement("Inicio", () => NavigationController.PushViewController(new RootViewController(), true)) { TextColor = UIColor.Black, BackgroundColor = UIColor.Clear },
				new StyledStringElement("Categorias", () => NavigationController.PushViewController(new CategoViewController(), true)) { TextColor = UIColor.Black, BackgroundColor = UIColor.Clear },
				new StyledStringElement("Favoritos", () => NavigationController.PushViewController(new FavorViewController(), true)) { TextColor = UIColor.Black, BackgroundColor = UIColor.Clear },
				new StyledStringElement("Ayuda", () => NavigationController.PushViewController(new AyudaViewController(), true)) { TextColor = UIColor.Black, BackgroundColor = UIColor.Clear },
			});
	
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			*/

			//var img = new UIImageView(UIImage.FromFile("galaxy.png"));
			//TableView.BackgroundView = img;

		}
	}
}
