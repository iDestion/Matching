using System;
using System.Collections.Generic;

namespace Matching1
{
    public class Team
    {
        //Required for matching. Null is caught, won't happen in practise.
        private List<Skill> skills;
        
        //Boolean, determines if team is African or European (experienced in projectmanagement or not)
        private bool isAfrican;

        //Language --> Hard exclusion if no match with other team/project
        private List<String> languages;

        //Personal information, LFLS
        
        //End of personal information
        
        public Team(List<Skill> skills, List<String> languages)
        {
            this.skills = skills;
            this.languages = languages;
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

        public List<String> GetLanguages()
        {
            return this.languages;
        }

        public void AddLanguage(string language)
        {
            this.languages.Add(language);
        }
    }
}
