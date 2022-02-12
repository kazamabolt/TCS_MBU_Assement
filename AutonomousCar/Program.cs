namespace vignesh
{
    class Program
    {
        public static void Main(string[] args)
        {
            AutonomusCar[] ac=new AutonomusCar[4];
            for(int i=0;i<ac.Length;i++)
            {
                int cardId=Convert.ToInt32(Console.ReadLine());
                string brand=Console.ReadLine();
                int noOfTestsConducted=Convert.ToInt32(Console.ReadLine());
                int noOfTestsPassed=Convert.ToInt32(Console.ReadLine());
                string environment=Console.ReadLine();
                ac[i] = new AutonomusCar(cardId, brand, noOfTestsConducted, noOfTestsPassed, environment);
            }

            string targetEnv=Console.ReadLine();
            string targetBrand=Console.ReadLine();

            int testPassed = findTestPassedByEnv(ac, targetEnv);
            if (testPassed == 0)
            {
                Console.WriteLine("There are no tests passed in this particular environment");
            }
            else
            {
                Console.WriteLine(testPassed);
            }

            AutonomusCar au = updateCarGrade(ac, targetBrand);
            if(au== null)
            {
                Console.WriteLine("No Car is available with the specified brand");
            }
            else
            {
                Console.WriteLine(au.brand + "::" + au.grade);
            }
        }

        public static int findTestPassedByEnv(AutonomusCar[] a,string targetEnv)
        {
            int sum = 0;
            for(int i=0; i<a.Length;i++)
            {
                if(a[i].environment.Equals(targetEnv))
                {
                    sum+=a[i].noOfTestsPassed;
                }
            }
            return sum;
        }

        public static AutonomusCar updateCarGrade(AutonomusCar[] a,string targetBrand)
        {
            int rating;
            for(int i=0;i<a.Length;i++)
            {
                if(a[i].brand.Equals(targetBrand))
                {
                    rating = (a[i].noOfTestsPassed / a[i].noOfTestsConducted);
                    if(rating >=80)
                    {
                        a[i].setGrade("A1");
                    }
                    else
                    {
                        a[i].setGrade("B2");
                    }
                    return a[i];
                }
            }
            return null;
        }
    }

    class AutonomusCar
    {
        public int carId;
        public string brand;
        public int noOfTestsConducted;
        public int noOfTestsPassed;
        public string environment;
        public string grade;

        public AutonomusCar(int carId,string brand, int noOfTestsConducted, int noOfTestsPassed, string environment)
        {
            this.carId = carId;
            this.brand = brand;
            this.noOfTestsConducted = noOfTestsConducted;
            this.noOfTestsPassed = noOfTestsPassed;
            this.environment = environment;
        }

        public void setGrade(string grade)
        {
            this.grade = grade;
        }
    }
}