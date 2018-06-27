using System.Collections.Generic;

namespace Matching1
{
    public static class Data
    {
        private static List<Team> teams;
        private static List<Project> projects;

        public static void SetTeams(List<Team> teams)
        {
            Data.teams = teams;
        }

        public static void SetProjects(List<Project> projects)
        {
            Data.projects = projects;
        }

        public static List<Team> GetTeams()
        {
            return teams;
        }

        public static List<Project> GetProjects()
        {
            return projects;
        }


        public static Project getProjectById(int id)
        {
            foreach (Project proj in projects)
            {
                if (proj.getId() == id)
                {
                    return proj;
                }
            }

            return null;
        }
    }
}