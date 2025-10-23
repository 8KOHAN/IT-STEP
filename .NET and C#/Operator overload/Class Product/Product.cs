public class Product
{
    public string Name { get; set; }

    private int quantity;
    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Quantity cannot be negative.");
            quantity = value;
        }
    }

    private double price;
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative.");
            price = value;
        }
    }

    public Product(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }


    public static Product operator +(Product p, int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount to add cannot be negative.");
        return new Product(p.Name, p.Quantity + amount, p.Price);
    }

    public static Product operator -(Product p, int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount to subtract cannot be negative.");
        int newQuantity = p.Quantity - amount;
        if (newQuantity < 0)
            newQuantity = 0;
        return new Product(p.Name, newQuantity, p.Price);
    }

    public static bool operator ==(Product p1, Product p2)
    {
        if (ReferenceEquals(p1, p2))
            return true;
        if (p1 is null || p2 is null)
            return false;
        return p1.Price == p2.Price;
    }

    public static bool operator !=(Product p1, Product p2)
    {
        return !(p1 == p2);
    }

    public static bool operator >(Product p1, Product p2)
    {
        return p1.Quantity > p2.Quantity;
    }

    public static bool operator <(Product p1, Product p2)
    {
        return p1.Quantity < p2.Quantity;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Product other)
            return false;
        return Name == other.Name && Price == other.Price && Quantity == other.Quantity;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Quantity, Price);
    }

    public override string ToString()
    {
        return $"{Name}: Quantity = {Quantity}, Price = {Price:C}";
    }
}
