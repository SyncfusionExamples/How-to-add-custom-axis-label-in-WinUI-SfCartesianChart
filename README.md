# How to customize the axis labels of WinUI (SfCartesianChart).

This article explains how to customize axis labels in [WinUI (SfCartesianChart)](https://help.syncfusion.com/winui/cartesian-charts/getting-started).

By customizing the axis labels in a chart, you can display more meaningful and descriptive text along the axes, thereby enhancing the representation of the chart data. The following steps demonstrate this process.

## Method: 1

We can customize the axis labels by utilizing the [LabelTemplate](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartAxis.html#Syncfusion_UI_Xaml_Charts_ChartAxis_LabelTemplate) property with the help of a Converter, as shown in the following code snippet.

**[Xaml]**

```
<chart:SfCartesianChart >
…
      <chart:SfCartesianChart.Resources>
            <local:AxisLabelConverter x:Key="axisLabel" />
            <DataTemplate x:Key="labelTemplate">
                <Border BorderBrush="Gray"
				CornerRadius="5"
				BorderThickness="1">
                    <TextBlock Text="{Binding Converter={StaticResource axisLabel}}"
					   FontSize="13"
					   FontWeight="Medium" 
					   Margin="2"/>
                </Border>
            </DataTemplate>
        </chart:SfCartesianChart.Resources> 
 <chart:SfCartesianChart.XAxes>
            <chart:CategoryAxis LabelTemplate="{StaticResource labelTemplate}"  >
                <chart:CategoryAxis.LabelStyle>
                    <chart:LabelStyle FontSize="15"  />
                </chart:CategoryAxis.LabelStyle>
            </chart:CategoryAxis>
        </chart:SfCartesianChart.XAxes>
...
    </chart:SfCartesianChart>

```

Customize the axis label by using the [ChartAxisLabel](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartAxisLabel.html) properties in the AxisLabelConverter, which is inherited from IValueConverter. 

```
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

```

## Method: 2

Additionally, we can modify the axis label by utilizing the LabelCreated event and the properties of [ChartAxisLabelEventArgs](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartAxisLabelEventArgs.html), as demonstrated in the provided code snippet.

**[Xaml]**

```
<chart:SfCartesianChart >
…
        <chart:SfCartesianChart.YAxes>
            <chart:NumericalAxis   LabelCreated="NumericalAxis_LabelCreated" />
        </chart:SfCartesianChart.YAxes>

    </chart:SfCartesianChart>

```

Customize the axis label using the [LabelCreated](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartAxis.html#Syncfusion_UI_Xaml_Charts_ChartAxis_LabelCreated) event.

**[C#]**

 ```
 public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

        }

        private void NumericalAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
        { 
            var axis = sender as NumericalAxis;
            if (axis != null)
            {
                var axisValue = double.Parse(e.Label);

                if (axisValue < 250)
                {
                    e.Label = "Very Low";
                }
                else if (axisValue >= 250 && axisValue < 500)
                {
                    e.Label = "Low";
                }
                else if (axisValue >= 500 && axisValue < 750)
                {
                    e.Label = "Average";
                }
                else if (axisValue >= 750 && axisValue < 1000)
                {
                    e.Label = "High";
                }
                else if (axisValue >= 1000)
                {
                    e.Label = "Very High";
                }

            }
        }

 ```

**Output:**

  
 ![CustomAxisLabels.png](https://support.syncfusion.com/kb/agent/attachment/article/13013/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjgwNjEiLCJvcmdpZCI6IjMiLCJpc3MiOiJzdXBwb3J0LnN5bmNmdXNpb24uY29tIn0.BYYpOdxW4g9OVM2RQRXTaCwarfTsG-5sMozYW78WFA8)

 KB link - [How-to-add-custom-axis-label-in-WinUI-SfCartesianChart](https://support.syncfusion.com/kb/article/13013/how-to-customize-the-axis-labels-of-winui-chart-sfcartesianchart).