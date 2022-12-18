namespace Homework_13.Models.BankAccounts.Accounts;

/// <summary>
/// Кредитный счет
/// </summary>
internal class CreditAccount : BankAccount
{
    #region Процент по кредиту
    private readonly double _percent;
    /// <summary>
    /// Процент по кредиту
    /// </summary>
    public double Precent => _percent;
    #endregion
    
    
    /// <summary>
    /// Депозитный счет
    /// </summary>
    public CreditAccount(double percent, double account)
    {
        _percent = percent;
        _account = 0;
    }
}