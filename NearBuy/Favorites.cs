using System;
using SQLite;

namespace NearBuy
{
	public class Favorites
	{
		[PrimaryKey]
		public int Id { get; set; }
		public string titulo { get; set; }
		public Favorites ()
		{
		}
		public Favorites (int id, string titulo)
		{
			this.Id = id;
			this.titulo = titulo;
		}
	}
}


