namespace Homework_13.Models.BankAccounts.Accounts;

/// <summary>
/// Депозитный счет
/// </summary>
internal class DepositAccount : BankAccount
{
    #region Процент по дипозиту
    private readonly double _percent;
    /// <summary>
    /// Процент по дипозиту
    /// </summary>
    public double Precent => _percent;
    #endregion
    
    
    /// <summary>
    /// Депозитный счет
    /// </summary>
    public DepositAccount(double percent, double account = 0)
    {
        _percent = percent;
        _account = 0;
    }
}