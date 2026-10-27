namespace csharp_practice12;

public delegate bool Comparer(object x, object y);

static class SelectionSort
{
    static public void Sort(object[] array, Comparer comparer)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer(array[j], array[minIndex]))
                    minIndex = j;
            }

            if (minIndex != i)
            {
                object temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }
}

public class Product
{
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; } = 0.0;
    public int Count { get; set; } = 0;

    public Product()
    {
        Title = "Default Title";
        Price = 0.0;
        Count = 0;
    }
    
    public Product(string title, double price, int count)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(nameof(title));
        if (price <= 0)
            throw new ArgumentOutOfRangeException(nameof(price));
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));
        
        Title = title;
        Price = price;
        Count = count;
    }

    public override string ToString()
    {
        return string.Format($"Title: {Title}, Price: {Price}, Count: {Count}");
    }
}

class Program
{
    static bool CompareByTitle(object x, object y)
    {
        Product p1 = (Product)x;
        Product p2 = (Product)y;
        
        return string.Compare(p1.Title, p2.Title, StringComparison.OrdinalIgnoreCase) < 0;
    }

    static bool CompareByPrice(object x, object y)
    {
        Product p1 = (Product)x;
        Product p2 = (Product)y;
        
        return p1.Price < p2.Price;
    }

    static bool CompareByCount(object x, object y)
    {
        Product p1 = (Product)x;
        Product p2 = (Product)y;
        
        return p1.Count < p2.Count;
    }

    static void PrintArray(object[] array)
    {
        foreach (object obj in array)
            Console.WriteLine(obj + "");
        
        Console.WriteLine("");
    }
    
    static void Main(string[] args)
    {
        Product p1 = new Product("Cappuccino", 75, 1);
        Product p2 = new Product("Latte", 80, 2);
        Product p3 = new Product("Americano", 50, 3);
        Product p4 = new Product("Espresso", 55, 4);
        
        object[] coffeeArray = { p1, p2, p3, p4 };
        Console.WriteLine("Array before sorting: ");
        PrintArray(coffeeArray);
        
        Console.WriteLine("Array after sorting: ");
        Console.WriteLine("1) Sort by title: ");
        SelectionSort.Sort(coffeeArray, CompareByTitle);
        PrintArray(coffeeArray);
        
        Console.WriteLine("2) Sort by price: ");
        SelectionSort.Sort(coffeeArray, CompareByPrice);
        PrintArray(coffeeArray);
        
        Console.WriteLine("3) Sort by count: ");
        SelectionSort.Sort(coffeeArray, CompareByCount);
        PrintArray(coffeeArray);
    }
}

