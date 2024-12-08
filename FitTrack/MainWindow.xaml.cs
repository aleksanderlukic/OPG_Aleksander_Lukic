using FitTrack.Classes.BaseClasses;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserManagement manager;
        public MainWindow(UserManagement manager)
        {

            InitializeComponent();
            this.manager = manager;

        }

        private void OpenWorkoutsWindow()
        {
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager);
            workoutsWindow.Show();
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenWorkoutsWindow();
        }

        private void CloseAllWorkoutWindows()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is WorkoutsWindow)
                {
                    window.Close();
                }
            }
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            var user = manager.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                MessageBox.Show("Inloggning lyckades!", "Inloggning", MessageBoxButton.OK, MessageBoxImage.Information);
                manager.CurrentUser = user;
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager);
                workoutsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fel användarnamn eller lösenord. Försök igen.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Logik för lösenordsändring
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logik för användarnamnändring
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerwindow = new RegisterWindow(manager);
            registerwindow.Show();
            this.Close();

            // Event handler för när lösenordet ändras i PasswordBox

         


        }

    }

}
