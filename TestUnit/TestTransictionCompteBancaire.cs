using ConsoleApp2;

namespace TestUnit;

[TestClass]
public class TestTransictionCompteBancaire
{
    // Ajouter argent
    [TestMethod]
    public void Call_3_times_AjouterArgent_make_3_transactions()
    {
        // Arrange
        CompteBancaire CompteBancaireToTest = new CompteBancaire();
        CompteBancaireToTest.AjouterArgent(100);
        CompteBancaireToTest.AjouterArgent(200);
        CompteBancaireToTest.AjouterArgent(300);

        // Act
        List<Transaction> transactions = CompteBancaireToTest.TransactionList;

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
        CompteBancaire CompteBancaireToTest = new CompteBancaire();

        // Act
        bool result = CompteBancaireToTest.AjouterArgent(-100);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Call_AjouterArgent_with_positive_amount_return_true()
    {
        // Arrange
        CompteBancaire CompteBancaireToTest = new CompteBancaire();

        // Act
        bool result = CompteBancaireToTest.AjouterArgent(100);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Call_AjouterArgent_with_positive_amount_add_amount_to_Solde()
    {
        // Arrange
        CompteBancaire CompteBancaireToTest = new CompteBancaire();
        decimal amount = 100;

        // Act
        CompteBancaireToTest.AjouterArgent(amount);

        // Assert
        Assert.AreEqual(amount, CompteBancaireToTest.Solde);
    }

    [TestMethod]
    public void Adding_money_with_more_than_2_decimal_places()
    {
        // Arrange
        CompteBancaire compteBancaireToTest = new CompteBancaire();
        decimal initialBalance = compteBancaireToTest.Solde;
        int initialTransactionCount = compteBancaireToTest.TransactionList.Count;

        // Act
        bool result = compteBancaireToTest.AjouterArgent(100.123m);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(initialBalance, compteBancaireToTest.Solde);
        Assert.AreEqual(initialTransactionCount, compteBancaireToTest.TransactionList.Count);
    }


    // Retirer argent
    [TestMethod]
    public void Call_RetirerArgent_with_negative_amount_return_false()
    {
        // Arrange
        CompteBancaire CompteBancaireToTest = new CompteBancaire();

        // Act
        bool result = CompteBancaireToTest.RetirerArgent(-100);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Call_RetirerArgent_with_positive_amount_return_true()
    {
        // Arrange
        CompteBancaire CompteBancaireToTest = new CompteBancaire();

        // Solde
        CompteBancaireToTest.AjouterArgent(100);
        // Act
        bool result = CompteBancaireToTest.RetirerArgent(100);

        // Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void test_add_zero_amount()
    {
        // Arrange
        CompteBancaire compte = new CompteBancaire();
        decimal initialBalance = compte.Solde;
        decimal amount = 0;

        // Act
        bool result = compte.AjouterArgent(amount);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(initialBalance, compte.Solde);
        Assert.AreEqual(0, compte.TransactionList.Count);
    }
    [TestMethod]
    public void test_add_negative_amount()
    {
        // Arrange
        CompteBancaire compte = new CompteBancaire();
        decimal initialBalance = compte.Solde;
        decimal amount = -100;

        // Act
        bool result = compte.AjouterArgent(amount);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(initialBalance, compte.Solde);
        Assert.AreEqual(0, compte.TransactionList.Count);
    }
    [TestMethod]
    public void test_add_amount_with_more_than_2_decimal_places()
    {
        // Arrange
        CompteBancaire compte = new CompteBancaire();
        decimal initialBalance = compte.Solde;
        decimal amount = 10.123M;

        // Act
        bool result = compte.AjouterArgent(amount);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(initialBalance, compte.Solde);
        Assert.AreEqual(0, compte.TransactionList.Count);
    }
    [TestMethod]
    public void test_view_balance()
    {
        // Arrange
        CompteBancaire compte = new CompteBancaire();
        decimal initialBalance = 1000;
        compte.Solde = initialBalance;

        // Act
        decimal balance = compte.VoirSolde();

        // Assert
        Assert.AreEqual(initialBalance, balance);
    }
    // Withdrawing 0 amount does not change balance and does not add transaction to history
    
    [TestMethod]
    public void test_withdraw_zero_amount()
    {
        // Arrange
        CompteBancaire compte = new CompteBancaire();
        decimal initialBalance = 500;
        compte.Solde = initialBalance;
        decimal amount = 0;

        // Act
        bool result = compte.RetirerArgent(amount);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(initialBalance, compte.Solde);
        Assert.AreEqual(0, compte.TransactionList.Count);
    }

}
