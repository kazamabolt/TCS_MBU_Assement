namespace vignesh
{
    class Program
    {
        public static void Main(string[] args)
        {
            Associate[] a = new Associate[5];
            for (int i = 0; i < a.Length; i++)
            {
                int id=Convert.ToInt32(Console.ReadLine());
                string name=Console.ReadLine();
                string technology=Console.ReadLine();
                int experienceInYears=Convert.ToInt32(Console.ReadLine());
                a[i]=new Associate(id, name, technology, experienceInYears);
            }

            string targetTech=Console.ReadLine();

            Associate[] associates = associatesForGivenTechnology(a, targetTech);
            Console.WriteLine("\n");

            for (int i=0;i<associates.Length;i++)
            {
                if(associates[i]!=null)
                {
                    Console.WriteLine(associates[i].id);
                }
            }
        }


        public static Associate[] associatesForGivenTechnology(Associate[] a,string targeTech)
        {
            Associate[] res=new Associate[a.Length];
            for (int i = 0;i < a.Length;i++)
            {
                if((a[i].technology.Equals(targeTech))&&(a[i].experienceInYears%5==0))
                {
                    res[i] = a[i];
                }
                else
                {
                    res[i] = null;
                }
            }
            return res;
        }
    }


    class Associate
    {
        public int id;
        public string name;
        public string technology;
        public int experienceInYears;

        public Associate(int id, string name,string technology,int experienceInYears)
        {
            this.id = id;
            this.name = name;
            this.technology = technology;
            this.experienceInYears = experienceInYears;
        }
    }
}