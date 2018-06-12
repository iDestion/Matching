using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Matching1
{
    public class TwoFactorMatcher
    {
        private List<Team> euTeams;
        private List<Team> afTeams;
        private Project project;
        
        
        //TODO change matcher to static class or singleton
        
        public TwoFactorMatcher(List<Team> teams, Project project)
        {
            euTeams = new List<Team>();
            afTeams = new List<Team>();
            this.project = project;
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

        //Two methods for refreshing the matcher
        public void Refresh(List<Team> teams)
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

        public void Refresh(Project project)
        {
            this.project = project;
        }

        public Match DoMatching()
        {
            //Return values --> Team with highest matching score gets stored. Also stores scores for easy comparison.
            Team team1 = null;
            float score1 = 0;
            Team team2 = null;
            float score2 = 0;
            
            //TODO implement team ability to add unto eachother skills or even complement eachothers skills
            foreach(Team euTeam in euTeams)
            {
                if (WeightedMatcher.DoMatching(euTeam, this.project) > score1)
                {
                    team1 = euTeam;
                    score1 = WeightedMatcher.DoMatching(euTeam, this.project);
                }
            }

            foreach (Team afTeam in afTeams)
            {
                if (WeightedMatcher.DoMatching(afTeam, this.project) > score2)
                {
                    team2 = afTeam;
                    score2 = WeightedMatcher.DoMatching(afTeam, this.project);
                }
            }

            return new Match(team1, team2, this.project);
        }
    }
}