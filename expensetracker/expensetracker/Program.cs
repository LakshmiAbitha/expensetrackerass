using System.Collections.Generic;

namespace expensetracker
{
    class Expensetracker
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateOnly Date { get; set; }
    }
    class Details
    {
        public List<Expensetracker> list=new List<Expensetracker>();
        public void Addtrancation()
        {
            Console.WriteLine("Enter the title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the amount");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the date");
            DateOnly date = DateOnly.Parse(Console.ReadLine());
            list.Add(new Expensetracker() { Title = title, Description = description, Amount = amount, Date = date });
            Console.WriteLine("New transaction is added Sucessfully");
        }
        public void Viewexpneses()
        {
            Console.WriteLine("The expenses transcations are following");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            var res= list.Where(x=>x.Amount < 0);
            foreach (var t in res)
            {
                Console.WriteLine($"{t.Title}\t{t.Description}\t\t{t.Amount}\t{t.Date}");
            }
        }
        public void ViewIncome()
        {
            Console.WriteLine("The income transcations are following");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            var res1= list.Where(x=>x.Amount > 0);
            foreach(var t in res1)
            {
                Console.WriteLine($"{t.Title}\t{t.Description}\t\t{t.Amount}\t{t.Date}");
            }
        }
        public double Checkbalance()
        {
            return list.Sum(x =>x.Amount);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Details obj= new Details();
            string res = "";
            do
            {
                Console.WriteLine("1.Add transcation");
                Console.WriteLine("2.view expenses");
                Console.WriteLine("3.View income");
                Console.WriteLine("4.Check available balance");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            obj.Addtrancation();
                            break;
                        }
                    case 2:
                        {
                            obj.Viewexpneses();
                            break;
                        }
                    case 3:
                        {
                            obj.ViewIncome();
                            break;
                        }
                    case 4:
                        {
                            double bal=obj.Checkbalance();
                            Console.WriteLine($"Avaiable balance is: {bal}");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(" Wrong Choice Entered");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue[y/n]");
                res = Console.ReadLine();
            } while (res.ToLower() == "y");
        }
    }
}