namespace Sample
{

    public interface IVisitor
    {
        void VisitSimpleProduct(SimpleProduct product);
        void VisitConfigurableProduct(ConfigurableProduct product);
        void VisitBundleProduct(BundleProduct product);
        void Print();
    }

    public interface IVisitableElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        // an accumulator for the total discount across all products visited.
        private double _totalDiscount = 0.0;


        public void VisitSimpleProduct(SimpleProduct product)
        {
            if (product.Price > 2)
            {
                const double discount = 0.50;
                _totalDiscount += product.GetDiscount(discount);
                Console.WriteLine($"DISCOUNTED: {product.Name} is now ${Math.Round(product.Price - discount, 2)}");
            }
            else
            {
                Console.WriteLine($"NO DISCOUNT: {product.Name}");
            }
        }


        public void VisitConfigurableProduct(ConfigurableProduct product)
        {
            if (product.Price > 50)
            {
                const double discount = 0.10;
                _totalDiscount += product.GetDiscount(discount);
                Console.WriteLine($"DISCOUNTED: {product.Name} is now ${Math.Round(product.Price - discount, 2)}");
            }
            else
            {
                Console.WriteLine($"NO DISCOUNT: {product.Name}");
            }
        }


        public void VisitBundleProduct(BundleProduct product)
        {
            if (product.Price > 20)
            {
                const double discount = 0.75;
                _totalDiscount += product.GetDiscount(discount);
                Console.WriteLine($"DISCOUNTED: {product.Name} is now ${Math.Round(product.Price - discount, 2)}");
            }
            else
            {
                Console.WriteLine($"NO DISCOUNT: {product.Name}");
            }
        }


        public void Print()
        {
            Console.WriteLine($"\nTotal discount: {Math.Round(_totalDiscount, 2)}\n");
            Reset();
        }

        private void Reset()
        {
            _totalDiscount = 0.0;
        }
    }

    public class SalesVisitor : IVisitor
    {
        // an accumulator for the total item count across all products visited.
        private int _simpleProductCount = 0;
        private int _configurableProductCount = 0;
        private int _bundleProductCount = 0;

        public void VisitSimpleProduct(SimpleProduct product)
        {
            _simpleProductCount++;
        }

        public void VisitConfigurableProduct(ConfigurableProduct product)
        {
            _configurableProductCount++;
        }

        public void VisitBundleProduct(BundleProduct product)
        {
            _bundleProductCount++;
        }

        public void Print()
        {
            Console.WriteLine($"Simple Products sold: {_simpleProductCount}");
            Console.WriteLine($"Configurable Products sold: {_configurableProductCount}");
            Console.WriteLine($"Bundle Products sold: {_bundleProductCount}");

            Console.WriteLine($"\nTotal Items sold: " +
                              $"{_simpleProductCount + _configurableProductCount + _bundleProductCount}");
            Reset();
        }

        private void Reset()
        {
            _simpleProductCount = 0;
            _configurableProductCount = 0;
            _bundleProductCount = 0;
        }
    }
}
