namespace RefValueTypesHomework
{
    internal class Program
    {
        class Country
        {
            public int x { get; set; }
            public int y { get; set; }
            public Country()
            {
                x = 0;
                y = 0;
            }
            public Country(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public override string ToString()
            {
                return $"Country: \nX: {x}\nY: {y}";
            }
        }
        struct City
        {
            public int x { get; set; }
            public int y { get; set; }
            public Country country { get; set; }
            public City()
            {
                x = 0;
                y = 0;
                country = new Country();
            }
            public City(int x, int y, Country country)
            {
                this.x = x;
                this.y = y;
                this.country = country;
            }
            public override string ToString()
            {
                string res = country.ToString() + "\n";
                return res + $"City: \nX: {x}\nY: {y}";
            }
        }

        static void Main(string[] args)
        {
            City kharkiv = new City(5, 5, new Country(10, 10)); //Creating an instance of the City structure and filling it with some values.
            var kyiv = kharkiv; //Copying the instance into another variable. Since structures are a value type, there will be two objects on the stack.
                                //Since Country is a reference type we can assume that both instances refer to the same object on the heap.
            Console.WriteLine(kharkiv + "\n");
            Console.WriteLine(kyiv + "\n");
            Console.WriteLine("---------------------------------------------------------\n");
            kyiv.country.x = 7; 
            kyiv.country.y = 7; //Now both instances have a different country. 
            kyiv.x = 2; 
            kyiv.y = 2; //Since x and y are value types, only the second instance will have different values. 
            Console.WriteLine(kharkiv + "\n");
            Console.WriteLine(kyiv + "\n");
            Console.WriteLine("---------------------------------------------------------\n");
            kyiv.country = new Country(15, 15); //Now we are creating another Country object on the heap and assign it to the second instance.  
            Console.WriteLine(kharkiv + "\n");
            Console.WriteLine(kyiv + "\n");
        }
    }
}
