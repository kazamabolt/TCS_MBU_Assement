class Program
{
    public static void Main(string[] args)
    {
        Player[] players = new Player[4];
        for (int i = 0; i < players.Length; i++)
        {
            int playerId = Convert.ToInt32(Console.ReadLine());
            string skill = Console.ReadLine();
            string level = Console.ReadLine();
            int points = Convert.ToInt32(Console.ReadLine());
            players[i] = new Player(playerId, skill.ToLower(), level.ToLower(), points);
        }
        string newskill = Console.ReadLine();
        string newlevel = Console.ReadLine();
        int totalPoints = findPointsForGivenSkill(players, newskill.ToLower());
        Player chosenOne = getPlayerBasedOnLevel(players, newskill.ToLower(), newlevel.ToLower());
        if (totalPoints > 0)
            Console.WriteLine(totalPoints);
        else
            Console.WriteLine("The given Skill is not available");
        if (chosenOne == null)
            Console.WriteLine("No player is available with specified level, skill and eligibility points");
        else
            Console.WriteLine(chosenOne.playerId);
    }

    public static int findPointsForGivenSkill(Player[] players, string skill)
    {
        int points = 0;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].skill.Equals(skill))
                points = points + players[i].points;
        }
        return points;
    }

    public static Player getPlayerBasedOnLevel(Player[] players, string skill, string level)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].skill.Equals(skill) && players[i].level.Equals(level))
            {
                if (players[i].points >= 20)
                    return players[i];
            }
        }
        return null;
    }
}

class Player
{
    public int playerId;
    public string skill;
    public string level;
    public int points;

    public Player(int playerId, string skill, string level, int points)
    {
        this.playerId = playerId;
        this.skill = skill;
        this.level = level;
        this.points = points;
    }
}