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
            cmbPart.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPart.SelectedIndex = 0; // 기본값으로 첫 번째 항목 선택

            exerciseName.TabIndex = 0;
            cmbPart.TabIndex = 1;
            sets.TabIndex = 2;
            reps.TabIndex = 3;
            weight.TabIndex = 4;
            todayDate.TabIndex = 5;
            memo.TabIndex = 6;
            btnSave.TabIndex = 7;

            SetPlaceholder(exerciseName, "운동명");
            SetPlaceholder(sets, "세트 수");
            SetPlaceholder(reps, "반복 수");
            SetPlaceholder(weight, "무게 (kg)");
            SetPlaceholder(memo, "기록 메모");

            todayDate.Enter += (s, e) => SendKeys.Send("%{DOWN}");

            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.Orange700,
                TextShade.WHITE
            );
        }
        private void SetPlaceholder(TextBox textbox, string placeholder)
        {
            textbox.Text = placeholder;
            textbox.ForeColor = Color.Gray;
            SetPlaceholderEvents(textbox, placeholder);
        }

        private void SetPlaceholderEvents(TextBox textbox, string placeholder)
        {
            textbox.Enter += (s, e) =>
            {
                if (textbox.Text == placeholder)
                {
                    textbox.Text = "";
                    textbox.ForeColor = Color.Black;
                }
            };

            textbox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    textbox.Text = placeholder;
                    textbox.ForeColor = Color.Gray;
                }
            };
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
    }
}
