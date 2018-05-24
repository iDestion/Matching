using System;

namespace Matching1
{
    class Skill : ICompetency
    {
        public string NameProperty { get; set; }

        public Skill(string name)
        {
            this.NameProperty = name;
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
