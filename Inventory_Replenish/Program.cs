class Program
{
    public static void Main(string[] args)
    {
        Inventory[] inventories = new Inventory[4];
        for (int i = 0; i < inventories.Length; i++)
        {
            string inventoryId = Console.ReadLine();
            int maximumQuantity = Convert.ToInt32(Console.ReadLine());
            int currentQuantity = Convert.ToInt32(Console.ReadLine());
            int threshold = Convert.ToInt32(Console.ReadLine());
            inventories[i] = new Inventory(inventoryId, maximumQuantity, currentQuantity, threshold);
        }
        int limit = Convert.ToInt32(Console.ReadLine());
        Inventory[] result = replenish(inventories, limit);
        for (int i = 0; i < result.Length; i++)
        {
            if(result[i] != null)
            {
                if (result[i].threshold >= 75)
                    Console.WriteLine(result[i].inventoryId + " Critical Filling");
                else if (result[i].threshold >= 50 && result[i].threshold <= 74)
                    Console.WriteLine(result[i].inventoryId + " Moderate Filling");
                else
                    Console.WriteLine(result[i].inventoryId + " Non-Critical Filling");
            }
        }
    }
    public static Inventory[] replenish(Inventory[] inventories, int limit)
    {
        Inventory[] refined = new Inventory[inventories.Length];
        for (int i = 0; i < inventories.Length; i++)
        {
            if (inventories[i].threshold <= limit)
            {
                
                refined[i] = inventories[i];
            }
            else
            {
                refined[i] = null;
            }
        }
        return refined;
    }
}

class Inventory
{
    public string inventoryId;
    public int maximumQuantity;
    public int currentQuantity;
    public int threshold;
    public Inventory(string inventoryId, int maximumQuantity, int currentQuantity, int threshold)
    {
        this.inventoryId = inventoryId;
        this.maximumQuantity = maximumQuantity;
        this.currentQuantity = currentQuantity;
        this.threshold = threshold;
    }
}