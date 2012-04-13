using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Configuration;

namespace WpfApplication6.Converter
{
  public  class StorageConverter:IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            Guid storageId = (Guid)value;
            if (storageId == Guid.Empty) return null;
            return CaculateLibrary.StorageModule.GetStorageByCode(ConfigManager.StorageFileName, storageId).Code;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
