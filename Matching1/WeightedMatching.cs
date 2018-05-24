//WeightedMatching will consider the provided weights in evaluating the score gained for every criterion.

using System;

namespace Matching1
{
    public static class WeightedMatching
    {
        public static float DoWeightedMatching(Team team, Project project)
        {
            //Total weight of the criteria.
            int maxweight = project.TotalWeight();
            Console.WriteLine("Total weight: " + maxweight);
            //Score will consist of the added weights of the skills the team has.
            int score = 0;
            
            Console.WriteLine(maxweight);

            foreach (Criterion crit in project.GetCriteria())
            {
                if (team.HasSkill(crit))
                {
                    score += crit.GetWeight();
                    Console.WriteLine("Weighted score: " + score);
                }
            }

            //TODO fix when total weight > 100
            return 100 / maxweight * score;
        }
    }
}