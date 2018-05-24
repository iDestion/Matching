using System;

namespace Matching1
{
    public class Criterion : ICompetency
    {

        private int weight;
        private string name;
        public string NameProperty
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Criterion(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }

        public bool Equals(ICompetency comp)
        {
            return this.NameProperty == comp.NameProperty;
        }

        public string ToString()
        {
            return this.NameProperty;
        }
    }
}