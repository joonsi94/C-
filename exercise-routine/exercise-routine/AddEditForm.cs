using exercise_routine;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercise_routine
{
    public partial class AddEditForm : MaterialSkin.Controls.MaterialForm
    {
        public Workout WorkoutResult { get; private set; }
        public AddEditForm()
        {
            InitializeComponent();
            cmbPart.Items.AddRange(new string[] { "가슴", "등", "하체", "어깨", "팔", "복근" });
            cmbPart.SelectedIndex = 0; // 기본값으로 첫 번째 항목 선택

            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.Orange700,
                TextShade.WHITE
            );
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.sets.Text, out int parsedsets) || parsedsets <= 0)
            {
                MessageBox.Show("세트 수를 올바르게 입력하세요.");
                return;
            }

            if (!int.TryParse(this.reps.Text, out int parsedreps) || parsedreps <= 0)
            {
                MessageBox.Show("반복 수를 올바르게 입력하세요.");
                return;
            }

            if (!float.TryParse(this.weight.Text, out float parsedweight) || parsedweight < 0)
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

        private void exerciseName_Enter(object sender, EventArgs e)
        {
            exerciseName.Text = "운동이름";
        }
    }
}
