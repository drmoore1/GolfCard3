using System;
using System.Collections.Generic;
using GolfCard3.Models;
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
      Console.Clear();
      Greeting();

      Course CoursePlaying = SelectCourse();
      System.Console.WriteLine(CoursePlaying.Name);

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
      bool valid = false;
      string userInput = "";
      int selection = 0;
      while (valid == false)
      {
        try
        {
          selection = Convert.ToInt32(userInput);
          switch (selection)
          {
            case 1:
              valid = true;
              return course1;
            case 2:
              valid = true;
              return course2;
            default:
              return null;
          }
        }
        catch
        {
          return null;
        }


      }
      //   try
      //   {
      //     selection = Convert.ToInt32(userInput);
      //   }
      //   catch
      //   {
      //     Console.Clear();
      //     System.Console.WriteLine("Invalid Selection, Please Select Again");
      //     SelectCourse();
      //     return null;
      //   }


      //   switch (selection)
      //   {
      //     case 1:
      //       return course1;
      //     case 2:
      //       return course2;
      //     default:
      //       Console.Clear();
      //       System.Console.WriteLine("Invalid Selection, Please Select Again");
      //       SelectCourse();

      //   }




    }

  }
}
