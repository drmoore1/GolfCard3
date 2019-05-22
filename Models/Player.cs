using System;
using System.Collections.Generic;

namespace GolfCard3.Models
{
  class Player
  {
    public Player(string name, int handi)
    {
      Name = name;
      Handicap = handi;
      Score = new List<int> { };
      TotalScore = 0 - Handicap;
    }

    public string Name { get; set; }
    public int Handicap { get; set; }
    public List<int> Score { get; set; }
    public int TotalScore { get; set; }

  }
}