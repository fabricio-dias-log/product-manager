namespace ProductManager.Entities;

public sealed class ImportedProduct : Product
{
    public double CustomFee { get; set; }

    public ImportedProduct()
    {
    }

    public ImportedProduct(string name, double price, double customFee) : base(name, price)
    {
        CustomFee = customFee;
    }

    public override string PriceTag()
    {
        return $"{Name} ${Price} (Custom Fee: ${CustomFee})";
    }

    public double TotalPrice()
    {
        return Price + CustomFee;
    }
}