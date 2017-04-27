using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;
using System.Collections;

namespace UrbanDictionary.Xamarin.Droid.Converters
{
    public class EmptyToVisibilityConverter : IMvxValueConverter
    {
        public bool IsInvert { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isVisible = true;

            if (value == null)
            {
                isVisible = false;
            }
            else
            {
                if (value is ICollection)
                {
                    var collection = (ICollection)value;
                    isVisible = collection.Count > 0;
                }
                else if (value is byte)
                {
                    isVisible = IsDefaultValue<byte>(value);
                }
                else if (value is short)
                {
                    isVisible = IsDefaultValue<short>(value);
                }
                else if (value is int)
                {
                    isVisible = IsDefaultValue<int>(value);
                }
                else if (value is long)
                {
                    isVisible = IsDefaultValue<long>(value);
                }
                else if (value is double)
                {
                    isVisible = IsDefaultValue<double>(value);
                }
                else if (value is decimal)
                {
                    isVisible = IsDefaultValue<decimal>(value);
                }
                else if (value is string str)
                {
                    isVisible = !string.IsNullOrEmpty(str);
                }
                else if (value is DateTime)
                {
                    isVisible = IsDefaultValue<DateTime>(value);
                }
                else if (value is TimeSpan)
                {
                    isVisible = IsDefaultValue<TimeSpan>(value);
                }
            }

            return  isVisible ^ IsInvert ?
                   ViewStates.Visible : ViewStates.Gone;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private bool IsDefaultValue<T>(object value) where T : struct
        {
            return value?.Equals(default(T)) ?? true;
        }
    }
}