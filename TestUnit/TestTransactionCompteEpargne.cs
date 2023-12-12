using BanqueAcmc;

namespace TestUnit;

[TestClass]

public class TestTransactionCompteEpargne
{
    // Ajouter argent
    [TestMethod]
    public void Call_3_times_AjouterArgent_make_3_transactions()
    {
        // Arrange
        CompteEpargne CompteEpargneToTest = new CompteEpargne();
        CompteEpargneToTest.AjouterArgent(100);
        CompteEpargneToTest.AjouterArgent(200);
        CompteEpargneToTest.AjouterArgent(300);

        // Act
        List<Transaction> transactions = CompteEpargneToTest.TransactionList;

        // Assert
        Assert.AreEqual(3, transactions.Count);
        Assert.AreEqual("Dépôt", transactions[0].Type);
        Assert.AreEqual(100, transactions[0].Montant);
        Assert.AreEqual("Dépôt", transactions[1].Type);
        Assert.AreEqual(200, transactions[1].Montant);
        Assert.AreEqual("Dépôt", transactions[2].Type);
        Assert.AreEqual(300, transactions[2].Montant);

    }

    [TestMethod]
    public void Call_AjouterArgent_with_negative_amount_return_false()
    {
        // Arrange
        CompteEpargne CompteEpargneToTest = new CompteEpargne();

        // Act
        bool result = CompteEpargneToTest.AjouterArgent(-100);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Call_AjouterArgent_with_positive_amount_return_true()
    {
        // Arrange
        CompteEpargne CompteEpargneToTest = new CompteEpargne();

        // Act
        bool result = CompteEpargneToTest.AjouterArgent(100);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Call_AjouterArgent_with_positive_amount_add_amount_to_Solde()
    {
        // Arrange
        CompteEpargne CompteEpargneToTest = new CompteEpargne();

        // Act
        CompteEpargneToTest.AjouterArgent(100);

        // Assert
        Assert.AreEqual(100, CompteEpargneToTest.Solde);
    }


}