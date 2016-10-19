using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Addressbook.Domain.ValueTypes;


namespace Addressbook.Addressbook
{
    public class EmailToStringConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType()==typeof(Email))
            {
                var email = (Email) value;
                return email.Value;

            }

            throw new Exception($"Du är fan sämst");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
