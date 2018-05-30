using System;
using System.Collections.Generic;

namespace Matching1
{
    class Program
    {
        static void Main(string[] args)
        {
            Skill skill01 = new Skill("Test01");
            Skill skill02 = new Skill("Test02");
            Skill skill03 = new Skill("Test03");
            Skill skill04 = new Skill("Test04");
            Skill skill05 = new Skill("Test05");
            Skill skill06 = new Skill("Test06");
            Skill skill07 = new Skill("Test07");
            Skill skill08 = new Skill("Test08");
            Skill skill09 = new Skill("Test09");
            Skill skill10 = new Skill("Test10");
            Skill skill11 = new Skill("Test11");
            Skill skill12 = new Skill("Test12");
            Skill skill13 = new Skill("Test13");
            Skill skill14 = new Skill("Test14");
            Skill skill15 = new Skill("Test15");
            
            Criterion crit01 = new Criterion("Test01", 10);
            Criterion crit02 = new Criterion("Test02", 10);
            Criterion crit03 = new Criterion("Test03", 10);
            Criterion crit04 = new Criterion("Test04", 25);
            Criterion crit05 = new Criterion("Test05", 10);
            Criterion crit06 = new Criterion("Test06", 25);
            Criterion crit07 = new Criterion("Test07", 10);
            Criterion crit08 = new Criterion("Test08", 10);
            Criterion crit09 = new Criterion("Test09", 10);
            Criterion crit10 = new Criterion("Test10", 10);
            Criterion crit11 = new Criterion("Test11", 10);
            Criterion crit12 = new Criterion("Test12", 10);
            Criterion crit13 = new Criterion("Test13", 10);
            Criterion crit14 = new Criterion("Test14", 10);
            Criterion crit15 = new Criterion("Test15", 10);
            
            List<Criterion> critlist = new List<Criterion>();
            List<Skill> skilllist = new List<Skill>();
            
            critlist.Add(crit01);
            critlist.Add(crit02);
            critlist.Add(crit03);
            critlist.Add(crit04);
            critlist.Add(crit05);
            critlist.Add(crit06);
            critlist.Add(crit07);
            critlist.Add(crit08);
            critlist.Add(crit09);
            critlist.Add(crit10);
            critlist.Add(crit11);
            critlist.Add(crit12);
            critlist.Add(crit13);
            critlist.Add(crit14);
            critlist.Add(crit15);
            
            skilllist.Add(skill01);
            skilllist.Add(skill02);
            skilllist.Add(skill03);
            skilllist.Add(skill04);
            skilllist.Add(skill05);
            skilllist.Add(skill06);
            skilllist.Add(skill07);
//            skilllist.Add(skill08);
//            skilllist.Add(skill09);
//            skilllist.Add(skill10);
//            skilllist.Add(skill11);
//            skilllist.Add(skill12);
//            skilllist.Add(skill13);
            skilllist.Add(skill14);
            skilllist.Add(skill15);

            
            
            Project project = new Project(critlist, "Dutch");
            Team team = new Team(skilllist, "Dutch");

            Console.WriteLine("Simple matching percentage: " + SimpleMatching.DoSimpleMatching(team, project));
            Console.WriteLine("Weighted matching percentage: " + WeightedMatching.DoWeightedMatching(team, project));
        }
    }
}
