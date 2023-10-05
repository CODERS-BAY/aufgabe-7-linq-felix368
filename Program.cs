using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace LinqExercise;

/*
 * your tests here
 */


class Tests()
{
    static void Main(string[] args)
    {
        var filmOp = new FilmOperations();


        Console.WriteLine("------directorFilms-----");
        var directorFilms = filmOp.GetMoviesByDirector("Francis Ford Coppola");
        foreach (var movie in directorFilms)
        {
            Console.WriteLine(movie.title);
        }


        Console.WriteLine("------yearMovies-----");
        var yearMovies = filmOp.GetMoviesByYear(1994);
        foreach (var movie in yearMovies)
        {
            Console.WriteLine(movie.title);
        }


        Console.WriteLine("-----ratingMovis-----");
        var ratingMovis = filmOp.GetMoviesByRatingRange(5, 8);
        foreach (var movie in ratingMovis)
        {
            Console.WriteLine(movie.title);
        }


        Console.WriteLine("-----sortedMovies----");
        var sortedMovies = filmOp.GetMoviesByRatingSortedLimited(5);
        foreach (var movie in sortedMovies)
        {
            Console.WriteLine(movie.rating);
        }


    }
}





