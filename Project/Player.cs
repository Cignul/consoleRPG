using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Player : IPlayer
  {

    public Player(string name)
    {
      PlayerName = name;
      Inventory = new List<Item>();
    }

    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

  }
}