namespace ConsoleApp2
{
    /// <summary>
    /// Represents a transaction in the bank.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets the type of the transaction.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the amount of the transaction.
        /// </summary>
        public decimal Montant { get; }

        /// <summary>
        /// Gets the date of the transaction.
        /// </summary>
        public string Date { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="type">The type of the transaction.</param>
        /// <param name="montant">The amount of the transaction.</param>
        public Transaction(string type, decimal montant)
        {
            Type = type;
            Montant = montant;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Returns a string that represents the current transaction.
        /// </summary>
        /// <returns>A string that represents the current transaction.</returns>
        public override string ToString()
        {
            return $"{Date} - {Type}: {Montant} €";
        }
    }
}
