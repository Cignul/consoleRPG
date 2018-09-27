using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    //creating rooms for game

    //creating an object
    public Item key;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {
      string userInput = Console.ReadLine();

    }

    public void Go(string direction)
    {

    }

    public void Help()
    {
      Console.WriteLine(@"List of Commands:
                        Go <direction>
                        Inventory
                        Look <direction>
                        Quit
                        Reset
                        Take <item>
                        Use <item");

      Console.WriteLine("What would you like to do?");
      string userInput = Console.ReadLine();
      if (userInput == "help" || userInput == "Help" || userInput == "HELP")
      {
        Help();
      }
      if (userInput == "look" || userInput == "Look" || userInput == "LOOK")
      {
        Look();
      }
    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }

    public void Setup()
    {
      //add a better description
      Room Room0 = new Room("Room0", "starting room");
      Room Room1 = new Room("Room1", "this room is a real doozy");
      Room Room2 = new Room("Room2", "stuff is getting real in this room, there is a locked door");
      Room Room3 = new Room("Room3", "almost won you magnificient person, the room is very dark but there appears to be a light switch on your left.");
      Room Room4 = new Room("Room4", "victory you did the thing");
      CurrentRoom = Room0;
      //adding room exit paths
      Room0.Exits.Add("north", Room1);
      Room1.Exits.Add("south", Room0);
      Room1.Exits.Add("east", Room2);
      Room2.Exits.Add("west", Room1);
      Room2.Exits.Add("north", Room3);
      Room3.Exits.Add("south", Room2);
      Room3.Exits.Add("east", Room4);
      Room4.Exits.Add("west", Room3);

      Room3.Items.Add(item: key);
    }

    public void StartGame()
    {
      Setup();

      Console.WriteLine("Welcome to castle Grimtol, keep your head on a swivel");
      Console.WriteLine("Use <Help> for a list of commands");
      string userInput = Console.ReadLine();
      if (userInput == "help" || userInput == "HELP" || userInput == "Help")
      {
        Help();
        userInput = Console.ReadLine();
      }

      if (userInput == "look" || userInput == "LOOK" || userInput == "Look")
      {
        Console.WriteLine(CurrentRoom.Description);
        userInput = Console.ReadLine();
      }

    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }
  }
}