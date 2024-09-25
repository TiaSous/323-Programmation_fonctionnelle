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


Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");
///////////////////////////////////////////////////////////version immutable/////////////////////////////////////////////////
// va chercher le joueur le plus agées
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
///////////////////////////////////////////////////////////version Linq/////////////////////////////////////////////////
// va chercher le joueur le plus agées
Player elder2 = players.Aggregate((current, next) => current.Age < next.Age ? next : current);

Console.WriteLine($"Le plus agé est {elder2.Name} qui a {elder2.Age} ans");

Console.ReadKey();
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