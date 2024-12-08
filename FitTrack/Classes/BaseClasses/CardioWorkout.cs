﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack.Classes.BaseClasses
{
    public class CardioWorkout : Workout
    {
        public CardioWorkout()
        {
            base.Type = "Konditionsträning";
        }
       
        public int Distance  { get; set; } //distans i km
    }
}
