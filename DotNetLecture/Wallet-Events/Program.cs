using System;
using Wallet_Events.Events;

namespace Wallet_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet(100);

            // Add event handlers
            wallet.ToppedUp += Log_TopUp;
            wallet.Withdrawn += delegate(object sender, WalletEventArgs e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Withdrawn: {e.Amount}");
                Console.WriteLine(e.ActionMessage);
            };

            wallet.Withdraw(90);

            wallet.Withdraw(20);

            wallet.TopUp(50);

            // Remove Top Up event handler
            wallet.ToppedUp -= Log_TopUp;

            wallet.TopUp(100);
        }

        private static void Log_TopUp(object sender, WalletEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Top up amount: {e.Amount}");
            Console.WriteLine(e.ActionMessage);
        }
    }
}