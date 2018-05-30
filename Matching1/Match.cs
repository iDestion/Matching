using System.Runtime.InteropServices.WindowsRuntime;

namespace Matching1
{
    public class Match
    {
        private Team euTeam;
        private Team afTeam;
        private Project project;
        
        public Match(Team euTeam, Team afTeam, Project project)
        {
            this.euTeam = euTeam;
            this.afTeam = afTeam;
            this.project = project;
        }

        public Team getEuTeam()
        {
            return this.euTeam;
        }

        public Team getAfTeam()
        {
            return this.afTeam;
        }

        public Project getProject()
        {
            return this.project;
        }
    }
}