using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Day_9
{
    /// <summary>
    /// Represents a bank account with basic deposit and withdrawal functionality.
    /// </summary>
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        /// <summary>
        /// Deposits the specified amount into the bank account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance += amount;
        }

        /// <summary>
        /// Withdraws the specified amount from the bank account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <exception cref="InsufficientBalanceException">Thrown when the withdrawal amount exceeds the available balance.</exception>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Insufficient balance for the withdrawal.");
            }
            Balance -= amount;
        }
    }
    
}
