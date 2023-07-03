# How-to-add-custom-axis-label-in-WinUI-SfCartesianChart.

This article explains how to add custom axis labels in [WinUI (SfCartesianChart)](https://help.syncfusion.com/winui/cartesian-charts/getting-started).

The [axis labels](https://help.syncfusion.com/winui/cartesian-charts/axis/axislabels) in WinUI (SfCartesianChart) are generated based on the range and data point values binding to the [XBindingPath](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeries.html#Syncfusion_UI_Xaml_Charts_ChartSeries_XBindingPath) and [YBindingPath](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.CircularSeries.html#Syncfusion_UI_Xaml_Charts_CircularSeries_YBindingPath) properties of the Cartesian series.

To add the custom axis labels, you can utilize the [LabelCreated](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartAxis.html#Syncfusion_UI_Xaml_Charts_ChartAxis_LabelCreated) event in the ChartAxis. In the LabelCreated event, you can add the custom axis label using the [ChartAxisLabelEventArgs](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartAxisLabelEventArgs.html), as shown in the provided code snippet.

**[Xaml]**

```
<chart:SfCartesianChart >
…
        <chart:SfCartesianChart.XAxes>
            <chart:CategoryAxis   LabelCreated="CategoryAxis_LabelCreated"   >
            </chart:CategoryAxis>
        </chart:SfCartesianChart.XAxes>

        <chart:SfCartesianChart.YAxes>
            <chart:NumericalAxis   LabelCreated="NumericalAxis_LabelCreated" />
        </chart:SfCartesianChart.YAxes>

        <chart:ColumnSeries Fill="Orange"  XBindingPath="Month" YBindingPath="Sales" ItemsSource="{Binding Data}" />
    </chart:SfCartesianChart>

```

**[C#]**

```
public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

        }

        private void CategoryAxis_LabelCreated(object sender, Syncfusion.UI.Xaml.Charts.ChartAxisLabelEventArgs e)
        {
            var axis = sender as CategoryAxis;
            if (axis != null)
            {
                ViewModel viewModel = axis.DataContext as ViewModel;
                if (viewModel != null)
                {
                    Model value = viewModel.Data[(int)e.Position];
                    var label = ((value.Sales - value.Target) / value.Target);
                    e.Label = e.Label + " => " + label.ToString("+#.00 %;-#.00 %;+0.00 %");
                   
                }
            }
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

[Download the complete sample in GitHub](https://github.com/SyncfusionExamples/How-to-add-custom-axis-label-in-WinUI-SfCartesianChart).

**Output:**

 
 ![AxisLabel.png](https://support.syncfusion.com/kb/agent/attachment/article/13013/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6Ijc5NzIiLCJvcmdpZCI6IjMiLCJpc3MiOiJzdXBwb3J0LnN5bmNmdXNpb24uY29tIn0.-vdghEI9U-NU11bpD9aK21UYXtp5ey2Vk_ujCR-aPbI)