using FitTrack.Classes.BaseClasses;
using FitTrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace FitTrack.Classes.BaseClasses;
//{
//    public class Workout
//    {
//        public DateTime Date { get; set; }
//        public string Type { get; set; }
//        public TimeSpan Duration { get; set; }
//        public int CaloriesBurned { get; set; }
//        public string Notes { get; set; }

//        // Konstruktor
//        public Workout(DateTime date, string type, TimeSpan duration, string notes)
//        {
//            Date = date;
//            Type = type;
//            Duration = duration;
//            CaloriesBurned = 0;  // Startvärde, kan räknas ut senare
//            Notes = notes;
//        }

//        // Metod för att beräkna kaloriförbränning
//        public virtual int CalculateCaloriesBurned()
//        {
//            // En generell beräkning, kan vara annorlunda för specifika träningsformer
//            return (int)(Duration.TotalMinutes * 10); // Exempelberäkning
//        }
//    }
//}

//public partial class WorkoutsWindow : Window
//{
//    public User CurrentUser { get; private set; }
//    public List<Workout> WorkoutList { get; private set; }

//    public WorkoutsWindow()
//    {
//        InitializeComponent();
//    }

//    public WorkoutsWindow(User user) : this() // Anropar parameterlös konstruktor
//    {
//        CurrentUser = user;
//        WorkoutList = new List<Workout>(); // Initierar listan av träningspass
//        UpdateWorkoutList();
//    }

//    // Uppdaterar visningen av träningslistan (t.ex. i en ListView eller liknande)
//    private void UpdateWorkoutList()
//    {
//        WorkoutsListView.ItemsSource = null;  // Rensa befintliga objekt
//        WorkoutsListView.ItemsSource = WorkoutList;  // Sätt om datakällan
//    }

//    // Öppna fönstret för att lägga till ett nytt träningspass
//    private void AddWorkout_Click(object sender, RoutedEventArgs e)
//    {
//        var addWorkoutWindow = new AddWorkoutsWindow(); // Skapar nytt AddWorkoutWindow
//        addWorkoutWindow.Owner = this;

//        if (addWorkoutWindow.ShowDialog() == true) // Om användaren sparar träningspasset
//        {
//            if (addWorkoutWindow.NewWorkout != null) // Kontrollera om ett träningspass skapades
//            {
//                WorkoutList.Add(addWorkoutWindow.NewWorkout); // Lägg till träningspasset i listan
//                UpdateWorkoutList();  // Uppdatera listan efter att träningspasset lagts till
//            }
//            else
//            {
//                MessageBox.Show("Inget träningspass lades till.");
//            }
//        }
//    }
//}

public abstract class Workout
{
    public string Name
    {
        get { return Type + " - " + Date.ToString(); }   // get method
        set { Name = value; }  // set method
    }
    public DateOnly Date { get; set; }
    public string Type { get; set; }
    public TimeSpan Duration { get; set; }
    public int CaloriesBurned { get; set; }
    public string Notes { get; set; }

    public virtual double CalculateCaloriesBurned()
    {
        // Formel på hur mycket kalorier som bränts
        return (Duration.TotalMinutes * 5); // Exempel formula
    }
}