namespace ConsoleApp2;

/// <summary>
/// Represents an interface for performing transactional operations.
/// </summary>
internal interface ITransactionnel
{    
    /// <summary>
    /// Adds the specified amount of money to the account.
    /// </summary>
    /// <param name="montant">The amount of money to add.</param>
    /// <returns>True if the operation is successful, otherwise false.</returns>
    bool AjouterArgent(decimal montant);

    /// <summary>
    /// Withdraws the specified amount of money from the account.
    /// </summary>
    /// <param name="montant">The amount of money to withdraw.</param>
    /// <returns>True if the operation is successful, otherwise false.</returns>
    bool RetirerArgent(decimal montant);

    /// <summary>
    /// Displays the current balance of the account.
    /// </summary>
    /// <returns>True if the operation is successful, otherwise false.</returns>
    bool VoirSolde();

    /// <summary>
    /// Displays the transaction history of the account.
    /// </summary>
    /// <returns>True if the operation is successful, otherwise false.</returns>
    bool VoirHistorique();

}
