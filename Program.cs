using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    class Program
    {
        enum ArticleType { foods, clothes, books, toys};
        enum PayType { CashPayment, PaymentByCard };
        enum ClientType { important, unimportant };
        struct Article
        {

            public int code { get; set; }
            public string name { get; set; }
            public double price { get; set; }
            public ArticleType Type{ get; set; }
            public Article (int codeP, string nameP, double priceP, ArticleType TypeP)
            {
                 code = codeP;
                name = nameP;
                price = priceP;
                Type = TypeP;
            }


        };
       struct Client
        {
            public  int code { get; set; }
            public string full_name { get; set; }
            public string address { get; set; }
            public string phone_number { get; set; }
            public int number_of_orders { get; set; }
            public double sum { get; set; }
           public ClientType Type { get; set; }
            public void Print()
            {
                Console.WriteLine("Информация о клиенте:");
                Console.WriteLine("Код клиента: " + code);
                Console.WriteLine("Имя : " + full_name);
                Console.WriteLine("количество заказов : " + number_of_orders);
                Console.WriteLine("Важность клиента : " + Type);
            }
          
        };
      struct RequestItem
        {
            public Article product { get; set; }
            public int number_of_product { get; set; }
            RequestItem(Article productP, int number_of_productP)
            {
                product = productP;
                number_of_product = number_of_productP;
            }

        };
       struct Request
        {
            public int code_of_order { get; set; }
            public Client client { get; set; }
            public DateTime date { get; set; }
            public RequestItem[] products { get; set; }
            PayType Type { get; set; }
         
           public double sum { get; set; }
            public double Sum
             { 
                 set { sum = value; }
                 get 
                 {
                     for (int i = 0; i < products.Length; i++)
                     sum += products[i].number_of_product * products[i].product.price;
                     return sum; 
                 }

             }
            public Request(int code_of_orderP,  Client clientP,  DateTime dateP, RequestItem[] productsP,  PayType TypeP)
            {
                code_of_order = code_of_orderP;
              
                client= clientP;
                date = dateP;
                products = productsP;
                Type = TypeP;
                sum = 0;

            }
         public void Print()
            {
               
                client.Print();
                Console.WriteLine("Информация заказа");
                Console.WriteLine();
                Console.WriteLine("Код товара: " + code_of_order);
                Console.WriteLine("Дата закакза: " + date);
                Console.WriteLine("перечень товара " );
                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". название товара: " + products[i].product.name +" - количество едениц товара: "
                        + products[i].number_of_product +" х " + products[i].product.price + "(цена)");
                }
                Console.WriteLine("сума за весь товар  " + this.Sum);

            }
        };

        static void Main(string[] args)
        {
            Client a = new Client();
            a.full_name = "Roman";
            a.code = 555;
            a.number_of_orders = 3;
            a.Type = ClientType.important;
           
          
            RequestItem g= new RequestItem();
            g.product= new Article(555, "apple", 5.55, ArticleType.foods);
            g.number_of_product = 2;
            RequestItem g1 = new RequestItem();
            g1.product = new Article(333, "the best game", 10.45, ArticleType.toys);
            g1.number_of_product = 1;
            RequestItem g2 = new RequestItem();
            g2.product = new Article(111, "cap", 25, ArticleType.clothes);
            g2.number_of_product = 1;
            DateTime x=DateTime.Today;
            RequestItem[] B=new RequestItem[] {g,g1,g2 };
            Request Test = new Request(1111, a, x, B, 0);
            Test.Print();
           

        }
    }
}
