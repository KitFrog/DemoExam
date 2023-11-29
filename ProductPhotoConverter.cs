using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MVVM_learn.Models.Converters
{
    public class ProductPhotoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            string productName = value as string;
            return GetPhotoByProductName(productName);
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }

        private object GetPhotoByProductName(string productName)
        {
            if (productName == "Отсутсвует")
            {
                return $"/Resources/picture.png";
            }

            return $"/Resources/{productName}";
        }
    }
}
