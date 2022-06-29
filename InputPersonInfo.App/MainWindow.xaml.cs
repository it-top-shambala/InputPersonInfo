using System.IO;
using System.Text.Json;
using System.Windows;
using InputPersonInfo.Lib;

namespace InputPersonInfo.App
{
    public partial class MainWindow : Window
    {
        private Person _person;
        
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
            
            int.TryParse(Input_Age.Text, out int age);
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
    }
}