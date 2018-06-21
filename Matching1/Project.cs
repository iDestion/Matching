using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Matching1
{
    public class Project
    {
        //Required for matching. Null is caught, can happen in practise
        private List<Criterion> criteria;
        
        //Language --> Hard exclusion if no match between teams and project
        private string language;
        
        //Misc. information about project, besides name LFLS
        private String name;
        
        //End of misc. information

        //id for database
        private int id;

        public List<Criterion> GetCriteria()
        {
            return this.criteria;
        }

        public Project(List<Criterion> criteria, string language, String name)
        {
            this.criteria = criteria;
            this.language = language;
            this.name = name;
        }
        
        public Project(List<Criterion> criteria, string language, String name, int id)
        {
            this.criteria = criteria;
            this.language = language;
            this.name = name;
            this.id = id;
        }

        public void AddCriterion(Criterion criterion)
        {
            this.criteria.Add(criterion);
        }
        //TODO: Handle exception, implement better removal. LFLS
        public void RemoveCriterion(Criterion criterion)
        {
            if (this.criteria.Contains(criterion))
            {
                this.criteria.Remove(criterion);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int GetCount()
        {
            return this.criteria.Count;
        }
        
        public string GetLanguage()
        {
            return this.language;
        }

        public int TotalWeight()
        {
            int result = 0;
            foreach (Criterion crit in criteria)
            {
                result += crit.GetWeight();
            }

            return result;
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
