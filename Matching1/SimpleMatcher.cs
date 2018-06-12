using System;
using System.Collections.Generic;

//Simplematching scores every ICompetency equally.

namespace Matching1
{
    public static class SimpleMatcher
    {
        public static Dictionary<Team, int> DoMatching(List<Team> teams, Project project)
        {
            
            //Meeting all the requirements means a 100% match.
            //TODO implement matching with decimals LFLS
            int max = project.GetCount();
            int score;
            Dictionary<Team, int> result = new Dictionary<Team, int>();
            
            //TODO implement more efficient way of matching, remove nested foreach, LFLS
            foreach (Team team in teams)
            {
                //TODO make languages list and implement check
//                if (team.GetLanguage() != project.GetLanguage())
//                {
//                    result.Add(team, 0);
//                }
                score = 0;
                foreach (Criterion criterion in project.GetCriteria())
                {
                    if (team.HasSkill(criterion))
                    {
                        score += 100 / max;
                        Console.WriteLine("Simple score: " + score);
                    }
                }
                result.Add(team, score);
            }

            return result;
        }

        public static int DoMatching(Team team, Project project)
        {
            int max = project.GetCount();
            int score = 0;
            foreach (Criterion criterion in project.GetCriteria())
            {
                if (team.HasSkill(criterion))
                {
                    score += 100 / max;
                    Console.WriteLine("Simple score: " + score);
                }
            }

            return score;
        }
    }
}