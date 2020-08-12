using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JsonpathTester
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

        private void path_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoPathTest();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoPathTest();
        }

        private void DoPathTest()
        {
            string payload = input.Text;
            string jsonPath = path.Text;

            if (string.IsNullOrEmpty(payload)) return;
            if (string.IsNullOrEmpty(jsonPath)) return;

            JObject sourceJson = JObject.Parse(payload);

            try
            {
                JToken token = sourceJson.SelectToken(jsonPath);
                string jsonResult = token.ToString();

                output.Text = jsonResult;
            }
            catch (Exception)
            {
                output.Text = string.Empty;
            }
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            input.Clear();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(input.Text);
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            input.Text = Clipboard.GetText();
        }
    }
}
