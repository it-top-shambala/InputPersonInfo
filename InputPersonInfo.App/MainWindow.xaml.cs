using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using InputPersonInfo.Lib;

namespace InputPersonInfo.App
{
    public partial class MainWindow : Window
    {
        private readonly Person _person;
        
        public MainWindow()
        {
            _person = new Person();
            
            InitializeComponent();
        }

        private void Button_Clear_OnClick(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void Button_Save_OnClick(object sender, RoutedEventArgs e)
        {
            _person.FirstName = Input_FirstName.Text;
            _person.LastName = Input_LastName.Text;
            
            int.TryParse(Input_Age.Text, out var age);
            _person.Age = age;
            
            ClearAll();
        }

        private void Button_ExportToFile_OnClick(object sender, RoutedEventArgs e)
        {
            using var file = new FileStream("person.json", FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.SerializeAsync(file, _person);
        }
        
        private void ClearAll()
        {
            Input_FirstName.Clear();
            Input_LastName.Clear();
            Input_Age.Clear();
        }

        private void Input_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var flagFirstname = string.IsNullOrWhiteSpace(Input_FirstName.Text);
            var flagLastname = string.IsNullOrWhiteSpace(Input_LastName.Text);
            var flagAge = string.IsNullOrWhiteSpace(Input_Age.Text);

            if (flagFirstname && flagLastname && flagAge)
            {
                Button_Clear.IsEnabled = false;
            }
            else
            {
                Button_Clear.IsEnabled = true;
            }
        }
    }
}