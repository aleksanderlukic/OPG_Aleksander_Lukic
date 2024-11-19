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
    /// Interaction logic for AddWorkoutsWindow.xaml
    /// </summary>
    //public partial class AddWorkoutsWindow : Window
    //{
    //    public AddWorkoutsWindow() { }

    //    public Workout NewWorkout { get; private set; } // Nya träningspasset som användaren skapar

    //        //InitializeComponent();


    //        // Hanterar "Spara"-knappen
    //        private void SaveWorkout_Click(object sender, RoutedEventArgs e)
    //        {
    //            // Validering av inmatning
    //            if (string.IsNullOrEmpty(WorkoutTypeComboBox.Text) ||
    //                string.IsNullOrEmpty(DurationInput.Text) ||
    //                string.IsNullOrEmpty(CaloriesBurnedInput.Text))
    //            {
    //                MessageBox.Show("Vänligen fyll i alla fält korrekt.");
    //                return;
    //            }

    //            try
    //            {
    //                // Skapa ett nytt Workout-objekt
    //                NewWorkout = new Workout
    //                {
    //                    Type = WorkoutTypeComboBox.Text,
    //                    Duration = TimeSpan.FromMinutes(Convert.ToDouble(DurationInput.Text)),
    //                    CaloriesBurned = Convert.ToInt32(CaloriesBurnedInput.Text),
    //                    Notes = NotesInput.Text,
    //                    Date = DateTime.Now // Använd nuvarande datum för träningspasset
    //                };

    //                DialogResult = true; // Signalerar att träningen sparades korrekt
    //                Close(); // Stänger fönstret
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show($"Ett fel uppstod: {ex.Message}");
    //            }
    //        }

    //        // Hanterar "Avbryt"-knappen
    //        private void Cancel_Click(object sender, RoutedEventArgs e)
    //        {
    //            DialogResult = false; // Användaren avbröt processen
    //            Close(); // Stänger fönstret utan att spara
    //        }
    //    }
    //}

    public partial class AddWorkoutsWindow : Window
    {
        public UserManagement manager;

        public User currentUser;
        public AddWorkoutsWindow(User user, UserManagement manager)
        {
            InitializeComponent();
            currentUser = user;
            this.manager = manager;
        }

        public Workout NewWorkout { get; set; } // Nya träningspasset som användaren skapar

        // Hanterar "Spara"-knappen
        private void SaveWorkout_Click(object sender, RoutedEventArgs e)
        {
            // Validering av inmatning
            if (string.IsNullOrEmpty(WorkoutTypeComboBox.Text) ||
                string.IsNullOrEmpty(DurationTextBox.Text) ||
                string.IsNullOrEmpty(CaloriesBurnedTextBox.Text))
            {
                MessageBox.Show("Vänligen fyll i alla fält korrekt.");
                return;
            }

            // Kontrollera om inmatade värden är giltiga
            if (!double.TryParse(DurationTextBox.Text, out double duration) ||
                !int.TryParse(CaloriesBurnedTextBox.Text, out int caloriesBurned))
            {
                MessageBox.Show("Vänligen ange giltiga värden för tid och kalorier.");
                return;
            }

            try
            {

                // Skapa ett nytt Workout-objekt
                NewWorkout = new CardioWorkout
                {
                    Type = WorkoutTypeComboBox.Text,
                    Duration = TimeSpan.FromMinutes(duration),
                    CaloriesBurned = caloriesBurned,
                    Notes = NotesTextBox.Text,
                    Date = DateOnly.Parse(DateTextBox.Text)
                };

                MessageBox.Show("En ny workout har skapats");
                DialogResult = true; // Signalerar att träningen sparades korrekt
                Close(); // Stänger fönstret
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ett fel inträffade: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }   
}


