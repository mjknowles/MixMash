using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Converters
{
    public class AttribValueNormalizerConverter : MvxValueConverter<float, int>
    {
        protected override int Convert(float value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return System.Convert.ToInt32(value * 100);
        }

        protected override float ConvertBack(int value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return value / 100f;
        }
    }
}
