using System;
using System.Collections.Generic;
using GolfCard3;
namespace GolfCard3.Models
{
  class Match
  {
    public Match(Course course, List<Player> list)
    {
      CurrentPlayers = list;
      Course = course;

    }

    public int CurrentHole { get; set; } = 1;
    public List<Player> CurrentPlayers { get; set; }
    public Course Course { get; set; }
  }
}