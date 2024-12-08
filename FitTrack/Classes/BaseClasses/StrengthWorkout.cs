using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack.Classes.BaseClasses
{
    public class StrengthWorkout : Workout
    {
        public StrengthWorkout() {
            base.Type = "Styrketräning";
        }
        public int Weight { get; set; } //Vikt i kg
        public int Repetitions { get; set; } //Antal repetitioner
    }
}
