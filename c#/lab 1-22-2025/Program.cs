internal unsafe class Program
{
    public abstract class AbstractPerson
    {
        public int? Age { get; set; }
        public string? Name { get; set; }
        public abstract void SetTextData(string text);

    }
    public class Person : AbstractPerson
    {

        public override void SetTextData(string text)
        {
            var SplitString = text.Split(';');
            foreach (var item in SplitString)
            {
                var SplitItem = item.Split('=');
                if (SplitItem[0] == "Age")
                {
                    Age = int.Parse(SplitItem[1]);
                }
                else
                {
                    Name = SplitItem[1];
                }
            }
        }
        public override string ToString() // override the ToString method
        {
            return $"Name: {Name} Age: {Age}";
        }

    }
    public class Student : AbstractPerson
    {
        public int Year { get; set; }
        public override void SetTextData(string text)
        {
            var SplitString = text.Split(';');
            Year = int.Parse(SplitString[0].Split('=')[1]);
            Name = SplitString[1].Split('=')[1];
            Age = int.Parse(SplitString[2].Split('=')[1]);
        }
        public override string ToString()   // override the ToString method
        {
            return $"Year: {Year} Name: {Name} Age: {Age}";
        }


    }
    public class Employee : AbstractPerson
    {
        public double Salary { get; set; }
        public override void SetTextData(string text)
        {
            var SplitString = text.Split(';');
            Salary = double.Parse(SplitString[0].Split('=')[1]);
            Name = SplitString[1].Split('=')[1];
            Age = int.Parse(SplitString[2].Split('=')[1]);
        }
        public override string ToString() // override the ToString method
        {
            return $"Salary: {Salary} Name: {Name} Age: {Age}";
        }
    }

    private static void Main(string[] args)
    {
        string[] lines = new string[]{
           "Person:Name=John;Age=20",
           "Person:Age=33;Name=Mike Robert",
           "Student:Year=2025;Name=John Doe;Age=28",
           "Employee:Salary=10000;Name=Albert Einstein;Age=17",
           "Employee:Salary=200;Name=Albert;Age=11",
           "Employee:Salary=300;Name=Ken Thompson;Age=97",
       };
        Person p = new Person();
        p.SetTextData(lines[0].Split(':')[1]);
        Person p1 = new Person();
        p1.SetTextData(lines[1].Split(':')[1]);
        Student s = new Student();
        s.SetTextData(lines[2].Split(':')[1]);
        Employee e = new Employee();
        e.SetTextData(lines[3].Split(':')[1]);
        Employee e1 = new Employee();
        e1.SetTextData(lines[4].Split(':')[1]);
        Employee e2 = new Employee();
        e2.SetTextData(lines[5].Split(':')[1]);
        List<AbstractPerson> list = new List<AbstractPerson>(){
                p,p1,s,e,e1,e2
        };
        var GreatestAgePerson = list.OrderByDescending(x => x.Age).First();
        // var GreatestAgePerson = list.FirstOrDefault(x => x.Age == list.Max(x => x.Age));
        Console.WriteLine("********** Greatest age person **********");
        Console.WriteLine(GreatestAgePerson);
        Console.WriteLine("********** Before sorting salary **********");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("********** After sorting salary **********");

        list = list.OrderBy(x => x is Employee e ? e.Salary : 0).ToList();
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

}
