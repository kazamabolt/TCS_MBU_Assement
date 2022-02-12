
namespace selva
{
    class Program
    {
        public static void Main(string[] args)
        {
            Player[] pl = new Player[4];
            for (int i = 0; i < 4; i++)
            {
                int id = Convert.ToInt32(Console.ReadLine());
                string name = Console.ReadLine();
                string iccRank=Console.ReadLine();
                int matchPlayed = Convert.ToInt32(Console.ReadLine());
                int runs = Convert.ToInt32(Console.ReadLine());
                pl[i] = new Player(id, name,iccRank, matchPlayed, runs);
            }

            int target = Convert.ToInt32(Console.ReadLine());

            double[] average = findAvg(pl, target);

            for (int i = 0; i < average.Length; i++)
            {
                if (average[i] >= 80 && average[i] <= 100)
                {
                    Console.WriteLine(pl[i].name + ":Grade A");
                }
                else if (average[i] >= 50 && average[i] <= 79)
                {
                    Console.WriteLine(pl[i].name + ":Grade B");
                }
                else if (average[i] >= 1 && average[i] <= 49)
                {
                    Console.WriteLine(pl[i].name + ":Grade C");
                }
            }
        }

        public static double[] findAvg(Player[] p,int target)
        {
            double[] average = new double[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].matchPlayed >= target)
                {
                    average[i] = (p[i].runs / p[i].matchPlayed);
                }
                else
                {
                    average[i] = 0;
                }
            }
            return average;
        }
    }

    class Player
    {
        public int id;
        public string name;
        public string iccRank;
        public int matchPlayed;
        public int runs;

        public Player(int id, string name,string iccRank, int matchPlayed, int runs)
        {
            this.id = id;
            this.name = name;
            this.iccRank = iccRank;
            this.matchPlayed = matchPlayed;
            this.runs = runs;
        }
    }
}