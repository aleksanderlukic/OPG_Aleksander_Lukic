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
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {
        private Workout workout;

        public WorkoutDetailsWindow(Workout selectedWorkout)
        {
            InitializeComponent();
            workout = selectedWorkout;

            // Fyll i detaljerna i fälten
            WorkoutTypeTextBox.Text = workout.GetType().Name;
            DurationTextBox.Text = workout.Duration.ToString();
            CaloriesBurnedTextBox.Text = workout.CaloriesBurned.ToString();
            NotesTextBox.Text = workout.Notes;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Uppdatera träningspasset med nya värden
            workout.Duration = new TimeSpan(int.Parse(DurationTextBox.Text));
            //workout.Duration = TimeSpan.FromMinutes(int.Parse(DurationTextBox.Text));
            workout.CaloriesBurned = int.Parse(CaloriesBurnedTextBox.Text);
            workout.Notes = NotesTextBox.Text;

            MessageBox.Show("Ändringar sparade!");
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Stäng fönstret utan att spara
            this.Close();
        }
    }
}

