class Program
{
    public static void Main(string[] args)
    {
        Movie[] movies = new Movie[4];
        for (int i = 0; i < 4; i++)
        {
            movies[i] = new Movie(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
        }
        string searchGenre = Console.ReadLine();
        Movie[] result = getMovieByGenre(movies, searchGenre);
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i].budget > 80000000)
                Console.WriteLine("High Budget Movie");
            else
                Console.WriteLine("Low Budget Movie");
        }
    }

    public static Movie[] getMovieByGenre(Movie[] movies, string searchGenre)
    {
        Movie[] refined = new Movie[0];
        for (int i = 0; i < 4; i++)
        {
            if (movies[i].genre.Equals(searchGenre))
            {
                Array.Resize(ref refined,refined.Length + 1);
                refined[refined.Length - 1] = movies[i];
            }
        }
        return refined;
    }
}

class Movie
{
    public string movieName;
    public string company;
    public string genre;
    public int budget;

    public Movie(string movieName, string company, string genre, int budget)
    {
        this.movieName = movieName;
        this.company = company;
        this.genre = genre;
        this.budget = budget;
    }
}