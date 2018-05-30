//WeightedMatching will consider the provided weights in evaluating the score gained for every criterion.

using System;

namespace Matching1
{
    public static class WeightedMatching
    {
        public static float DoWeightedMatching(Team team, Project project)
        {
            //Total weight of the criteria.
            float maxweight = project.TotalWeight();
            Console.WriteLine("Total weight: " + maxweight);
            //Score will consist of the added weights of the skills the team has.
            float score = 0;

            foreach (Criterion crit in project.GetCriteria())
            {
                if (team.HasSkill(crit))
                {
                    score += crit.GetWeight();
                    Console.WriteLine("Weighted score: " + score);
                }
            }

            return 100 * score / maxweight;
        }
    }
}