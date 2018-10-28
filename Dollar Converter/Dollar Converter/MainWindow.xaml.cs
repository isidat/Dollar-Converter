using System.ServiceModel;
using System.Windows;

namespace Dollar_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            WordTextBlock.Text = string.Empty;

            var number = NumberTextbox.Text;

            try
            {
                var service = new DollarConverterServiceReference.DollarConverterServiceClient();

                WordTextBlock.Text = service.ConvertNumberToWord(number);
            }
            catch (FaultException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
            }
        }
    }
}
