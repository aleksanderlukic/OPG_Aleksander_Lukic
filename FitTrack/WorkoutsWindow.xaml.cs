using FitTrack.Classes.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for WorkoutsWindow.xaml
    /// </summary>
    //public partial class WorkoutsWindow : Window
    //{
    //    public WorkoutsWindow()
    //    {
    //        InitializeComponent();
    //    }
    //        public User CurrentUser { get; private set; }
    //        public List<Workout> WorkoutList { get; private set; }

    //        public WorkoutsWindow(User user)
    //        {
    //            InitializeComponent();
    //            CurrentUser = user;
    //            WorkoutList = new List<Workout>(); // Initiell lista av träningspass
    //            UpdateWorkoutList();
    //        }

    //        // Uppdaterar visningen av träningslistan (t.ex. i en ListView eller liknande)
    //        private void UpdateWorkoutList()
    //        {
    //            // Här skulle du uppdatera din ListView eller annan kontroll som visar träningspassen
    //            // Exempel: WorkoutsListView.ItemsSource = WorkoutList;
    //        }

    //        // Öppna fönstret för att lägga till ett nytt träningspass
    //        private void AddWorkout_Click(object sender, RoutedEventArgs e)
    //        {
    //            var addWorkoutWindow = new AddWorkoutsWindow(); // Skapar nytt AddWorkoutWindow
    //            addWorkoutWindow.Owner = this;

    //            if (addWorkoutWindow.ShowDialog() == true) // Om användaren sparar träningspasset
    //            {
    //                if (addWorkoutWindow.NewWorkout != null) // Kontrollera om ett träningspass skapades
    //                {
    //                    WorkoutList.Add(addWorkoutWindow.NewWorkout); // Lägg till träningspasset i listan
    //                    UpdateWorkoutList(); // Uppdatera träningslistan
    //                }
    //            }
    //        }

    //        // Tar bort ett träningspass (om du har en knapp för detta)
    //        private void RemoveWorkout_Click(object sender, RoutedEventArgs e)
    //        {
    //            // Här kan du implementera logiken för att ta bort ett träningspass från WorkoutList
    //        }

    //        // Öppnar ett fönster för att se detaljer om ett valt träningspass
    //        private void OpenDetails_Click(object sender, RoutedEventArgs e)
    //        {
    //      /*  var selectedWorkout =*/ /* logik för att få det valda träningspasset */
    //            //if (selectedWorkout != null)
    //            {
    //                var workoutDetailsWindow = new WorkoutDetailsWindow(selectedWorkout);
    //                workoutDetailsWindow.Owner = this;
    //                workoutDetailsWindow.ShowDialog();
    //            }
    //        }
    //    }
    //}

    public partial class WorkoutsWindow : Window
    {
        private UserManagement manager;
        public User CurrentUser { get; private set; }
        private ObservableCollection<Workout> workoutList;

        public ObservableCollection<Workout> WorkoutList
        {
            get { return workoutList; }
            set
            {
                workoutList = value;
                OnPropertyChanged(nameof(WorkoutList));
            }
        }

        public WorkoutsWindow(UserManagement manager)
        {
            InitializeComponent();
            this.manager = manager;
            workoutList = new ObservableCollection<Workout>(); // Initialize the ObservableCollection
            DataContext = this; // Set the DataContext for data binding
        }

        private void AddWorkout_Click(object sender, RoutedEventArgs e)
        {
            var addWorkoutWindow = new AddWorkoutsWindow(CurrentUser, manager);

            if (addWorkoutWindow.ShowDialog() == true)
            {
                if (addWorkoutWindow.NewWorkout != null)
                {
                    WorkoutList.Add(addWorkoutWindow.NewWorkout); // Add new workout to the ObservableCollection
                }
                else
                {
                    MessageBox.Show("Inget träningspass lades till.");
                }
            }

            this.Show(); // Show the current window again
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UserDetails_Click(object sender, RoutedEventArgs e)
        {
            var userDetailsWindow = new UserDetailsWindow(manager);
            userDetailsWindow.Show();
        }

        private void RemoveWorkout_Click(object sender, RoutedEventArgs e)
        {
            if (WorkoutListBox.SelectedItem != null)
            {
                var selectedWorkout = WorkoutListBox.SelectedItem as Workout; //hitta valt träningspass
                if (selectedWorkout != null)
                {
                    WorkoutList.Remove(selectedWorkout); //ta bor det.

                }
                else
                {
                    MessageBox.Show("No workout selected.");
                }
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.");
            }
        }



        private void WorkoutDetails_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}