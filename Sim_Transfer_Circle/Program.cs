class Program
{
    public static void Main(string[] args)
    {
        Sim[] sim = new Sim[5];
        for (int i = 0; i < 5; i++)
        {
            int simId = Convert.ToInt32(Console.ReadLine());
            string customerName = Console.ReadLine();
            double balance = Convert.ToDouble(Console.ReadLine());
            double ratePerSecond = Convert.ToDouble(Console.ReadLine());
            string circle = Console.ReadLine();
            sim[i] = new Sim(simId, customerName, balance, ratePerSecond, circle);
        }
        string circle1 = Console.ReadLine();
        string circle2 = Console.ReadLine();
        Sim[] result = transferCircle(sim, circle1, circle2);
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i].simId + " " + result[i].customerName + " " + result[i].circle + " " + result[i].ratePerSecond);
        }
    }
    public static Sim[] transferCircle(Sim[] sim, string circle1, string circle2)
    {
        Sim[] refined = new Sim[0];
        for (int i = 0; i < 5; i++)
        {
            if (sim[i].circle.Equals(circle1))
            {
                Array.Resize(ref refined, refined.Length + 1);
                refined[refined.Length - 1] = sim[i];
                refined[refined.Length - 1].setCircle(circle2);
            }
        }
        for (int i = 0; i < refined.Length - 1; i++)
        {
            for (int j = 0; j < refined.Length - 1 - i; j++)
            {
                if (refined[j].ratePerSecond < refined[j + 1].ratePerSecond)
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
    public int simId;
    public string customerName;
    public double balance;
    public double ratePerSecond;
    public string circle;

    public void setCircle(string circle)
    {
        this.circle = circle;
    }
    public Sim(int simId, string customerName, double balance, double ratePerSecond, string circle)
    {
        this.simId = simId;
        this.ratePerSecond = ratePerSecond;
        this.customerName = customerName;
        this.circle = circle;
        this.balance = balance;
    }
}