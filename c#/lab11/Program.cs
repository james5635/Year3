// Author: Sou Chanrojame

public unsafe class Program
{
    public interface IEffection
    {
        public abstract int GetFactor();
        public abstract double GetAmountOf(double actingAmount);
        public virtual string Info(){
            return $"(Na)";
        }
    }
    public class Sale
    {
        public double Total { get; set; }
        public List<IEffection>? Effections { get; set; }
        public double GetGrandTotal()
        {
            double effAmount = 0;
        
            foreach (var eff in Effections)
            {
                effAmount += eff.GetFactor() * eff.GetAmountOf(Total);
            }
            return Total + effAmount;
        }
        public override string ToString()
        {
            
            var infos = from eff in Effections select eff.Info();
            if(Effections?.ToList().Count == 0){
                 infos = [$"(Na)"];
            }
            return $"Total: {Total} Effections: {string.Join(", ",infos.ToArray())} GrandTotal: {GetGrandTotal()}";
        }
    }
    public class Discount : IEffection
    {
        public double Value { get; set; }
        public bool IsPer { get; set; }
        // explicit implementation
        double IEffection.GetAmountOf(double actingAmount)
        {
            if (IsPer == false)
            {
                return Value;
            }
            else
            {
                return actingAmount * Value;
            }
        }
        int IEffection.GetFactor()
        {
            return -1;
        }
              string IEffection.Info(){
            return $"Discount --> {Value}";
        }
    }
    public class VAT : IEffection
    {
        public double Value { get; set; }
        public bool IsPer { get; set; }
        // explicit implementation
        double IEffection.GetAmountOf(double actingAmount)
        {
            if (IsPer == false)
            {
                return Value;
            }
            else
            {
                return actingAmount * Value;
            }
        }
        int IEffection.GetFactor()
        {
            return 1;
        }
             string IEffection.Info(){
            return $"Vat --> {Value}";
        }

    }
    public class Charge : IEffection
    {
        public double Value { get; set; }
        // explicit implementation
        double IEffection.GetAmountOf(double actingAmount)
        {
            return Value;
        }
        int IEffection.GetFactor()
        {
            return 1;
        }
              string IEffection.Info(){
            return $"Charge --> {Value}";
        }

    }
    private static void Main(string[] args)
    {
        Sale s1 = new Sale(){
            Total = 100,
            Effections = new List<IEffection>()
        };
        Sale s2 = new Sale()
        {
            Total = 300,
            Effections = new List<IEffection>(){
        new Discount(){Value=0.20,IsPer=true},
        }
        };
        Sale s3 = new Sale()
        {
            Total = 200,
            Effections = new List<IEffection>(){
        new VAT(){Value=0.10,IsPer=true},
        }
        };
        Sale s4 = new Sale()
        {
            Total = 50,
            Effections = new List<IEffection>(){
        new Discount(){Value=0.20,IsPer=true},
        new VAT(){Value=0.10,IsPer=true},
        new Charge(){Value=20}
        }
        };
        // collection expression
        Sale[] sales= [s1, s2, s3, s4];
        foreach(var s in sales){
            Console.WriteLine(s);
        }
        // Console.WriteLine(s1.GetGrandTotal());
        // Console.WriteLine(s2.GetGrandTotal());
        // Console.WriteLine(s3.GetGrandTotal());
        // Console.WriteLine(s4.GetGrandTotal());
    }
}