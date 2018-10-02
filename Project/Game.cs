using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    //creating rooms for game

    //creating an object

    bool playing = false;
    Player _player;

    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }


    public void GetUserInput()
    {
      string userInput = Console.ReadLine();

    }

    public void Go(string direction)
    {
      // CurrentRoom = CurrentRoom.Exits(Console.ReadLine("east"));
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
                        Use <item>");

      Console.WriteLine("What would you like to do?");
      string userInput = Console.ReadLine();

      Console.WriteLine(CurrentRoom.Description);
    }

    public void Inventory()
    {
      Console.WriteLine(CurrentPlayer.Inventory);
    }

    public void Look()
    {
      Console.WriteLine(CurrentRoom.Description);
      Console.WriteLine(CurrentRoom.Items);
    }

    public void Quit()
    {
      return;
    }

    public void Reset()
    {
      StartGame();
    }

    public void Setup()
    {
      System.Console.WriteLine("What is your Name brave warrior?");
      var name = Console.ReadLine();
      Console.WriteLine();
      Item key = new Item("key", "a silver key");
      _player = new Player(name);
      playing = true;
      //add a better description _player not coming in right..
      Room Room0 = new Room("Room0", $"Welcome to castle Grimtol {name}. Keep your head on a swivel, you find yourself in the entry plaza of the castle, a cold air eminates from within, there appears to be a door to the north");
      Room Room1 = new Room("Room1", "this room is a real doozy, there appears to be a giant pit to the west.  There is a door to the east");
      Room Room2 = new Room("Room2", "stuff is getting real in this room");
      Room Room3 = new Room("Room3", "almost won you magnificient person, , there is a locked door to the north. \n However, there appears to be a table with a key on it.  Someone wasn't paying attention to security, apparently.");
      Room Room4 = new Room("Room4", "victory you did the thing");
      Room Pit = new Room("Pit", "you fall about 20 feet and are impaled by pungee sticks, your journey ends here...");
      CurrentRoom = Room0;
      //adding room exit paths
      Room0.Exits.Add("north", Room1);
      Room1.Exits.Add("south", Room0);
      Room1.Exits.Add("west", Pit);
      // I dont think I need a pit exit because it's a death trap
      Room1.Exits.Add("east", Room2);
      Room2.Exits.Add("west", Room1);
      Room2.Exits.Add("north", Room3);
      Room3.Exits.Add("south", Room2);
      Room3.Exits.Add("east", Room4);
      Room4.Exits.Add("west", Room3);

      //adding item (Key) to this room for last locked door, maybe add a light switch we'll see
      Room3.Items.Add(key);
      while (playing)
      {

        Console.WriteLine(CurrentRoom.Description);
        Console.WriteLine("Use <Help> for a list of commands");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "help" || userInput == "HELP" || userInput == "Help")
        {
          Help();
          userInput = Console.ReadLine().ToLower();
        }

        if (userInput == "look")
        {
          Console.WriteLine(CurrentRoom.Description);
          userInput = Console.ReadLine().ToLower();
        }
        if (userInput == "reset")
        {
          Reset();
        }
        if (userInput == "go north" && CurrentRoom == Room0)
        {
          CurrentRoom = Room1;
          Console.WriteLine(CurrentRoom.Description);

        }
        if (userInput == "go west" && CurrentRoom == Room1)
        {
          CurrentRoom = Pit;
          Console.WriteLine(CurrentRoom.Description);
          return;
        }
        if (userInput == "go east" && CurrentRoom == Room1)
        {
          CurrentRoom = Room2;
          Console.WriteLine(CurrentRoom.Description);
        }
        if (userInput == "go north" && CurrentRoom == Room2)
        {
          CurrentRoom = Room3;
          Console.WriteLine(CurrentRoom.Description);
        }
        if (userInput == "use key" && CurrentRoom == Room3 && CurrentPlayer.Inventory.Contains(key))
        {
          CurrentRoom = Room4;
          Console.WriteLine(CurrentRoom.Description);
        }
        if (userInput == "take key" && CurrentRoom == Room3)
        {
          TakeItem("key");
        }


        if (userInput == "quit")
        {
          return;
        }

      }

    }
    public void StartGame()
    {
      Setup();
    }
    public void TakeItem(string itemName)
    {

      CurrentPlayer.Inventory = (CurrentRoom.Items);
    }

    public void UseItem(string itemName)
    {
      // CurrentPlayer.Inventory
    }
  }
}