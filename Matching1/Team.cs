using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

        //Personal information, besides name LFLS
        private String name;
        
        //End of personal information
        
        //id for database
        private int id;
        
        //Method to make team without considering the origin
        public Team(List<Skill> skills, List<String> languages)
        {
            this.skills = skills;
            this.languages = languages;
        }
        
        //Proper method for creating team to be able to do twofactormatching
        public Team(List<Skill> skills, List<String> languages, bool isAfrican, String name)
        {
            this.skills = skills;
            this.languages = languages;
            this.isAfrican = isAfrican;
            this.name = name;
        }
        
        public Team(List<Skill> skills, List<String> languages, bool isAfrican, String name, int id)
        {
            this.skills = skills;
            this.languages = languages;
            this.isAfrican = isAfrican;
            this.name = name;
            this.id = id;
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
        
        //Returns true if the team originates in Africa
        public bool GetOrigin()
        {
            return this.isAfrican;
        }

        public String GetName()
        {
            return this.name;
        }
        
        public int getId()
        {
            return this.id;
        }
    }
}
