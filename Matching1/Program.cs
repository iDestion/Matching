using System;
using System.Collections.Generic;

namespace Matching1
{
    class Program
    {
        static void Main(string[] args)
        {
            ICompetency crit = new Criterion("Test", 123);
            ICompetency skill = new Skill("Test");

            Console.WriteLine(crit.Equals(skill));
        }
    }

    class Matcher
    {
        public Matcher(Project project, List<Team> teams)
        {

        }
    }
}
