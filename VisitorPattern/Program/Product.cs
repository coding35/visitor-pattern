namespace Sample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }

        public double GetDiscount(double percentage)
        {
            return Math.Round(Price * percentage, 2);
        }
    }


    public class SimpleProduct : Product, IVisitableElement
    {
        public SimpleProduct(int id, string name, double price) : base(id, name, price)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitSimpleProduct(this);
        }
    }


    public class ConfigurableProduct : Product, IVisitableElement
    {
        public ConfigurableProduct(int id, string name, double price) : base(id, name, price)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitConfigurableProduct(this);
        }
    }


    public class BundleProduct : Product, IVisitableElement
    {
        public BundleProduct(int id, string name, double price) : base(id, name, price)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitBundleProduct(this);
        }
    }
}
