using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    //creating rooms for game

    //creating an object
    bool playing = false;
    public Item key;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }


    public void GetUserInput()
    {
      string userInput = Console.ReadLine();

    }

    public void Go(string direction)
    {
      // CurrentRoom = CurrentRoom.Exits(Console.ReadLine(east));
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
      if (userInput == "help" || userInput == "Help" || userInput == "HELP")
      {
        Help();
      }
      if (userInput == "look" || userInput == "Look" || userInput == "LOOK")
      {
        Look();
      }
      Console.WriteLine(CurrentRoom.Description);
    }

    public void Inventory()
    {

    }

    public void Look()
    {
      Console.WriteLine(CurrentRoom.Description);
    }

    public void Quit()
    {
      Quit();
      return;
    }

    public void Reset()
    {
      StartGame();
    }

    public void Setup()
    {
      playing = true;
      //add a better description
      Room Room0 = new Room("Room0", "you find yourself in the entry plaza of the castle, a cold air eminates from within, there appears to be a door to the north");
      Room Room1 = new Room("Room1", "this room is a real doozy, there appears to be a giant pit to the west.  There is a door to the east");
      Room Room2 = new Room("Room2", "stuff is getting real in this room, there is a locked door to the north");
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
      while (playing)
      {

        Console.WriteLine("Welcome to castle Grimtol, keep your head on a swivel");
        Console.WriteLine(CurrentRoom.Description);
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
        if (userInput == "reset" || userInput == "RESET" || userInput == "Reset")
        {
          Reset();
        }
        if (userInput == "go north" || userInput == "Go North" || userInput == "GO NORTH")
        {
          // find out why no access to this even though constructed above
          //CurrentRoom = Room0;

          //this is not the right value to print.. to string maybe
          Console.WriteLine(CurrentRoom.Exits.ToString());
        }

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