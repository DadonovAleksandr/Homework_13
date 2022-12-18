using System;

namespace Homework_13.Models.BankAccounts;

internal class BankAccount
{
    #region Id

    private readonly string _id;
    /// <summary>
    /// Идентификатор счета
    /// </summary>
    public string Id => _id;

    #endregion
    
    #region Деньги на счете
    protected double _account;
    /// <summary>
    /// Деньги на счете
    /// </summary>
    public double Account => _account;
    #endregion
    
    public BankAccount()
    {
        _id = Guid.NewGuid().ToString();;
    }

    
    
}