class Program
{
    public static void Main(string[] args)
    {
        Sim[] sim = new Sim[4];
        for (int i = 0; i < 4; i++)
        {
            sim[i] = new Sim(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Console.ReadLine());
        }
        string search_circle = Console.ReadLine();
        double search_rate = Convert.ToDouble(Console.ReadLine());
        Sim[] result = matchAndSort(sim, search_circle, search_rate);
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i].id);
        }
    }

    public static Sim[] matchAndSort(Sim[] sim, string search_circle, double search_rate)
    {
        Sim[] refined = new Sim[0];
        for (int i = 0; i < sim.Length; i++)
        {
            if ((sim[i].circle).Equals(search_circle) && (sim[i].ratePerSecond < search_rate))
            {
                Array.Resize(ref refined, refined.Length + 1);
                refined[refined.Length - 1] = sim[i];
            }
        }
        for (int i = 0; i < refined.Length - 1; i++)
        {
            for (int j = 0; j < refined.Length - i - 1; j++)
            {
                if (refined[j].balance < refined[j + 1].balance)
                {
                    Sim temp = refined[j];
                    refined[j] = refined[j + 1];
                    refined[j + 1] = temp;
                }

            }
        }
        return refined;
    }
}

class Sim
{
    public int id;
    public string company;
    public int balance;
    public double ratePerSecond;
    public string circle;

    public Sim(int id, string company, int balance, double ratePerSecond, string circle)
    {
        this.id = id;
        this.company = company;
        this.balance = balance;
        this.ratePerSecond = ratePerSecond;
        this.circle = circle;
    }
}