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

    // Hanterar användarrelaterade data och logik

    {
        public UserManagement manager;

        // Konstruktor för MainWindow, tar in en instans av UserManagement
        public MainWindow(UserManagement manager)
        {

            InitializeComponent(); // Initialiserar komponenterna i fönstret
            this.manager = manager; // Sätter den inkommande UserManagement-instansen till lokala fältet

        }

        // Öppnar WorkoutsWindow och skickar vidare UserManagement-instansen
        private void OpenWorkoutsWindow()
        {
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager);
            workoutsWindow.Show(); // Visar WorkoutsWindow
        }


        // Event handler för att hantera klick på "OpenButton"
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenWorkoutsWindow(); // Anropar metoden för att öppna WorkoutsWindow
        }


        // Stänger alla öppna WorkoutsWindow-fönster
        private void CloseAllWorkoutWindows()
        {
            foreach (Window window in Application.Current.Windows) // Loopa igenom alla öppna fönster
            {
                if (window is WorkoutsWindow) // Kontrollera om fönstret är av typen WorkoutsWindow
                {
                    window.Close(); // Stäng fönstret
                }
            }
        }

        // Event handler för inloggningsknappen

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text; // Hämtar användarnamn från inmatningsfältet
            string password = PasswordBox.Password; // Hämtar lösenord från lösenordsfältet

            // Letar efter en användare med matchande användarnamn och lösenord

            var user = manager.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null) // Om användaren hittas
            {
                MessageBox.Show("Inloggning lyckades!", "Inloggning", MessageBoxButton.OK, MessageBoxImage.Information);
                manager.CurrentUser = user; // Sätter den inloggade användaren som aktiv användare

                // Kontrollera om användaren är administratör

                if (user.IsAdmin == true)
                {
                    manager.LoggedInAsAdmin = true;
                }
                else
                {
                    manager.LoggedInAsAdmin = false;
                }


                // Öppnar WorkoutsWindow och stänger MainWindow

                WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager);
                workoutsWindow.Show();
                this.Close(); // Stänger MainWindow
            }
            else // Om inloggningen misslyckas
            {
                MessageBox.Show("Fel användarnamn eller lösenord. Försök igen.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler för när lösenordet ändras i lösenordsfältet

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Logik för lösenordsändring
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logik för användarnamnändring
        }

        // Event handler för registreringsknappen
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerwindow = new RegisterWindow(manager); // Skapar ett nytt RegisterWindow och skickar UserManagement-instansen
            registerwindow.Show(); // Visar RegisterWindow
            this.Close(); // Stänger MainWindow

            // Event handler för när lösenordet ändras i PasswordBox




        }

    }

}
