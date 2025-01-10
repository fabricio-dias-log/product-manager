namespace ProductManager.Entities;

public sealed class UsedProduct : Product
{
    public DateOnly ManufactureDate { get; set; }

    public UsedProduct()
    {
        
    }

    public UsedProduct(string name, double price, DateOnly manufactureDate) : base(name, price)
    {
        ManufactureDate = manufactureDate;
    }

    public override string PriceTag()
    {
        return $"{Name} used ${Price} (Manufacture date: {ManufactureDate.ToString("dd/MM/yyyy")})";
    }
}