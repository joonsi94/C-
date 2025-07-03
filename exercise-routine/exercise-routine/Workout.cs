using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_routine
{
    public class Workout
    {
        public int Id { get; set; } // DB 연동 시 Primary Key 역할
        public DateTime Date { get; set; }
        public string ExerciseName { get; set; }
        public string Part { get; set; } // 부위: 가슴, 등 등
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
        public string Memo { get; set; }
    }
}
