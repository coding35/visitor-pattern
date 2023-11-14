/*

A visitor patterns function is to represent an operation to be
performed on the elements of an object structure without changing
the classes of the elements on which it operates. GOF

Implications

    1.  Add behavior across a wide rage of differing existing classes.

    2.  Gathering related behaviors and accumulating state across differing classes.

    3.  Can be costly if changing class hierarchies is likely. Interface 
        updates will have to be made for all visitors to match.

    4. Encapsulation can also be broken if the visitor is given access to 
       private members of the visited class.
 
Use Cases
 
    1.  When a project has several different classes, with different interfaces,
        that need additional behavior without changing their underlying structure.

    2.  When a project has a variety of classes, with different interfaces and
        inheritance structures, that need added class-specific behavior.

    3.  When different and unrelated behaviors need to be applied without polluting 
        the existing classes.

    4.  When the existing class structure is unlikely to change but new behaviors 
        are likely to be added.

*/

using Sample;

List<IVisitableElement> products = new List<IVisitableElement>()
{
    new SimpleProduct(1, "Chips", 1.99),
    new SimpleProduct(2, "Coke", 2.99),
    new ConfigurableProduct(3, "Shoes", 99.99),
    new BundleProduct(4, "Snack Pack", 29.99)
};


// using visitor pattern without object structure object
var discountVisitor = new DiscountVisitor();

foreach (var product in products)
{
    product.Accept(discountVisitor);
}

discountVisitor.Print();

var salesVisitor = new SalesVisitor();

foreach (var product in products)
{
    product.Accept(salesVisitor);
}

salesVisitor.Print();


// using object structure object to abstract the visitor pattern
var cart = new ObjectStructure(products);
cart.ApplyVisitor(new DiscountVisitor());
//cart.ApplyVisitor(new SalesVisitor());

cart.RemoveItem(products[3]);
cart.ApplyVisitor(new DiscountVisitor());
//cart.ApplyVisitor(new SalesVisitor());

cart.AddItem(new SimpleProduct(5, "Comb", 0.99));
cart.ApplyVisitor(new DiscountVisitor());
cart.ApplyVisitor(new SalesVisitor());