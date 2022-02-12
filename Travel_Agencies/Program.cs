
namespace selva
{
    class Program
    {
        public static void Main(string[] args)
        {
            TravelAgencies[] ta = new TravelAgencies[4];
            for (int i = 0; i < ta.Length; i++)
            {
                int regNo = Convert.ToInt32(Console.ReadLine());
                string agencyName = Console.ReadLine();
                string packageType = Console.ReadLine();
                int price = Convert.ToInt32(Console.ReadLine());
                bool flightFacility = Convert.ToBoolean(Console.ReadLine());
                ta[i] = new TravelAgencies(regNo, agencyName, packageType, price, flightFacility);
            }

            int targetRegNo = Convert.ToInt32(Console.ReadLine());
            string targetPackageType = Console.ReadLine();

            int highestPrice = findAgencyWithHighestPackagePrice(ta);
            TravelAgencies taa = agencyDetailsForGivenldAndType(ta, targetRegNo, targetPackageType);

            Console.WriteLine(highestPrice);
            if(taa==null)
            {
                Console.WriteLine("Not avaliable");
            }
            else
            {
                Console.WriteLine(taa.agencyName + ":" + taa.price);
            }

        }

        public static int findAgencyWithHighestPackagePrice(TravelAgencies[] t)
        {
            int prices = t[0].price;
            for (int i = 1; i < t.Length; i++)
            {
                if (t[i].price > prices)
                {
                    prices = t[i].price;
                }
            }
            return prices;
        }
        public static TravelAgencies agencyDetailsForGivenldAndType(TravelAgencies[] t,int targetRegNo,string targetPackageType)
        {
            for(int i=0;i< t.Length; i++)
            {
                if(t[i].flightFacility)
                {
                    if((t[i].regNo == targetRegNo)&&(t[i].packageType.Equals(targetPackageType)))
                    {
                        return t[i];
                    }
                }
            }
            return null;
        }
    }

    class TravelAgencies
    {
        public int regNo;
        public string agencyName;
        public string packageType;
        public int price;
        public bool flightFacility;
        public TravelAgencies(int regNo, string agencyName, string packageType, int price, bool flightFacility)
        {
            this.regNo = regNo;
            this.agencyName = agencyName;
            this.packageType = packageType;
            this.price = price;
            this.flightFacility = flightFacility;
        }
    }
}