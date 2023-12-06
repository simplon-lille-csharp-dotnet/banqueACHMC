namespace ConsoleApp2;

internal interface ITransactionnel
{    
    bool AjouterArgent(decimal montant);
    bool RetirerArgent(decimal montant);
    bool VoirSolde();
}
