using System;
using System.Collections.Generic;

namespace Matching1
{
    public class TwoFactorMatcher
    {
        private List<Team> euTeams;
        private List<Team> afTeams;
        
        public TwoFactorMatcher(List<Team> teams, Project project)
        {
            euTeams = new List<Team>();
            afTeams = new List<Team>();
            foreach (Team team in teams)
            {
                if (team.GetOrigin())
                {
                    afTeams.Add(team);
                } else if (!team.GetOrigin())
                {
                    euTeams.Add(team);
                }
            }    
        }

        public Match doMatching()
        {
            //TODO implement team ability to add unto eachother skills or even complement eachothers skills
            foreach(Team euTeam in euTeams)
            {
                
            }

            foreach (Team afTeam in afTeams)
            {
                
            }
        }
    }
}