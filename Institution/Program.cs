class Program
{
    public static void Main(string[] args)
    {
        Institution[] instArray = new Institution[4];
        for (int i = 0; i < 4; i++)
        {
            int institutionId = Convert.ToInt32(Console.ReadLine());
            string institutionName = Console.ReadLine();
            string noOfStudentsPlaced = Console.ReadLine();
            int noOfStudentsCleared = Convert.ToInt32(Console.ReadLine());
            string location = Console.ReadLine();
            instArray[i] = new Institution(institutionId, institutionName, noOfStudentsPlaced, noOfStudentsCleared, location);
        }
        string tarlocation = Console.ReadLine();
        string tarinstitutionName = Console.ReadLine();

        int noOfClearance = findNumClearancedByLoc(instArray, tarlocation);
        if (noOfClearance != 0)
        {
            Console.WriteLine(noOfClearance);
        }
        else
        {
            Console.WriteLine("There are no cleared students in this particular location");
        }

        Institution updated = updateInstitutionGrade(instArray, tarinstitutionName);

        if (updated != null)
        {
            Console.WriteLine(updated.institutionName + "::" + updated.grade);
        }
        else
        {
            Console.WriteLine("No Institute is available with the specified name");
        }
    }

    public static int findNumClearancedByLoc(Institution[] instArray, string location)
    {
        int noOfClearance = 0;
        for (int i = 0; i < instArray.Length; i++)
        {
            if (instArray[i].location.Equals(location))
            {
                noOfClearance += instArray[i].noOfStudentsCleared;
            }
        }
        return noOfClearance;
    }

    public static Institution updateInstitutionGrade(Institution[] instArray, string instName)
    {
        for (int i = 0; i < instArray.Length; i++)
        {
            if (instArray[i].institutionName.Equals(instName))
            {
                int rating = ((Convert.ToInt32(instArray[i].noOfStudentsPlaced) * 100) / instArray[i].noOfStudentsCleared);
                if (rating >= 80) instArray[i].setGrade("A");
                else instArray[i].setGrade("B");
                return instArray[i];
            }
        }
        return null;
    }
}

class Institution
{
    public int institutionId;
    public string institutionName;
    public string noOfStudentsPlaced;
    public int noOfStudentsCleared;
    public string location;
    public string grade;

    public Institution(int institutionId, string institutionName, string noOfStudentsPlaced, int noOfStudentsCleared, string location)
    {
        this.institutionId = institutionId;
        this.institutionName = institutionName;
        this.noOfStudentsPlaced = noOfStudentsPlaced;
        this.noOfStudentsCleared = noOfStudentsCleared;
        this.location = location;
    }

    public void setGrade(string grade)
    {
        this.grade = grade;
    }
}