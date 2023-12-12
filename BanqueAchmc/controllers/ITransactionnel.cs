namespace BanqueAcmc;

internal interface ITransactionnel
{    
    bool AjouterArgent(decimal montant);

    bool RetirerArgent(decimal montant);

    bool VoirSolde();

    bool VoirHistorique();

}
