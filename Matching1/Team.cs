using System;
using System.Collections.Generic;

namespace Matching1
{
    public class Team
    {
        //Required for matching. Null is caught, won't happen in practise.
        private List<Skill> skills;

        //Language --> Hard exclusion if no match with other team/project
        private string language;

        //Personal information, LFLS
        
        //End of personal information
        
        public Team(List<Skill> skills, string language)
        {
            this.skills = skills;
            this.language = language;
        }

        public Boolean HasSkill(ICompetency competency)
        {
            foreach (Skill skill in skills)
            {
                if (skill.Equals(competency))
                {
                    return true;
                }
            }

            return false;
        }


        public List<Skill> GetSkills()
        {
            return this.skills;
        }
        public void ResetSkills()
        {
            this.skills = null;
        }
        public void AddSkill(Skill skill)
        {
            this.skills.Add(skill);
        }
        //TODO: Handle exception, implement better removal. LFLS
        public void RemoveSkill(Skill skill)
        {
            if (skills.Contains(skill))
            {
                skills.Remove(skill);
            } 
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
