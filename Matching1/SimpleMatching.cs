using System;
using System.Collections.Generic;

namespace Matching1
{
    public static class SimpleMatching
    {
        public static Dictionary<Team, float> DoSimpleMatching(List<Team> teams, Project project)
        {
            //Meeting all the requirements means a 100% match.
            //TODO implement matching with decimals
            int max = project.GetCount();
            int score;
            Dictionary<Team, float> result = new Dictionary<Team, float>();
            
            //TODO implement more efficient way of matching, remove nested foreach, LFLS
            foreach (Team team in teams)
            {
                score = 0;
                foreach (Criterion criterion in project.GetCriteria())
                {
                    if (team.HasSkill(criterion))
                    {
                        score += 100 / max;
                        Console.WriteLine(score);
                    }
                }
                result.Add(team, score);
            }

            return result;
        }
    }
}