using System.Collections.Generic;

List<Movie> frenchMovies = new List<Movie>() {
new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
};

// exo 1
List<Movie> notDramaOrComedie = frenchMovies.Where(x => x.Genre != "Comédie" && x.Genre != "Drama").ToList();

// exo 2
List<Movie> ratingLessSeven = frenchMovies.Where(x => x.Rating < 7).ToList();

// exo 3
List<Movie> avantDeuxMilles = frenchMovies.Where(x => x.Year < 2000).ToList();

// exo 4
List<Movie> notFrench = frenchMovies.Where(x => !x.LanguageOptions.Contains("Français")).ToList();

// exo 5
List<Movie> notNetflix = frenchMovies.Where(x => !x.StreamingPlatforms.Contains("Netflix")).ToList();

// version 2 cumul
List<Movie> cumul = frenchMovies.Where(x => !x.Genre.Equals("Comédie") && x.Genre != "Drama" && x.Rating < 7 && x.Year < 2000 && !x.LanguageOptions.Contains("Français") && !x.StreamingPlatforms.Contains("Netflix")).ToList();

foreach (var item in cumul)
{
    Console.WriteLine(item.Title);
}

// version 3 dynamique
Console.WriteLine("Retirer les films de types ");

public class Movie
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public int Year { get; set; }
    public string[] LanguageOptions { get; set; }
    public string[] StreamingPlatforms { get; set; }
    // Constructeur sans paramètres
    public Movie() { }

    // Constructeur avec paramètres
    public Movie(string title, string genre, double rating, int year, string[] languageOptions, string[] streamingPlatforms)
    {
        Title = title;
        Genre = genre;
        Rating = rating;
        Year = year;
        LanguageOptions = languageOptions;
        StreamingPlatforms = streamingPlatforms;
    }
}

