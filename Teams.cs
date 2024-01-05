using System;
using System.Collections.Generic;
using System.Linq;

namespace AugustPaper
{
    public class Team
    {
        // Properties for team name and list of players
        public string Name { get; set; }
        public List<Member> Members { get; set; }

        // Constructor to initialize a team with a name
        public Team(string name)
        {
            Name = name;
            Members = new List<Member>();
        }
    }
}
