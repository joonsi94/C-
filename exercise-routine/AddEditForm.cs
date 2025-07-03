using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using exercise_routine;

namespace exercise_routine
{
    public partial class AddEditForm : Form
    {
        public Workout WorkoutResult { get; private set; }
        public AddEditForm()
        {
            InitializeComponent();
            cmbPart.Items.AddRange(new string[] { "가슴", "등", "하체", "어깨", "팔", "복근" });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(sets.Text, out int sets) || sets <= 0)
            {
                MessageBox.Show("세트 수를 올바르게 입력하세요.");
                return;
            }

            if (!int.TryParse(reps.Text, out int reps) || reps <= 0)
            {
                MessageBox.Show("반복 수를 올바르게 입력하세요.");
                return;
            }

            if (!float.TryParse(weight.Text, out float weight) || weight < 0)
            {
                MessageBox.Show("무게를 올바르게 입력하세요.");
                return;
            }

            WorkoutResult = new Workout
            {
                Date = todayDate.Value,
                ExerciseName = exerciseName.Text,
                Part = cmbPart.Text,
                Sets = int.Parse(sets.Text),
                Reps = int.Parse(reps.Text),
                Weight = float.Parse(weight.Text),
                Memo = memo.Text
            };
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
