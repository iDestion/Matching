namespace Matching1 { 
    public interface ICompetency
    {
        string NameProperty { get; set; }

        bool Equals(ICompetency comp);
    }
}
