namespace Homework_13.Models.BankAccounts.Accounts;

/// <summary>
/// Зарплатный счет
/// </summary>
internal class SalaryAccount : BankAccount
{
    #region Деньги на счете
    private double _account;
    /// <summary>
    /// Деньги на счете
    /// </summary>
    public double Account => _account;
    #endregion
    
    
    /// <summary>
    /// Зарплатный счет
    /// </summary>
    public SalaryAccount()
    {
        
    }
}