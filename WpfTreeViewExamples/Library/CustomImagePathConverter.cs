using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfTreeViewExamples.Library
{
    public class CustomImagePathConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "../Images/" + GetImageName(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "";
        }

        #endregion

        private string GetImageName(string text)
        {

            string name = "";

            name = text.ToLower() + ".png";
            ////switch (text.ToLower() )
            ////{
            ////    case "usa":
            ////        {
            ////            name = "usa.png";
            ////            break;
            ////        }
            ////    default:
            ////        {
            ////            name = text.ToLower()+ ".png";
            ////            break;
            ////        }
            ////}

            return name;

        }
    }
}
