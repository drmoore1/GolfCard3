using System;
using System.Collections.Generic;
using GolfCard3.Models;
using System.Linq;
namespace GolfCard3
{
  class Program
  {
    static void Main(string[] args)
    {

      //Greet User
      //Provide A list of available Properties/Courses
      // - Maybe display Pars and Distances?
      //Select Number of Players -- UNLIMITED!!!!
      // - Set up each players Name and Handicaps
      //Progress through each round of play.
      //Provide Last Hole, Current Score? for each player.
      //Need break down of all players at end, including final score.

      //-=-=- Initial Variables to FILL
      int PlayerCount = 0;
      Course CoursePlaying = null;
      List<Player> Players = new List<Player> { };
      // Clear Screen and Greeting
      Console.Clear();
      Greeting();
      //Check for actice course, call method to set one
      while (CoursePlaying == null)
      {
        CoursePlaying = SelectCourse();
      }
      //Check for valid player count, call method to set one
      while (PlayerCount == 0)
      {
        PlayerCount = GetPlayerCount();
      }
      //Add Players to the existing empty list, 
      // all error checking and such is handled inside the method.
      Players = CreatePlayer(PlayerCount);
      //Create the MATCH!!!!
      Match CurrentMatch = new Match(CoursePlaying, Players);
      Console.Clear();
      //Logic Loop for Hole Count
      while (CurrentMatch.CurrentHole < 19)
      {
        Console.Clear();

        // Logic Loop to record all scores for each player
        foreach (Player thisPlayer in CurrentMatch.CurrentPlayers)
        {
          // Wanted to put running totals...  Tried a method to sum.
          //  then tried linq...  always showed ZERO so gave up.
          //  OK... seems the Values are simply not getting into the list..
          //  I seem to have fixed it.. but with less than robust error handling....
          System.Console.WriteLine($"{thisPlayer.Name}: {thisPlayer.Score.Sum()}");
          System.Console.WriteLine($"Enjoy Hole {CurrentMatch.CurrentHole}, I want to refence the par and distance..");
          System.Console.WriteLine($"Please Input Score for {thisPlayer.Name}");
          int RoundScore = ScoreValidate();
          thisPlayer.Score.Add(RoundScore);
          thisPlayer.TotalScore += RoundScore;

        }
        CurrentMatch.CurrentHole++;
        Console.Clear();
      }
      System.Console.WriteLine($"The Final Scores are as Follows:");
      foreach (Player thisPlayer in CurrentMatch.CurrentPlayers)
      {
        System.Console.WriteLine($"{thisPlayer.Name} scored {thisPlayer.Score.Sum()} naturally.");
        System.Console.WriteLine($"But has a handicap of {thisPlayer.Handicap} for a final score of {thisPlayer.Score.Sum() - thisPlayer.Handicap}");
      }
      string WinnerName = "";
      int WinningScore = 99999999;
      foreach (Player thisPlayer in CurrentMatch.CurrentPlayers)
      {
        if (thisPlayer.TotalScore < WinningScore)
        {
          WinnerName = thisPlayer.Name;
          WinningScore = thisPlayer.TotalScore;
        }
      }
      System.Console.WriteLine($"The Overall Winner is {WinnerName}");



    }


    static int GetPlayerCount()
    {
      System.Console.WriteLine($"How Many Golfers will be Playing Today?");
      string userInput = Console.ReadLine();
      int count = 0;
      try
      {
        count = Convert.ToInt32(userInput);
      }
      catch
      {

        return 0;
      }
      if (count > 0)
      {
        return count;
      }
      else
      {
        return 0;
      }
    }
    static List<Player> CreatePlayer(int players)
    {
      List<Player> playerList = new List<Player> { };
      int count = players;
      int total = count;
      int handi = 0;
      while (count > 0)
      {
        Console.Clear();
        System.Console.WriteLine($"Please Input Name for Player {total - count + 1}");
        string name = Console.ReadLine();
        System.Console.WriteLine($"Please Input Handicap for Player {total - count + 1}");
        try
        {
          string userInput = Console.ReadLine();
          handi = Convert.ToInt32(userInput);
        }
        catch
        {
          return null;
        }
        Player newPlayer = new Player(name, handi);
        playerList.Add(newPlayer);
        count--;
      }
      return playerList;
    }
    static void Greeting()
    {
      System.Console.WriteLine("Welcome to GolfCard v3");
      System.Console.WriteLine("Copyright 1987");


    }
    //SelectCourse creates 2 courses statically and allows selection
    static Course SelectCourse()
    {
      List<int> course1Par = new List<int> { 4, 2, 5, 3, 4, 5, 4, 3, 5, 3, 3, 5, 5, 2, 3, 4, 4, 3 };
      List<int> course1Range = new List<int> { 323, 232, 354, 543, 325, 335, 532, 329, 230, 259, 301, 323, 245, 185, 194, 305, 264, 294 };
      Course course1 = new Course("Shady Acres Golf Club", "111 Shady Lane", course1Par, course1Range);
      List<int> course2Par = new List<int> { 4, 2, 3, 4, 4, 2, 4, 3, 5, 4, 3, 4, 5, 2, 4, 3, 4, 4 };
      List<int> course2Range = new List<int> { 363, 234, 264, 243, 306, 192, 284, 379, 278, 243, 323, 302, 228, 185, 173, 287, 227, 183 };
      Course course2 = new Course("Flat Fish Park", "408 Link Lane", course2Par, course2Range);

      System.Console.WriteLine("Please Select your Course");
      System.Console.WriteLine($"(1) {course1.Name}");
      System.Console.WriteLine($"(2) {course2.Name}");
      //   -=-=- This section keeps saying Not All Paths Return Object... 
      //  But adding return Nulls anywhere results in Unreachable Code?
      //  The Old Code fails, if you select an invalid choice it resets the interface, 
      //    but can not place the object correctly.  Possibly because of the null?
      //  Fixed the issue by making the Fail Safe work in the method that calls this one.
      //  Defines the Course as null, and while loops if is null until receives a valid choice.
      //   bool valid = false;
      //   while (valid == false)
      //   {
      //     try
      //     {
      //       string userInput = Console.ReadLine();
      //       int selection = Convert.ToInt32(userInput);
      //       switch (selection)
      //   {
      //     case 1:
      //       valid = true;
      //       return course1;
      //     case 2:
      //       valid = true;
      //       return course2;

      //     default:
      //       SelectCourse();
      //           return null;
      //       }

      //     }
      //     catch
      //     {
      //       SelectCourse();
      //       return null;
      //     }

      //   }
      #region Old Attempt That works kind of.. 
      int selection = 0;
      try
      {
        string userInput = Console.ReadLine();
        selection = Convert.ToInt32(userInput);
      }
      catch
      {
        Console.Clear();
        System.Console.WriteLine("Invalid Selection, Please Select Again");
        return null;
      }


      switch (selection)
      {
        case 1:
          return course1;
        case 2:
          return course2;
        default:
          Console.Clear();
          System.Console.WriteLine("Invalid Selection, Please Select Again");

          return null;

      }
      #endregion



    }
    static int ScoreValidate()
    {
      try
      {
        int number = Convert.ToInt32(Console.ReadLine());
        if (number > 0)
        {
          return number;
        }
      }
      catch
      {
        ScoreValidate();
        return 0;
      }
      return 0;
    }




    static int SumScore(List<int> scores)
    {
      int Total = 0;
      foreach (int score in scores)
      {
        Total += score;

      }
      return Total;
    }
  }
}
