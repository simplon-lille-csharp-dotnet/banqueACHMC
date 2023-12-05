namespace ConsoleApp2;

internal interface ITransactionnel
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="montant"></param>
    /// <returns>the balance</returns>
    
    bool AjouterArgent(decimal montant);
    bool RetirerArgent(decimal montant);
    bool VoirSolde();
}
