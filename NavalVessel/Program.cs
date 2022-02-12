class Program
{
    public static void Main(string[] args)
    {
 
        NavalVessel[] navalVessels = new NavalVessel[4];
        for (int i = 0; i < navalVessels.Length; i++)
        {
            int vesselId = Convert.ToInt32(Console.ReadLine());
            string vesselName = Console.ReadLine();
            int noOfVoyagesPlanned = Convert.ToInt32(Console.ReadLine());
            int noOfVoyagesCompleted = Convert.ToInt32(Console.ReadLine());
            string purpose = Console.ReadLine();
            navalVessels[i] = new NavalVessel(vesselId, vesselName, noOfVoyagesPlanned, noOfVoyagesCompleted, purpose.ToLower());
        }
        int searchPercentageValue = Convert.ToInt32(Console.ReadLine());
        string searchPurposeValue = Console.ReadLine();
        int avgOfVoyagesCompleted = findAvgVoyagesByPct(navalVessels, searchPercentageValue);

        if (avgOfVoyagesCompleted > 0)
            Console.WriteLine(avgOfVoyagesCompleted);
        else
            Console.WriteLine("There are no voyages completed with this percentage");

        NavalVessel navalvessel = findVesselByGrade(navalVessels, searchPurposeValue.ToLower());
        if (navalvessel == null)
            Console.WriteLine("No Naval Vessel is available with the specified purpose");
        else
            Console.WriteLine(navalvessel.vesselName + "%" + navalvessel.classification);
    }

    public static int findAvgVoyagesByPct(NavalVessel[] navalVessels, int searchPercentageValue)
    {
        int avg = 0, count = 0;
        for (int i = 0; i < navalVessels.Length; i++)
        {
            int percent = (navalVessels[i].noOfVoyagesCompleted * 100) / navalVessels[i].noOfVoyagesPlanned;
            if (percent >= searchPercentageValue)
            {
                avg += navalVessels[i].noOfVoyagesCompleted;
                count++;
            }
        }
        if (avg == 0)
            return 0;
        else
            return avg / count;
    }

    public static NavalVessel findVesselByGrade(NavalVessel[] navalVessels, string searchPurposeValue)
    {
        for (int i = 0; i < navalVessels.Length; i++)
        {
            if (searchPurposeValue.Equals(navalVessels[i].purpose))
            {
                int percentage = (navalVessels[i].noOfVoyagesCompleted * 100) / navalVessels[i].noOfVoyagesPlanned;
                if (percentage == 100) navalVessels[i].setClassification("Star");
                else if (percentage >= 80 && percentage <= 99) navalVessels[i].setClassification("Leader");
                else if (percentage >= 55 && percentage <= 79) navalVessels[i].setClassification("Inspirer");
                else
                    navalVessels[i].setClassification("Striver");
                return navalVessels[i];
            }
        }
        return null;
    }
}

class NavalVessel
{
    public int vesselId, noOfVoyagesPlanned, noOfVoyagesCompleted;
    public string vesselName, purpose, classification;
    public NavalVessel(int vesselId, string vesselName, int noOfVoyagesPlanned, int noOfVoyagesCompleted, string purpose)
    {
        this.vesselId = vesselId;
        this.vesselName = vesselName;
        this.noOfVoyagesPlanned = noOfVoyagesPlanned;
        this.noOfVoyagesCompleted = noOfVoyagesCompleted;
        this.purpose = purpose;
    }

    public void setClassification(string classification)
    {
        this.classification = classification;
    }
}