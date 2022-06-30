using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using InputPersonInfo.Lib;

namespace InputPersonInfo
{
    
    public partial class MainWindow : Window
    {
        private Person _person;
        public MainWindow()
        {
            _person = new Person();
            InitializeComponent();
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            TBox_FirstName.Clear();
            TBox_LastName.Clear();
            TBox_Patronymic.Clear();
            TBox_Age.Clear();
            TBox_DataBirth.Clear();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            _person.FirstName = TBox_FirstName.Text;
            _person.LastName = TBox_LastName.Text;
            _person.Patronymic = TBox_Patronymic.Text;
            int age;
            int.TryParse(TBox_Age.Text, out age);
            _person.Age = age;
            DateTime date;
            DateTime.TryParse(TBox_DataBirth.Text, out date);
            _person.DateBirth = date;
        }

        private void Button_WriteToFile_Click(object sender, RoutedEventArgs e)
        {
            using var file = new FileStream("person.json", FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.SerializeAsync(file, _person);           
        }
    }
}
