using System;

namespace Builder
{
    public class BankAccount
    {
        private BankAccount() { }
        private long accountNumber;
        private String owner;
        private double balance;

        public void ShowData()
        {
            Console.WriteLine(accountNumber + " " + owner + " " + balance);
        }

        public class BankAccountBuilder
        {
            BankAccount bankAccount;
            public BankAccountBuilder(long accountNumber)
            {
                bankAccount = new BankAccount();
                bankAccount.accountNumber = accountNumber;
            }
            public BankAccountBuilder SetOwner(String owner)
            {
                bankAccount.owner = owner;
                return this;
            }
            public BankAccountBuilder SetBalance(double balance)
            {
                bankAccount.balance = balance;
                return this;
            }
            public BankAccount Build()
            {
                return bankAccount;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Builder>");
            BankAccount ba = new BankAccount.BankAccountBuilder(123L)
                            .SetOwner("Pepe")
                            .SetBalance(3000.0)
                            .Build();
            ba.ShowData();
        }
    }
}
