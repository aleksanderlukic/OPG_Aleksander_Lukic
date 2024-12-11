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
    public partial class WorkoutDetailsWindow : Window
    {
        private WorkoutsWindow _workoutsWindow;
        private Workout _workout;
        public WorkoutDetailsWindow(WorkoutsWindow workoutsWindow, Workout workout)
        {
            InitializeComponent();
            _workoutsWindow = workoutsWindow;
            _workout = workout;
            DataContext = _workout; // Bind DataContext to workout object 
            // Set the selected value programmatically
            WorkoutTypeComboBox.SelectedValue = _workout.Type;
            
        }

        private void UnlockBtn_Click(object sender, RoutedEventArgs e)
        {
            WorkoutTypeComboBox.IsEnabled = true;
            DateInput.IsEnabled = true;
            CaloriesBurnedInput.IsEnabled = true;
            DurationMinInput.IsEnabled = true;
            NotesInput.IsEnabled = true;

            UnlockBtn.Visibility = Visibility.Collapsed;
            SaveBtn.Visibility = Visibility.Visible;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Validering av inmatning
            if (string.IsNullOrEmpty(WorkoutTypeComboBox.Text) ||
                string.IsNullOrEmpty(DurationMinInput.Text) ||
                string.IsNullOrEmpty(CaloriesBurnedInput.Text))
            {
                MessageBox.Show("Vänligen fyll i alla fält korrekt.");
                return;
            }

            // Kontrollera om inmatade värden är giltiga
            if (!double.TryParse(DurationMinInput.Text, out double duration) ||
                !int.TryParse(CaloriesBurnedInput.Text, out int caloriesBurned))
            {
                MessageBox.Show("Vänligen ange giltiga värden för tid och kalorier.");
                return;
            }

            MessageBox.Show("Sparat workout!");
            this.Close();
            _workoutsWindow.UpdateLayout();
            var currentSelected = _workoutsWindow.WorkoutListBox.SelectedIndex;
            _workoutsWindow.WorkoutList.RemoveAt(currentSelected);
            _workoutsWindow.WorkoutList.Insert(currentSelected, _workout);
            _workoutsWindow.WorkoutListBox.SelectedItem = _workout;
            _workoutsWindow.UpdateLayout();
            _workoutsWindow.Show();

        }

        private void WorkoutTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Stänger WorkoutDetailsWindow
            this.Close();

            // Om WorkoutsWindow redan är öppet, hitta den existerande instansen och visa den igen.
            // Detta förhindrar att en ny instans skapas varje gång.
            var workoutsWindow = Application.Current.Windows.OfType<WorkoutsWindow>().FirstOrDefault();
            if (workoutsWindow != null)
            {
                workoutsWindow.Show();
            }
            else
            {
                // Om WorkoutsWindow inte är öppet, skapa och visa det.
                WorkoutsWindow newWorkoutsWindow = new WorkoutsWindow();
                newWorkoutsWindow.Show();
            }
        }


    }
}

//    /// <summary>
//    /// Interaction logic for WorkoutDetailsWindow.xaml
//    /// </summary>
//    public partial class WorkoutDetailsWindow : Window
//    {
//        private Workout workout;

//        public WorkoutDetailsWindow(Workout selectedWorkout)
//        {
//            InitializeComponent();
//            workout = selectedWorkout;

//            // Fyll i detaljerna i fälten
//            WorkoutTypeTextBox.Text = workout.GetType().Name;
//            DurationTextBox.Text = workout.Duration.ToString();
//            CaloriesBurnedTextBox.Text = workout.CaloriesBurned.ToString();
//            NotesTextBox.Text = workout.Notes;
//        }

//        private void SaveButton_Click(object sender, RoutedEventArgs e)
//        {
//            // Uppdatera träningspasset med nya värden
//            workout.Duration = new TimeSpan(int.Parse(DurationTextBox.Text));
//            //workout.Duration = TimeSpan.FromMinutes(int.Parse(DurationTextBox.Text));
//            workout.CaloriesBurned = int.Parse(CaloriesBurnedTextBox.Text);
//            workout.Notes = NotesTextBox.Text;

//            MessageBox.Show("Ändringar sparade!");
//            this.Close();
//        }

//        private void CancelButton_Click(object sender, RoutedEventArgs e)
//        {
//            // Stäng fönstret utan att spara
//            this.Close();
//        }
//    }
//}

