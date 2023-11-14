namespace Sample
{
    public class ObjectStructure
    {
        private List<IVisitableElement> _cart;

        public ObjectStructure(List<IVisitableElement> items)
        {
            _cart = items;
        }

        public void RemoveItem(IVisitableElement item)
        {
            _cart.Remove(item);
        }

        public void AddItem(IVisitableElement item)
        {
            _cart.Add(item);
        }

        public void ApplyVisitor(IVisitor visitor)
        {
            Console.WriteLine($"\nApplying visitor {visitor.GetType()} to cart...\n");
            foreach (var item in _cart)
            {
                item.Accept(visitor);
            }
            visitor.Print();
        }
    }
}
