
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using BigTed;
using MonoTouch.CoreFoundation;
using MonoTouch.AddressBook;
using System.Runtime.Serialization;
using SQLite;



namespace NearBuy
{

	public partial class InfoView : UIViewController
	{
		JsonPromos jsonPromos;
		public string promoImage;
		public string hora;
		public DateTime tiempoAhora;
		public TimeSpan tiempoRestante;
		public DateTime labelDate;
		public float descuentos;
		public string tiempos;
		public static int favorite;

		public SQLiteConnection db;

		public string dateFormat = "MM/dd/yyyy hh:mm:ss";


		public InfoView(JsonPromos jsonPromos){
			this.jsonPromos = jsonPromos;
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				"favorites.db3");
			db = new SQLiteConnection (dbPath);
			db.CreateTable<Favorites> ();
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
			printElements ();
			InsertUI();


		}

		//Test Number of elements on table
		public void printElements(){
			var table = db.Table<Favorites> ();
			foreach (var s in table) {
				Console.WriteLine ("Id: " + s.Id + ", Nombre:" + s.titulo);
			}
		}
		public void InsertUI (){

			this.Title = jsonPromos.titulo;

			/*
			promoImage = jsonPromos.imagen;
			byte[] bytes = Convert.FromBase64String (promoImage);
			NSData data = NSData.FromArray (bytes);
			var uiImage = UIImage.LoadFromData (data);
			uiImagePromo.Image = uiImage;

			*/
			//tiempoAhora = DateTime.Now;
			//DateTime tiempoRestante = (jsonPromos.fechaVencimiento - tiempoAhora).TotalDays;



			NSTimer timer = NSTimer.CreateRepeatingScheduledTimer (TimeSpan.FromSeconds(0.1), delegate {

				tiempoAhora = DateTime.Now;
				if(tiempoAhora < jsonPromos.fechaVencimiento){
					tiempoRestante = (jsonPromos.fechaVencimiento - tiempoAhora);
					tiempos = String.Format("{0} dias, {1}:{2}:{3}", 
						tiempoRestante.Days, tiempoRestante.Hours, tiempoRestante.Minutes, tiempoRestante.Seconds);
					//lbTimer.Text = tiempos;
					//lbCountdown.Text = tiempos;
					btnCountdown.Title = tiempos;
				}else{
					btnCountdown.Title = "Promocion finalizada";
				}
			});

			timer.Fire();
			InsertUIImage();
			loadLocalDatabase ();
			var attrString = new NSAttributedString("$"+jsonPromos.precio.ToString(),new UIStringAttributes { StrikethroughStyle = NSUnderlineStyle.Single });
			lbTituloPromo.Text = jsonPromos.titulo;
			txtDescr.Text = jsonPromos.descripcion;
			lbPrecioA.AttributedText = attrString;
			lbPrecioB.Text = (jsonPromos.descuento*100).ToString()+"%";
			lbPrecioTotal.Text = "$"+(jsonPromos.precio-(jsonPromos.precio*jsonPromos.descuento)).ToString();
			Favorites fav = null;
			try{
				fav = db.Get<Favorites>(jsonPromos.idPromocion);
			}
			catch(Exception ex){
				Console.WriteLine ("Fav no existente: {0}", ex.StackTrace);
				_btnFav.SetImage(UIImage.FromFile ("star-grey45.png"), UIControlState.Normal);
				favorite = 0;
			}

			if(fav != null){
				Console.WriteLine ("Fav existente ");
				_btnFav.SetImage(UIImage.FromFile ("star-gold45.png"), UIControlState.Normal);
				favorite = 1;
			}

			_btnFav.SetImage(UIImage.FromFile ("star-gold45.png"), UIControlState.Highlighted);
			_btnFav.TouchUpInside += delegate {
				var newFav = new Favorites (jsonPromos.idPromocion, jsonPromos.titulo);
				if(favorite == 0){
					_btnFav.SetImage(UIImage.FromFile ("star-gold45.png"), UIControlState.Normal);
					favorite = 1;
					newFav.Id = jsonPromos.idPromocion;
					var rowcount = db.Insert (newFav);; 
					Console.WriteLine ("Fav agregado {0}", rowcount);
				}else{
					_btnFav.SetImage(UIImage.FromFile ("star-grey45.png"), UIControlState.Normal);
					favorite = 0;
					var rowcount = db.Delete<Favorites>(newFav.Id);
					Console.WriteLine ("Fav eliminado, afectados: {0} ", rowcount);
				}
			};
		}



		public void loadLocalDatabase() {
			db.CreateTable<Favorites> ();
		}

		public async void InsertUIImage ()
		{
			if(jsonPromos.imagen == null){
				string imagenURL = "http://www.codecags.com/Img/missingImage.png";
				uiImagePromo.Image = await this.LoadImage (imagenURL);
				BTProgressHUD.Dismiss();
			}else{
				string imagenURL = "http://www.codecags.com/Img/";
				imagenURL+=jsonPromos.imagen;
				uiImagePromo.Image = await this.LoadImage (imagenURL);
				BTProgressHUD.Dismiss();
			}
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

