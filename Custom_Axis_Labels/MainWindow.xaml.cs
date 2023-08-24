using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Charts;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Custom_Axis_Labels
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
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
    }

    public class Model
    {
        public string Month { get; set; }
        public double Target { get; set; }
        public double Sales { get; set; }
    }

    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }
        public ViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model() {Target = 1000,Sales = 600,Month = "Jan"},
                new Model() { Target = 1000,Sales = 870,Month = "Feb"},
                new Model() {Target = 1000,Sales = 1230,Month = "Mar"},
                new Model() {Target = 1000,Sales = 755,Month="Apr"},
                new Model() {Target = 1000,Sales = 1199,Month = "May"},
                new Model() {Target = 1000,Sales = 645,Month = "Jun"},
                new Model() {Target = 1000,Sales = 712,Month = "Jul"},
                new Model() {Target = 1000,Sales = 1030,Month = "Aug"},
                new Model() {Target = 1000,Sales = 755,Month = "Sep"},
                new Model() {Target = 1000,Sales = 1299,Month = "Oct"},
                new Model() {Target = 1000,Sales = 645,Month = "Nov"},
                new Model() {Target = 1000,Sales = 712,Month = "Dec"},
            };

        }
    }

}
