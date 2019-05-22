using System;
using System.Collections.Generic;

namespace GolfCard3.Models
{
  class Course
  {
    //Creates the Course.  Could create a constructor for the LISTS.
    //Would probably only be needed if the course isn't hard coded.
    //May add later if I'm feeling ambitious and do well... /cry-emoji
    public Course(string name, string address, List<int> par, List<int> range)
    {
      Name = name;
      Address = address;
      Par = par;
      Range = range;
    }
    // Name, Address, Par(list) Range(List) 0 = Hole 1 etc. 
    public string Name { get; private set; }
    public string Address { get; set; }
    public List<int> Par { get; set; }
    public List<int> Range { get; set; }
  }
}