using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Netflix;

namespace DataAccess
{
	public class NetflixProxyStub : INetflixProxy	
	{
		public List<Netflix.Title> GetFilms(string title)
		{
			var rnd = new Random();
			var filmList = new List<Netflix.Title>();
			for (int i = 100 - 1; i >= 0; i--)
			{
				var name = "Film #" + i.ToString();
				var rating = rnd.Next(1, 5).ToString() + " stars";
				var film = new Netflix.Title {Name = name, Rating = rating};
				filmList.Add(film);
			}
			return filmList.Where(f => f.Name.ToLower().Contains(title.ToLower())).ToList();
		}

		public List<Title> GetTitlesFromPeople(Person p)
		{
			var x = new Netflix.Title  { Name = "File Title 1" };
			var y = new Netflix.Title { Name = "File Title 2" };
			var z = new Netflix.Title { Name = "File Title 3" };
			return new List<Netflix.Title> { x, y, z };
		}

		public IEnumerable<Netflix.Genre> GetGenres()
		{
			var x = new Netflix.Genre { Name = "Sports" };
			var y = new Netflix.Genre { Name = "Sports Mockumentary" };
			var z = new Netflix.Genre { Name = "Action/Adventure" };
			return new List<Netflix.Genre> { x, y, z};
		}

		public List<Genre> GetGenresFromTitle(Title title)
		{
			return GetGenres().ToList();
		}

		public List<Netflix.Person> GetPeople(string name)
		{
			var x = new Netflix.Person { Name = "Dilbert" };
			var y = new Netflix.Person { Name = "Bob Dylan" };
			return new List<Netflix.Person> { x, y };
		}
	}
}
