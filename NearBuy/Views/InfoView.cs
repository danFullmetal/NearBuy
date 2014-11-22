﻿
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
		public static int favorite = 0;

		public string dateFormat = "MM/dd/yyyy hh:mm:ss";


		public InfoView(JsonPromos jsonPromos){
			this.jsonPromos = jsonPromos;
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

				
			InsertUI();


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
			var attrString = new NSAttributedString("$"+jsonPromos.precio.ToString(),new UIStringAttributes { StrikethroughStyle = NSUnderlineStyle.Single });
			lbTituloPromo.Text = jsonPromos.titulo;
			txtDescr.Text = jsonPromos.descripcion;
			lbPrecioA.AttributedText = attrString;
			lbPrecioB.Text = (jsonPromos.descuento*100).ToString()+"%";
			lbPrecioTotal.Text = "$"+(jsonPromos.precio-(jsonPromos.precio*jsonPromos.descuento)).ToString();
			_btnFav.SetImage(UIImage.FromFile ("star-grey45.png"), UIControlState.Normal);
			_btnFav.SetImage(UIImage.FromFile ("star-gold45.png"), UIControlState.Highlighted);
			_btnFav.TouchUpInside += delegate {

				if(favorite == 0){
					_btnFav.SetImage(UIImage.FromFile ("star-gold45.png"), UIControlState.Normal);
					favorite = 1;
				}else{
					_btnFav.SetImage(UIImage.FromFile ("star-grey45.png"), UIControlState.Normal);
					favorite = 0;
				}
			};
		}

		public async void InsertUIImage ()
		{
			string imagenURL = "http://www.codecags.com/Img/missingImage.png";
			uiImagePromo.Image = await this.LoadImage (imagenURL);
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

