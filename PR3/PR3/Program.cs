using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR3
{
    class Expense
    {
        int expenseId; string category; double amount; public void GetExpenseDetails()
        {
            Console.Write("Enter Expense ID: ");
            expenseId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Expense Category: ");
            category = Console.ReadLine(); Console.Write("Enter Expense Amount: ");
            amount = Convert.ToDouble(Console.ReadLine());
            // Manual Exception 
            if (amount < 0)
            {
                throw new Exception("Expense Amount cannot be less than 0.");
            }
        }
        public void ShowExpenseDetails()
        {
            Console.WriteLine("\n----- Expense Details -----");
            Console.WriteLine("Expense ID : " + expenseId);
            Console.WriteLine("Category : " + category);
            Console.WriteLine("Expense Amount : Rs." + amount);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Expense e = new Expense();
            try
            {
                e.GetExpenseDetails();
                e.ShowExpenseDetails();
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Exception: Please enter valid numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Manual Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nProgram Executed Successfully.");
            }
            Console.ReadKey();
        }
    }
}