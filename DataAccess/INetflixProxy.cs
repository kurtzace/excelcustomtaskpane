using System;
using System.Collections.Generic;

namespace DataAccess
{
	public interface INetflixProxy
	{
		List<DataAccess.Netflix.Title> GetFilms(string title);
		List<Netflix.Title> GetTitlesFromPeople(Netflix.Person p);
		List<DataAccess.Netflix.Person> GetPeople(string name);
		IEnumerable<DataAccess.Netflix.Genre> GetGenres();
		List<Netflix.Genre> GetGenresFromTitle(Netflix.Title title);
	}
}
