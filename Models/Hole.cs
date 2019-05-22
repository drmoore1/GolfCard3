using System;
using System.Collections.Generic;

namespace GolfCard3.Models
{
  class Hole
  {
    // Going to try to not use a HOLE class and instead make a 
    //LIST inside of Course for it all. 
    public List<int> HoleNumber { get; set; }
    public List<int> Par { get; set; }
    public List<int> Range { get; set; }

  }
}