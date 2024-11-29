using FitTrack.Classes.BaseClasses;
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
using System.Windows.Shapes;

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private UserManagement manager;
        public UserDetailsWindow(UserManagement manager)
        {
            InitializeComponent();
            this.manager = manager;
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //stänger fönstret.
        }
    }

    public partial class UserDetailsWindow : Window
    {
        public string CurrentUsername { get; set; } = "CurrentUser"; // För demoändamål
        public string CurrentCountry { get; set; } = "Sweden"; // För demoändamål

        public UserDetailsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = NewUsernameTextBox.Text.Trim();
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            // Validering av användarnamn
            if (newUsername.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (IsUsernameTaken(newUsername))
            {
                MessageBox.Show("This username is already taken.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validering av lösenord
            if (newPassword.Length < 5)
            {
                MessageBox.Show("Password must be at least 5 characters long.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Val av land
            string selectedCountry = ((ComboBoxItem)CountryComboBox.SelectedItem)?.Content.ToString();
            if (selectedCountry == null)
            {
                MessageBox.Show("Please select a country.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Spara ny användardata (lägg till din egen logik här)
            MessageBox.Show("User details saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Stäng fönstret och återgå till föregående fönster
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Metod för att kontrollera om användarnamnet är upptaget (simulerad)
        private bool IsUsernameTaken(string username)
        {
            // Här kan du lägga till logik för att kolla mot en databas eller lista med användarnamn
            return username == "TakenUsername"; // Simulerad kontroll
        }
    }
}

