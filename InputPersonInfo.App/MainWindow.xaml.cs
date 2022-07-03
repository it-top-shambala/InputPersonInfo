using System;
using System.IO;
using System.Text.Json;
using System.Windows;
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
            FetchInput();
            ClearAll();
        }

        private void Button_ExportToFile_OnClick(object sender, RoutedEventArgs e)
        {
            using var file = new FileStream("person.json", FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.SerializeAsync(file, _person);
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            if (!IsEmpty())
            {
                Button_Clear.IsEnabled = false;
            }
            else
            {
                Button_Clear.IsEnabled = true;
            }
        }

        private void ClearAll()
        {
            Input_FirstName.Clear();
            Input_LastName.Clear();
            Input_Age.Clear();
            Patronymic_TextBox.Clear();
            DatePicker.SelectedDate = null;
        }

        private bool IsEmpty()
        {
            var user = (Person)GetAllPerson().Clone();
            if (
                user.FirstName != String.Empty ||
                user.LastName != String.Empty ||
                (user?.Age != null && user.Age != 0) ||
                user?.Patronymic != String.Empty
            )
            {
                return true;
            }
            return false;
        }

        private Person GetAllPerson()
        {
            int.TryParse(Input_Age.Text, out var age);
            return new Person()
            {
                FirstName = Input_FirstName.Text,
                LastName = Input_LastName.Text,
                Age = age,
                Patronymic = Patronymic_TextBox.Text,
                SelectedDate = DatePicker.SelectedDate
            };
        }
        private void FetchInput()
        {
            _person.FirstName = Input_FirstName.Text;
            _person.LastName = Input_LastName.Text;
            int.TryParse(Input_Age.Text, out var age);
            _person.Age = age;
            _person.Patronymic = Patronymic_TextBox.Text;
            _person.SelectedDate = DatePicker.SelectedDate;
        } 
    }
}