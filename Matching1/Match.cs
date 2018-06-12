using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.SqlServer.Server;

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

        public Team GetEuTeam()
        {
            return this.euTeam;
        }

        public Team GetAfTeam()
        {
            return this.afTeam;
        }

        public Project GetProject()
        {
            return this.project;
        }

        public override String ToString()
        {
            String res = "Eu: " + euTeam.GetName() + ", AF: " + afTeam.GetName() + ", proj: " + project.GetName();
            Console.WriteLine(res);
            return res;
        }
    }
}