using System;
using System.Collections.Generic;

namespace Solid
{
    class Item { }

    class Order
    {
        private List<Item> itemList = new List<Item>();
        internal List<Item> ItemList { get { return itemList; } set { itemList = value; } }

        public void CalculateTotalSum() { }
        public void GetItems() { }
        public void GetItemCount() { }
        public void AddItem(Item item) { }
        public void DeleteItem(Item item) { }
    }

    class OrderViewer
    {
        public void PrintOrder(Order order) { }
        public void ShowOrder(Order order) { }
    }

    class OrderRepository
    {
        public void Load(int orderId) { }
        public void Save(Order order) { }
        public void Update(Order order) { }
        public void Delete(Order order) { }
    }

    class Email
    {
        public string Theme { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    class EmailSender
    {
        private ILogger logger;
        public EmailSender(ILogger logger)
        {
            this.logger = logger;
        }
        public void Send(Email email)
        {
            logger.Log("Email from '" + email.From + "' to '" + email.To + "' was send");
        }
    }

    interface IShape
    {
        int GetArea();
    }

    class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int GetArea()
        {
            return Width * Height;
        }
    }

    class Square : IShape
    {
        public int Side { get; set; }
        public int GetArea()
        {
            return Side * Side;
        }
    }

    interface IItem
    {
        void SetPrice(double price);
    }

    interface IDiscountable
    {
        void ApplyDiscount(string discount);
        void ApplyPromocode(string promocode);
    }

    interface IClothes
    {
        void SetColor(byte color);
        void SetSize(byte size);
    }

    class Book : IItem, IDiscountable
    {
        public void SetPrice(double price) { }
        public void ApplyDiscount(string discount) { }
        public void ApplyPromocode(string promocode) { }
    }

    class Outerwear : IItem, IDiscountable, IClothes
    {
        public void SetPrice(double price) { }
        public void ApplyDiscount(string discount) { }
        public void ApplyPromocode(string promocode) { }
        public void SetColor(byte color) { }
        public void SetSize(byte size) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
            EmailSender es = new EmailSender(new ConsoleLogger());
            es.Send(e1);

            IShape rect = new Rectangle { Width = 5, Height = 10 };
            IShape sq = new Square { Side = 5 };
            Console.WriteLine("Rectangle area: " + rect.GetArea());
            Console.WriteLine("Square area: " + sq.GetArea());

            Console.ReadKey();
        }
    }
}
