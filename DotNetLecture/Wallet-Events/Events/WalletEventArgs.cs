namespace Wallet_Events.Events
{
    public class WalletEventArgs
    {
        // Wallet action message
        public string ActionMessage { get; }

        // Amount of money on which wallet balance changed 
        public int Amount { get; }

        public WalletEventArgs(string actionMessage, int amount)
        {
            ActionMessage = actionMessage;
            Amount = amount;
        }
    }
}
