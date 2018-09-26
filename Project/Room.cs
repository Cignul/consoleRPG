using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    //method for changing room if exit is an available choice (needs logic still)
    public void changeRoom()
    {

    }
    //method to take an item from a room (needs logic)
    public void takeItem()
    {

    }
  }
}
