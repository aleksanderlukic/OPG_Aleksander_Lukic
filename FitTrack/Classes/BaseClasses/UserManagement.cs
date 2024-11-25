using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack.Classes.BaseClasses
{
    public class UserManagement
    {
        public User CurrentUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public List<Workout> Workouts { get; set; } = new List<Workout>();

        
        public List<User> Users { get; set; }

        public UserManagement()
        {
            User user = new User { Username = "Alex", Password = "123", Country = "Sverige" };
            user.Workouts.Add(new CardioWorkout { Duration = new TimeSpan(20), Type = "CardioWorkout" , Date = new DateOnly()   , CaloriesBurned = 123 , Notes = "blabla"  });
            Users = new List<User>();
            Users.Add(user);
            
        }
        public bool SignIn(string username, string password)
        {
            return username == Username && password == Password;
        }

       

        public void AddWorkout(Workout workout)
        {
            Workouts.Add(workout);
        }

        public void ResetPassword(string securityAnswer, string newPassword)
        {
            // Logik för att återställa lösenord
        }
    }
}