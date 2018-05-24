using System;

namespace Matching1
{
    public class Criterion : ICompetency
    {

        private int _weight;
        private string _name;
        public string NameProperty
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Criterion(string name, int weight)
        {
            this._name = name;
            this._weight = weight;
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