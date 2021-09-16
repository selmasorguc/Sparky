namespace Sparky
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        {
            Balance = 0;
            _logBook = logBook;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked"); //true
            _logBook.Message(""); //false
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= Balance)
            {
                _logBook.LogToDb("Withdrawl amount: " + amount.ToString());
                Balance -= amount;
                return _logBook.LogBalanceAfterWithdrawl(Balance);
            }
            return _logBook.LogBalanceAfterWithdrawl(Balance - amount); ;
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
