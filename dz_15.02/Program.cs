using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dz_15._02
{
    class Book : IComparable, ICloneable
    {
        public string name { get; set; }
        public string autor { get; set; }

        public Book() { }
        public Book(string n, string a)
        {
            name = n;
            autor = a;
        }
        public void Print()
        {
            Console.WriteLine($"Name: {name};\nAutor: {autor}.");
        }
        public override string ToString()
        {
            return $"Name: {name};\nAutor: {autor}.";
        }
        public void Show()
        {
            Console.WriteLine("\n{0}   {1}", name, autor);
        }
        public void Input()
        {
            Console.WriteLine("\nВведите название клуба: ");
            this.name = Console.ReadLine();
            Console.WriteLine("\nВведите название города: ");
            this.autor = Console.ReadLine();
        }
        public int CompareTo(object obj)
        {
            if (obj is Book)
                return name.CompareTo((obj as Book).name);

            throw new NotImplementedException();
        }
        public object Clone()
        {
            return new Book(name, autor);
        }

        public class SortByName : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).name.CompareTo((obj2 as Book).name);

                throw new NotImplementedException();
            }
        }
        public class SortByAutor : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).autor.CompareTo((obj2 as Book).autor);

                throw new NotImplementedException();
            }
        }
    }
    class Library : IEnumerable
    {
        Book[] arr;
        public Library(int len)
        {
            arr = new Book[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = new Book();
            }
        }
        public Library() : this(1) { }
        public Library(Book[] books)
        {
            arr = new Book[books.Length];
            for (int i = 0; i < books.Length; i++)
            {
                arr[i] = new Book(books[i].name, books[i].autor);
            }
        }
        public void InputBook()
        {
            for(int i=0;i<arr.Length;i++)
            {
                arr[i].Input();
            }
        }
        public void ShowBook()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Show();
            }
        }
        public IEnumerator GetEnumerator()
        {
            Console.WriteLine("\nВыполняется метод GetEnumerator");
            for (int i = 0; i < arr.Length; i++)
                yield return arr[i];
        }
        static void Main(string[] args)
        {
            Book[] arr = new Book[3];
            arr[0] = new Book("Гарри Поттер", "Роулинг");
            arr[1] = new Book("Тореадоры из Васюковки", "Нестайко");
            arr[2] = new Book("Ведьмак", "Сопковский");
            Library l = new Library(arr);
            Array.Sort(arr, new Book.SortByName());
            foreach (Book temp in arr)
                temp.Print();
            Console.WriteLine("\n\n");
            Array.Sort(arr, new Book.SortByAutor());
            l = new Library(arr);
            foreach (Book temp in l)
                temp.Print();
        }
    }
}

