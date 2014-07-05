using System;
using System.Linq;
using System.Reflection;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Data;

namespace EnumTranslateToList.Converters
{
    public class EnumTypeToListConverter : IValueConverter
    {
        private static readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            var enumType = value as Type;
            if (enumType == null || !enumType.GetTypeInfo().IsEnum)
                return null;

            var values = Enum.GetValues((Type)value).Cast<Enum>();

            return values.Select(item => resourceLoader.GetString(string.Format("{0}_{1}", enumType.Name, item))).ToList();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
