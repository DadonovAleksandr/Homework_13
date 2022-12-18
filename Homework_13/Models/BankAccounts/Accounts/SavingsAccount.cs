namespace Homework_13.Models.BankAccounts.Accounts;

/// <summary>
/// Сберегательный счет
/// </summary>
internal class SavingsAccount : BankAccount
{
    #region Процент по дипозиту
    private readonly double _percent;
    /// <summary>
    /// Процент по дипозиту
    /// </summary>
    public double Precent => _percent;
    #endregion
    
    
    /// <summary>
    /// Сберегательный счет
    /// </summary>
    public SavingsAccount(double percent, double account = 0)
    {
        _percent = percent;
        _account = 0;
    }
    
}