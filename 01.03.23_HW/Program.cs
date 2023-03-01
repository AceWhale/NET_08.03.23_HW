using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._03._23_HW
{
    internal class Program
    {
        #region 1
        class Book : IDisposable
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public string Type { get; set; }
            public int Year { get; set; }
            public Book() { }
            public Book(string name, string author, string type, int year)
            {
                Name = name;
                Author = author;
                Type = type;
                Year = year;
            }
            public override string ToString()
            {
                return "Книга: " + Name + "\nАвтор: " + Author + "\nЖанр: " + Type + "\nГод: " + Year;
            }
            ~Book() => Console.WriteLine($"Вызван финализатор для книги {Name}");
            public void Dispose() => Console.WriteLine($"Вызван Dispose для книги {Name}");
        }
        #endregion

        #region 2
        public enum TypeShop
        {
            Продовольственный,
            Хозяйственный,
            Одежда,
            Обувь
        }

        public class Shop : IDisposable
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public TypeShop TypeShop { get; set; }
            public Shop() { }
            public Shop(string name, string address, TypeShop typeShop)
            {
                Name = name;
                Address = address;
                TypeShop = typeShop;
            }
            public override string ToString()
            {
                return $"Магазин: {Name}\nАдресс: {Address}\nТип: {TypeShop}";
            }
            public void Dispose() => Console.WriteLine($"Вызван Dispose для магазина {Name}");
            ~Shop() => Console.WriteLine($"Вызван финализатор для магазина {Name}");
        }
        #endregion
        static void Main(string[] args)
        {
            Book book = new Book("Book", "Nikke", "test", 2023);
            Console.WriteLine(book.ToString());
            using (book) ;
            Shop shop = new Shop("Magazin", "Govorova", TypeShop.Продовольственный);
            Console.WriteLine("\n"+shop.ToString());
            using (shop) ;
        }
    }
}
