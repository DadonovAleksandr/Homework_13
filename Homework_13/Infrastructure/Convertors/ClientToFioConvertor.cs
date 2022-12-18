using System;
using System.Globalization;
using System.Windows.Data;
using Homework_13.Models.Clients;

namespace Homework_13.Infrastructure.Convertors;

public class ClientToFioConvertor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is Client client)) return null;
        return $"{client.LastName} {client.FirstName} {client.MiddleName}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}