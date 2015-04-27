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
using System.Runtime.Serialization.Json;
using System.IO;

namespace Autos
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

        private void Do()
        {
            PassengerCar pc = new PassengerCar();
            pc.Name = "Nissan GTR";
            pc.Number = "9999 AB";
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PassengerCar));
            FileStream fs = File.OpenWrite(@"C:/Users/Valentin/Desktop/json.txt");
            ser.WriteObject(fs, pc);
            fs.Dispose();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Do();
            TextBox1.Text = File.ReadAllText(@"C:/Users/Valentin/Desktop/json.txt");
        }
    }
}
