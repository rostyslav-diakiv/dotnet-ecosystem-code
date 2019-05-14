using System;
using System.IO;

namespace Wallet_Events.Events
{
    public struct Wallet
    {
        // Define an delegate
        public delegate void WalletStateHandler(object sender, WalletEventArgs e);

        // Events, that fires when wallet balance is toped up
        public event WalletStateHandler ToppedUp;

        // Events, that fires when somebody withdraw money form a wallet balance
        public event WalletStateHandler Withdrawn;

        // Private field that stores amount of money in wallet
        private int _balance;

        public Wallet(int amount)
        {
            _balance = amount;
            ToppedUp = null;
            Withdrawn = null;
        }

        public void TopUp(int amount)
        {
            _balance += amount;
            var args = new WalletEventArgs($"The wallet was topped up on {amount} of money", amount);
            ToppedUp?.Invoke(this, args); // null condition operator
        }

        public void Withdraw(int amount)
        {
            if (_balance < amount)
            {
                var args = new WalletEventArgs($"Not enough money on wallet's balance", amount);
                Withdrawn?.Invoke(this, args);
            }
            else
            {
                _balance -= amount;
                var args = new WalletEventArgs($"{amount} of money was withdrawned from the wallet", amount);
                Withdrawn?.Invoke(this, args);
            }
        }
    }
}
