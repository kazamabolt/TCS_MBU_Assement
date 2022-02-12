class Program
{
    public static void Main(string[] args)
    {
        Phone[] phones = new Phone[4];
        for (int i = 0; i < 4; i++)
        {
            int id = Convert.ToInt32(Console.ReadLine());
            string os = Console.ReadLine();
            string brand = Console.ReadLine();
            int price = Convert.ToInt32(Console.ReadLine());
            phones[i] = new Phone(id, os.ToLower(), brand, price);
        }
        string searchBrand = Console.ReadLine();
        string searchOS = Console.ReadLine();
        
        int priceResult = findPriceForGivenBrand(phones, searchBrand);
        if (priceResult != 0)
        {
            Console.WriteLine(priceResult);
        }
        else
        {
            Console.WriteLine("The given Brand is not available");
        }
        Phone phoneResult = getPhoneIdBasedOnOs(phones, searchOS.ToLower());
        if (phoneResult != null)
        {
            Console.WriteLine(phoneResult.phoneId);
        }
        else
        {
            Console.WriteLine("No phones are available with specified os and price range");
        }

    }

    public static int findPriceForGivenBrand(Phone[] phones, string brand)
    {
        int price = 0;
        for (int i = 0; i < phones.Length; i++)
        {
            if (phones[i].brand.Equals(brand))
            {
                price += phones[i].price;
            }
        }
        if (price > 0)
            return price;
        else
            return 0;
    }

    public static Phone getPhoneIdBasedOnOs(Phone[] phones, string os)
    {
        Phone temp = null;
        for (int i = 0; i < phones.Length; i++)
        {
            if (phones[i].os.Equals(os) && phones[i].price >= 50000)
            {
                temp = phones[i];
                return temp;
            }
        }
        return temp;
    }
}

class Phone
{
    public int phoneId, price;
    public string os, brand;
    public Phone(int phoneId, string os, string brand, int price)
    {
        this.phoneId = phoneId;
        this.os = os;
        this.brand = brand;
        this.price = price;
    }
}