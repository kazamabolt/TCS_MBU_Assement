class Program
{
    public static void Main(string[] args)
    {
        Movie[] movies = new Movie[4];
        for (int i = 0; i < 4; i++)
        {
            int movieId = Convert.ToInt32(Console.ReadLine());
            string director = Console.ReadLine();
            int rating = Convert.ToInt32(Console.ReadLine());
            int budget = Convert.ToInt32(Console.ReadLine());
            movies[i] = new Movie(movieId, director.ToLower(), rating, budget);
        }
        string searchDirector = Console.ReadLine();
        int searchRating = Convert.ToInt32(Console.ReadLine());
        int searchBudget = Convert.ToInt32(Console.ReadLine());
        int avgBudget = findAvgBudgetByDirector(movies, searchDirector.ToLower());
        if (avgBudget > 0)
            Console.WriteLine(avgBudget);
        else
            Console.WriteLine("Sorry - The given director has not yet directed any movie");
        Movie resultMovie = getMovieByRatingBudget(movies, searchRating, searchBudget);
        if (resultMovie == null)
            Console.WriteLine("Sorry - No movie is available with the specified rating and budget requirement");
        else
            Console.WriteLine(resultMovie.movieId);

    }

    public static int findAvgBudgetByDirector(Movie[] movies, string searchDirector)
    {
        int avg, s = 0, j = 0;
        for (int i = 0; i < 4; i++)
        {
            if (searchDirector.Equals(movies[i].director))
            {
                s = s + movies[i].budget;
                j++;
            }
        }
        if (j > 0)
        {
            avg = s / j;
            return avg;
        }
        else
            return 0;
    }

    public static Movie getMovieByRatingBudget(Movie[] movies, int rating, int budget)
    {
        for (int i = 0; i < 4; i++)
        {
            if ((rating == movies[i].rating) && (budget == movies[i].budget) && (movies[i].budget % movies[i].rating == 0))
            {
                return movies[i];
            }
        }
        return null;

    }
}

class Movie
{
    public int movieId, rating, budget;
    public string director;

    public Movie(int movieId, string director, int rating, int budget)
    {
        this.movieId = movieId;
        this.director = director;
        this.rating = rating;
        this.budget = budget;
    }
}
