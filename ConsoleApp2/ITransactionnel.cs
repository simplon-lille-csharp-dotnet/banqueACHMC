namespace ConsoleApp2;

internal interface ITransactionnel
{
    decimal AjouterArgent(decimal montant);
    decimal RetirerArgent(decimal montant);
    decimal VoirSolde();
}
