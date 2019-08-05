using Syncfusion.DataSource.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewSample
{
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = 0;
            var items = value as IEnumerable;
            if(items != null)
            {
                var groupitems = items.ToList<object>().ToList<object>();

                if (groupitems != null)
                {
                    for (int i = 0; i < groupitems.Count; i++)
                    {
                        var contact = groupitems[i] as Contacts;
                        string temp = null;
                        foreach(var charac in contact.ContactNumber)
                        {
                            if (charac != ',')
                                temp += charac;
                        }
                        var dd = System.Convert.ToInt32(temp);
                        result += dd;
                    }
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
