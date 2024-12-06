using FitTrack.Classes.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        UserManagement manager;
        public RegisterWindow(UserManagement manager)
        {
            InitializeComponent();
            this.manager = manager;
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string ConfirmPassword = ConfirmPasswordBox.Password;
            string country = CountryTextBox.Text;

            if (password == ConfirmPassword)

            {

                MessageBox.Show("Användare registrerad!");
                MainWindow mainWindow = new MainWindow(manager);
                mainWindow.Show();
                this.Close();

            }

            else

            {

                MessageBox.Show("Lösenorden matchar inte!");

            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)

        {

            MainWindow mainWindow = new MainWindow(manager);
            mainWindow.Show();
            this.Close();

        }
    }
}

