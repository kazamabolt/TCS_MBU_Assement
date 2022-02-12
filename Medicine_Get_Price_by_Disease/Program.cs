class Program
{
    public static void Main(string[] args)
    {
        Medicine[] medicines = new Medicine[4];
        for (int i = 0; i < medicines.Length; i++)
        {
            string MedicineName=Console.ReadLine();
            string batch = Console.ReadLine(); 
            string disease = Console.ReadLine();
            int price = Convert.ToInt32(Console.ReadLine());
            medicines[i] = new Medicine(MedicineName,batch,disease.ToLower(),price);
        }
        string tardisease = Console.ReadLine(); 
 
        int[] result = getPriceByDisease(medicines, tardisease);
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
    public static int[] getPriceByDisease(Medicine[] medicines, string disease)
    {
        int[] result = new int[0];
        for (int i = 0; i < medicines.Length; i++)
        {
            if (medicines[i].disease.Equals(disease.ToLower()))
            {
                Array.Resize(ref result, result.Length+1);
                result[result.Length-1] = medicines[i].price;
            }
            Array.Sort(result);
        }
        return result;
    }
}

class Medicine
{
    public string MedicineName;
    public string batch;
    public string disease;
    public int price;

    public Medicine(string medicineName, string batch, string disease, int price)
    {
        this.MedicineName = medicineName;
        this.batch = batch;
        this.disease = disease;
        this.price = price;
    }
}