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
using System.Web.Script.Serialization;
using System.IO;

namespace Autos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Func<Car>> carTypes = new Dictionary<string, Func<Car>>();
        private Dictionary<string, int> typeIndexes = new Dictionary<string, int>();
        private List<Car> cars = new List<Car>();
        CarObjects carObjectsCreator = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonNewCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car newCar = carTypes[(string)comboBoxCarTypes.Text]();
                FillCarState(newCar);
                cars.Add(newCar);
                comboBoxCars.Items.Add(newCar.Name + " " + newCar.Number);
                comboBoxCars.SelectedIndex = comboBoxCars.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillPassengerCarState(PassengerCar pc)
        {
            pc.TotalSeats = int.Parse(textBoxTotalSeats.Text);
            pc.PassengersCount = int.Parse(textBoxPassengers.Text);
            pc.FrontDrive = checkBoxFrontDrive.IsChecked ?? false;
        }

        private void FillAmbulanceCarState(Ambulance ambulance)
        {
            ambulance.CallNumber = textBoxCallNumber.Text;
            ambulance.Flasher.IsOn = checkBoxFlasherOn.IsChecked ?? false;
        }

        private void FillTrailerTruckState(TrailerTruck ttruck)
        {
            ttruck.Goods = textBoxGoods.Text;
            ttruck.MaxTrailerWeight = int.Parse(textBoxTrailerWeight.Text);
            ttruck.TrailerWeight = int.Parse(textBoxMaxTrailerWeight.Text);
            ttruck.HasTrailer = checkBoxHasTrailer.IsChecked ?? false;
        }

        private void FillCarState(Car newCar)
        {
            newCar.Name = textBoxName.Text;
            newCar.Number = textBoxNumber.Text;
            newCar.MaxSpeed = int.Parse(textBoxMaxSpeed.Text);
            newCar.Speed = int.Parse(textBoxSpeed.Text);
            newCar.HorsePower = int.Parse(textBoxHP.Text);
            newCar.Weight = int.Parse(textBoxWeight.Text);
            newCar.Color = textBoxColor.Text;
            newCar.EngineOn = checkBoxEngineOn.IsChecked ?? false;
        }

        private void Load_Loaded(object sender, RoutedEventArgs e)
        {
            InitTextBoxes();
            carObjectsCreator = new CarObjects(FillPassengerCarState,
                FillTrailerTruckState, FillAmbulanceCarState);
            carTypes.Add("Passenger car", carObjectsCreator.GetPassengerCar);
            carTypes.Add("Ambulance", carObjectsCreator.GetAmbulance);
            carTypes.Add("Trailer truck", carObjectsCreator.GetTrailerTruck);

            typeIndexes.Add("Passenger car", 0);
            typeIndexes.Add("Ambulance", 1);
            typeIndexes.Add("Trailer truck", 2);
        }

        private void InitTextBoxes()
        {
            textBoxFilePath.Resources.Add("default value", "file path");
            textBoxHP.Resources.Add("default value", "Horse power");
            textBoxCallNumber.Resources.Add("default value", "Call number");
            textBoxNumber.Resources.Add("default value", "Number");
            textBoxName.Resources.Add("default value", "Name");
            textBoxColor.Resources.Add("default value", "Color");
            textBoxMaxSpeed.Resources.Add("default value", "Max speed");
            textBoxSpeed.Resources.Add("default value", "Speed");
            textBoxWeight.Resources.Add("default value", "Weight");
            textBoxTotalSeats.Resources.Add("default value", "Total seats");
            textBoxPassengers.Resources.Add("default value", "Passengers count");
            textBoxGoods.Resources.Add("default value", "Goods");
            textBoxMaxTrailerWeight.Resources.Add("default value", "Max trailer weight");
            textBoxTrailerWeight.Resources.Add("default value", "Trailer weight");
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
                ((TextBox)sender).Text = (string)((TextBox)sender).Resources["default value"];
        }

        private void buttonSerialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
                File.WriteAllText(textBoxFilePath.Text, serializer.Serialize(cars));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDeserialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
                cars = serializer.Deserialize<List<Car>>(File.ReadAllText(textBoxFilePath.Text));
                UpdateComboBoxList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateComboBoxList()
        {
            comboBoxCars.Items.Clear();
            foreach (Car car in cars)
            {
                comboBoxCars.Items.Add(car.Name + " " + car.Number);
            }
            if (comboBoxCars.Items.Count > 0)
            {
                comboBoxCars.SelectedIndex = comboBoxCars.Items.Count - 1;
            }
        }

        private void UpdateFields(Car car)
        {
            textBoxName.Text = car.Name;
            textBoxNumber.Text = car.Number;
            textBoxHP.Text = car.HorsePower.ToString();
            textBoxSpeed.Text = car.Speed.ToString();
            textBoxMaxSpeed.Text = car.MaxSpeed.ToString();
            textBoxWeight.Text = car.Weight.ToString();
            textBoxColor.Text = car.Color;
            checkBoxEngineOn.IsChecked = car.EngineOn;

            if (car is PassengerCar)
            {
                PassengerCar pcar = car as PassengerCar;
                textBoxTotalSeats.Text = pcar.TotalSeats.ToString();
                textBoxPassengers.Text = pcar.PassengersCount.ToString();
                checkBoxFrontDrive.IsChecked = pcar.FrontDrive;
            }
            if (car is TrailerTruck)
            {
                TrailerTruck ttruck = car as TrailerTruck;
                textBoxGoods.Text = ttruck.Goods;
                textBoxMaxTrailerWeight.Text = ttruck.MaxTrailerWeight.ToString();
                textBoxTrailerWeight.Text = ttruck.TrailerWeight.ToString();
                checkBoxHasTrailer.IsChecked = ttruck.HasTrailer;
            }

            if (car is Ambulance)
            {
                Ambulance ambulance = car as Ambulance;
                textBoxCallNumber.Text = ambulance.CallNumber;
                checkBoxFlasherOn.IsChecked = ambulance.Flasher.IsOn;
                checkBoxPatientInside.IsChecked = ambulance.PatientInside;
            }
        }

        private void comboBoxCars_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0)
            {
                UpdateFields(cars[((ComboBox)sender).SelectedIndex]);
                comboBoxCarTypes.SelectedIndex = typeIndexes[cars[((ComboBox)sender).SelectedIndex].TextualRepresentation];
            }
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cars.RemoveAt(((ComboBox)comboBoxCars).SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateComboBoxList();
        }

        private void buttonApply_Click(object sender, RoutedEventArgs e)
        {
            cars[((ComboBox)comboBoxCars).SelectedIndex] = carTypes[(string)comboBoxCarTypes.Text]();
            FillCarState(cars[((ComboBox)comboBoxCars).SelectedIndex]);
        }
    }
}
