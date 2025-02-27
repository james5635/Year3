public class Goods
{
    public string code { get; set; }
    public string name { get; set; }
    public double SoldPrice { get; set; }

}
public class Sale
{
    public int No { get; init; }
    public double Price { get; set; } = 0;
    public double Quantity { get; set; } = 1;
    public virtual double GetAmount() { return Quantity * Price; }
    // 5/2/8
    public virtual string Info => $"{Price}/{Quantity}/{GetAmount()}";
}
public class MixSale : Sale
{
    public double TaxPer { get; set; }
    public double DiscountPer { get; set; }
    public override double GetAmount()
    {
        return base.GetAmount() + base.GetAmount() * TaxPer - base.GetAmount() * DiscountPer;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        List<Goods> goodList = new()
        {
            new Goods(){
                code = "PRD001", name = "Goods 1", SoldPrice = 5.20
            },
            new Goods(){
                code = "PRD002", name = "Goods 2", SoldPrice = 12.0
            },
            new Goods(){
                code = "PRD003", name = "Goods 3", SoldPrice = 8.50

            }
        };
        Goods? LowestGoods = goodList.FirstOrDefault(x => x.SoldPrice == goodList.Min(y => y.SoldPrice));
        List<Sale> saleList = new(){
            new Sale(){
                No = 1, Price = 5.20, Quantity = 2
            },
            new MixSale(){
                No = 2, Price = 12.0, Quantity = 1, TaxPer = 0.1, DiscountPer = 0.05
            },
        };
        MixSale s = new MixSale()
        {
            No = 3,
            Price = 5,
            Quantity = 2,
            TaxPer = 0.1
        }
        ;
        /*
        string No = FieldNo.Text;
        string Price = FieldPrice.Text;
        string Quantity = FieldQuantity.Text;
        if (TaxBox.checked){
        string TaxPer = FieldTaxPer.Text;
            if(DiscountBox.checked){
            string DiscountPer = FieldDiscountPer.Text;
            MixSale s = new MixSale(){
                No = int.Parse(No),
                Price = double.Parse(Price),
                Quantity = double.Parse(Quantity),
                TaxPer = double.Parse(TaxPer),
                DiscountPer = double.Parse(DiscountPer)
            saleList.Add(s);
            } else{
            MixSale s = new MixSale(){
                No = int.Parse(No),
                Price = double.Parse(Price),
                Quantity = double.Parse(Quantity),
                TaxPer = double.Parse(TaxPer)
                }
            saleList.Add(s);
            }
        } else {
            Sale s = new Sale(){
                No = int.Parse(No),
                Price = double.Parse(Price),
                Quantity = double.Parse(Quantity)
            }
            saleList.Add(s);
        }

        */
    }
}
