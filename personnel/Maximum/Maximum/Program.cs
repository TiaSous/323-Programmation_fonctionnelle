// 4 players
List<Player> players = new List<Player>()
{
    new Player("Joe", 32),
    new Player("Jack", 30),
    new Player("William", 37),
    new Player("Averell", 25)
};

// Initialize search
Player elder = Search(players);

// search
//foreach (Player p in players)
//{
//    if (p.Age > biggestAge) // memorize new elder
//    {
//        elder = p;
//        biggestAge = p.Age; // for future loops
//    }
//}

Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");

Console.ReadKey();

Player Search(List<Player> listOfPlayer)
{
    List<Player> aggestPlayer = [listOfPlayer[0]];
    foreach (Player p in listOfPlayer)
    {
       if(aggestPlayer.First().Age < p.Age)
        {
            aggestPlayer.Clear();
            aggestPlayer.Add(p);
        }
    }
    return aggestPlayer.First();
}

public class Player
{
    private readonly string _name;
    private readonly int _age;

    public Player(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public string Name => _name;

    public int Age => _age;
}