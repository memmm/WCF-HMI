using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HmiStyle.Symbols
{
    public class CheckNullConverter : IValueConverter
    {
        public enum type
        {
            Boolean = 1,
            Visibility = 2,
            String = 3,
            Integer = 4,
        }

        private object _bIsNullValue = false;
        private object _bIsNotNullValue = true;
        private type _type = type.Boolean;

        public type TypeConverter
        {
            get { return _type; }
            set { _type = value; }
        }

        public object IsNullValue
        {
            get { return _bIsNullValue; }
            set { _bIsNullValue = Convert(value.ToString()); }
        }

        public object IsNotNullValue
        {
            get { return _bIsNotNullValue; }
            set { _bIsNotNullValue = Convert(value.ToString()); }
        }


        private object Convert(string sValue)
        {
            switch (_type)
            {
                case type.Boolean:
                    Boolean bReturn;
                    Boolean.TryParse(sValue, out bReturn);
                    return bReturn;

                case type.Visibility:
                    Visibility vReturn;
                    Enum.TryParse(sValue, true, out vReturn);
                    return vReturn;

                case type.Integer:
                    Int32 iReturn;
                    Int32.TryParse(sValue, out iReturn);
                    return iReturn;

                case type.String:
                    return sValue;
            }

            return sValue;
        }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return _bIsNotNullValue;
            }

            return value == null ? _bIsNullValue : _bIsNotNullValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
