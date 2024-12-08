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
        public bool LoggedInAsAdmin {  get; set; }

        
        public List<User> Users { get; set; }

        public UserManagement()
        { 
            User adminUser = new User { Username = "admin", Password = "admin", Country = "Sverige", IsAdmin=true };
            User user = new User { Username = "Alex", Password = "123", Country = "Sverige" };
            CurrentUser = user;
            user.Workouts.Add(
                new CardioWorkout { Duration = 20, Date = new DateTime(2022, 12, 12), CaloriesBurned = 123, Notes = "blabla" }  
            );
            user.Workouts.Add(new StrengthWorkout { Duration = 60, Date = new DateTime(2018, 12, 13), CaloriesBurned = 200, Notes = "Test" });

            Users = new List<User>();
            Users.Add(user);
            Users.Add(adminUser);

        }

        public void UpdateWorkoutsList(List<Workout> workouts)
        {
            var foundUser = Users.FirstOrDefault(us => us.Username == CurrentUser.Username);
            if (foundUser != null)
            {
                foundUser.Workouts = workouts;
            }
        }
       
    }
}