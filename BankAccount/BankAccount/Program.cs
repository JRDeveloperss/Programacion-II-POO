using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        { 
            //Abrir cuenta
            bankAccount CBJeremy = new bankAccount("Jeremy", 1000, DateTime.Now);
            Console.WriteLine($"Felicitaciones {CBJeremy.Owner} acaba de crear su cuenta con un deposito inicial{CBJeremy.balance} "); 

            //Deposito a cuenta
            CBJeremy.makeDeposit(400, DateTime.Now, "Cobro de prestamo de Auto");

            Console.WriteLine($"Estimado {CBJeremy.Owner} debido a esta transaccion {CBJeremy.balance}");

            //Retiro 

            CBJeremy.Withdrawmoney(400, DateTime.Now, "Retiro para pago universidad");
            Console.WriteLine($"Estimado {CBJeremy.Owner} debido a esta transaccion {CBJeremy.balance}");

            //Historial 

            Console.WriteLine(" =========== HISTORIAL DE CUENTA =========== ");
            Console.WriteLine(CBJeremy.getAccountHistory());
            Console.WriteLine($"Estimado {CBJeremy.Owner} su balance final es {CBJeremy.balance}");
            Console.ReadKey(); 
        }
    }
}
