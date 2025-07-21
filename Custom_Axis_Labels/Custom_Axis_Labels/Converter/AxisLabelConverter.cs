using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Axis_Labels
{
    public class AxisLabelConverter : IValueConverter
    {
        ViewModel viewModel = new ViewModel();
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ChartAxisLabel chartAxisLabel = value as ChartAxisLabel;
            if (viewModel != null && chartAxisLabel != null)
            {
                Model item = viewModel.Data[(int)chartAxisLabel.Position];
                var label = ((item.Sales - item.Target) / item.Target);
                return chartAxisLabel.Content + " => " + label.ToString("+#.00 %;-#.00 %;+0.00 %");
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
