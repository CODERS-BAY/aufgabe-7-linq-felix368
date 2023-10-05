using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;

namespace LinqExercise;

public class FilmOperations
{
    List<Film> filmList;

    public FilmOperations()
    {
        filmList = GetAllMovies();
    }


    /// <returns>eine Liste aller Filme zurück.</returns>
    public List<Film> GetAllMovies()
    {
        var reader = new StreamReader(@"D:\felix\programiren\codersBay\cs\linq\films.json");
        var json = reader.ReadToEnd();
        var list = json.ToList();
        var result = new List<Film>();

        filmList = JsonConvert.DeserializeObject<List<Film>>(json);
        Film myFilm = filmList[2];
        return filmList; 
    }

    /// <returns>ein Array von Filmen zurück, die von dem angegebenen Regisseur stammen.</returns>
    public Film[] GetMoviesByDirector(string directorName)
    {
        var result = from film in filmList
                     where film.director == directorName
                     select film;

        return result.ToArray();
    }

    /// <returns>ein Array von Filmen zurück, die im angegebenen Erscheinungsjahr veröffentlicht wurden.</returns>
    public Film[] GetMoviesByYear(int releaseYear)
    {
        var result = from film in filmList 
                     where film.releaseYear == releaseYear 
                     select film;
        return result.ToArray();
    }
   
    /// <returns>ein Array von Filmen zurück, die zwischen der angegebenen Mindest- und Höchstbewertung liegen.</returns>
    public Film[] GetMoviesByRatingRange(double minRating, double maxRating)
    {
        if (minRating > maxRating)
        {
            throw new ArgumentException();
        }

        var result = from film in filmList 
                     where film.rating > minRating && film.rating < maxRating 
                     select film;
        return result.ToArray();
    }
    
    /// <returns>gibt ein Array mit den best bewerteten Filme zurück, sortiert nach Bewertung. numberOfFilms gibt die
    /// Anzahl der zurückgegeben Filme an.</returns>
    public Film[] GetMoviesByRatingSortedLimited(int numberOfFilms)
    {
        var result = (from film in filmList
                      orderby film.rating descending 
                      select film).Take(numberOfFilms);

        return result.ToArray();
    }
}