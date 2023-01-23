using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankAccount
{
    public class bankAccount
    { 
        //Variables
        public string Number { get; set; } 
        public string Owner { get;} 
        public decimal balance { get; set;  }
        private static int accountNumber = 209; 
        private List<Transaction> alltransactions = new List<Transaction>(); 

        //Constructor
        public bankAccount(string xname, decimal xinitialDeposit, DateTime xdate)
        {
            this.Owner = xname;
            this.Number = accountNumber.ToString();
            accountNumber++;   
            //Balance 
            makeDeposit(xinitialDeposit, xdate,"Initial Deposit");
        }     


        //Methods  

        public void makeDeposit(decimal xamount, DateTime xdate, string xnote)
        {
            if(xamount < 0) 
            {  
                throw new ArgumentOutOfRangeException(nameof(xamount) , "Amount of deposit must be higher than 0");
            } 
            else
            {
                this.balance = this.balance + xamount;
                var deposit = new Transaction(xamount, xdate, xnote); 
                alltransactions.Add(deposit);
            } 
        } 

        public void Withdrawmoney(decimal xamount, DateTime xdate, string xnote)
        {
            if (xamount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(xamount), "Amount to withdraw must be higher than 0");
            } 
            if ((balance - xamount) < 0) 
            {
                throw new InvalidOperationException("Insuficient funds on account, please try again"); 
                
            }   
            else
            {
                this.balance = this.balance - xamount;
           
                var depositcorrect = new Transaction(xamount, xdate, xnote);
                alltransactions.Add(depositcorrect);
            }
        }  

        public string getAccountHistory()
        {
            var xreport = new StringBuilder();
            xreport.AppendLine("Date \t\t\t Amount \t\t Note"); 

            foreach(var report in alltransactions)  
            {
                xreport.AppendLine($"{report.Date} \t\t {report.Amount} \t\t {report.Note}"); 

            } 
            return xreport.ToString();
        }
         


    }
}
